using AngleSharp.Common;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    public partial class StatisticsController : Controller
	{
		/*
		 * basic logic:
		 * 
		 * convert the order time of each order into an integer
		 * - if segmenting by days, get the number of days between the order date and start date
		 * - if segmenting by weeks, get the number of weeks between the order date and the start date
		 * - if segmenting by month, turn the order date into YYYYMM
		 * - if segmenting by quarter, turn the order date into YYYYQQ
		 * - if segmenting by year, get the year of the order date
		 * for months, quarters, and years; we have to handle overflows correctly,
		 * for example: quarter 202004 should be 202100 (assuming zero index)
		 * these conversions are lossy in nature since we only care about the start
		 * dates of each segment.
		 * 
		 * (we're converting stuff into integers as a more complex data type 
		 * would require needlessly more work to get sql server acting correctly)
		 * 
		 * then we group the orders by the new value on the server, 
		 * then convert the integers back into a datetime representing the start of the segment
		 * so for example, the first day of the week, month, etc
		 * 
		 * there may be segments which don't have any orders, in which case we have to put
		 * empty revenue data into it by generating a list of start dates from the start to end date
		 * then simply outerjoining the groupby data with the dates
		 * 
		 * we'll be utilizing expressions since they allow direct translation into sql
		 * so we can run all the conversion code on the server, thus putting the work onto the sql server
		 *  
		 */

		// expressions which converts to and from a datetime to an integer
		// representing the time segment it lies inside
		private struct SegmentGroupingExpressions
		{
			public required TimeSegment TimeSegment;
            // expression to turn order date into the segment number
            public required Expression<Func<DateTime, int>> TimeToSegment;
            // hackhack: for byday/week, we can only use datediff on the server and .totaldays on the client
            public required Expression<Func<DateTime, int>> TimeToSegmentClient;
            // expression to get the start date for a segment
            public required Expression<Func<int, DateTime>> TimeFromSegment;

			public DateTime GetSegmentStartDate(DateTime t, int offset = 0)
			{
				return TimeFromSegment.Invoke(TimeToSegmentClient.Invoke(t) + offset);
			}
        }
		private SegmentGroupingExpressions GroupingExpressionFromTimeSegment(TimeSegment segment, DateTime fromDate)
		{
            const int MONTHS_IN_YEAR = 12, QUARTERS_IN_YEAR = 4;

            Expression<Func<DateTime, int>> timeToSegment = null!;
            Expression<Func<DateTime, int>> timeToSegmentClient = null!;
            Expression<Func<int, DateTime>> timeFromSegment = null!;
            switch (segment)
            {
                case TimeSegment.ByDay:
                    timeToSegment = (d) => EF.Functions.DateDiffDay(fromDate, d);
                    timeToSegmentClient = (d) => (int)(d - fromDate).TotalDays;
                    timeFromSegment = (d) => fromDate.AddDays(d);
                    break;
                case TimeSegment.ByWeek:
                    timeToSegment = (d) => EF.Functions.DateDiffWeek(fromDate, d);
                    timeToSegmentClient = (d) => (int)((d - fromDate).TotalDays / 7);
                    timeFromSegment = (d) => fromDate.AddDays(d * 7);
                    break;
                case TimeSegment.ByMonth:
                    timeToSegment = (d) => d.Year * 100 + (d.Month - 1);
                    timeFromSegment = (d) => new DateTime
                    (
                        d / 100 + (d % 100) / MONTHS_IN_YEAR,
                        (d % 100 % MONTHS_IN_YEAR) + 1,
                        1
                    );
                    break;
                case TimeSegment.ByQuarter:
                    timeToSegment = (d) => d.Year * 10 + d.Month / QUARTERS_IN_YEAR;
                    timeFromSegment = (d) => new DateTime
                    (
                        d / 10 + (d % 10) / QUARTERS_IN_YEAR,
                        ((d % 10) % QUARTERS_IN_YEAR) * (MONTHS_IN_YEAR / QUARTERS_IN_YEAR) + 1,
                        1
                    );
                    break;
                case TimeSegment.ByYear:
                    timeToSegment = (d) => d.Year;
                    timeFromSegment = (d) => new DateTime(d, 1, 1);
                    break;
            }

			// define client-side timeToSegment as server-side if not otherwise indicated
            timeToSegmentClient ??= timeToSegment;

            return new SegmentGroupingExpressions()
			{
                TimeSegment = segment,
                TimeFromSegment = timeFromSegment,
				TimeToSegment = timeToSegment,
				TimeToSegmentClient = timeToSegmentClient
			};
        }
		// get all the start dates of the segments between 2 dates
		private IEnumerable<DateTime> GetSegmentStartDatesInBetween(SegmentGroupingExpressions expr, DateTime from, DateTime to)
		{
            // Adjust from and to dates based on segmentation
            from = expr.GetSegmentStartDate(from);
			// adjust to to account for the data from to up till now
            to = expr.GetSegmentStartDate(to);
            // Generate all start dates within the date range
            return Enumerable.Range(0, int.MaxValue)
                .Select(x =>
                {
                    var date = expr.GetSegmentStartDate(from, x);
                    if (date > to) return null;
                    return (DateTime?)date;
                })
                // take until we're not over the end date
                .TakeWhile(x => x != null)
                .Select(x => x!.Value);
        }

        private ICollection<DatedStatistics> CalculateHistoricalRevenue
		(
			Func<IQueryable<Order>> orderProvider,
			DateTime fromDate, DateTime toDate,
			TimeSegment segment = TimeSegment.ByWeek
		)
		{
			fromDate = fromDate.Date; toDate = toDate.Date;

			// Define time segmentation logic based on the selected segment type
			var groupingExprs = GroupingExpressionFromTimeSegment(segment, fromDate);

            // Define expressions for grouping and selecting
            Expression<Func<Order, int>> groupByExpr = (o) => groupingExprs.TimeToSegment.Invoke(o.OrderTime);
			Expression<Func<IGrouping<int, Order>, DatedStatistics>> selectExpr = (group) => new DatedStatistics()
			{
				StartDate = groupingExprs.TimeFromSegment.Invoke(group.Key),
				Statistics = CalculateRevenueFromOrders(group)
			};
			// "expand" here is part of linqkit's extensions which allows us to use expressions
			// directly inside other expressions, instead of having to run them through
			// expresssion.lambda() and the like
			var revenueBySegment = orderProvider().GroupBy(groupByExpr.Expand()).Select(selectExpr.Expand()).ToList();
            
            // Perform left join to ensure all segments are represented
            return	
            (
				from date in GetSegmentStartDatesInBetween(groupingExprs, fromDate, toDate)
				join rev in revenueBySegment on date equals rev.StartDate into joined
				from j in joined.DefaultIfEmpty()
				select j ?? new DatedStatistics() { StartDate = date, Statistics = new() }
			)
			.ToList();
		}
        private ICollection<DatedStatistics> CalculateHistoricalRevenue
        (
            Func<IQueryable<OrderDetail>> orderProvider,
            DateTime fromDate, DateTime toDate,
            TimeSegment segment = TimeSegment.ByWeek
        )
        {
            fromDate = fromDate.Date; toDate = toDate.Date;

            // Define time segmentation logic based on the selected segment type
            var groupingExprs = GroupingExpressionFromTimeSegment(segment, fromDate);

            // Define expressions for grouping and selecting
            Expression<Func<OrderDetail, int>> groupByExpr = (o) => groupingExprs.TimeToSegment.Invoke(o.Order.OrderTime);
            Expression<Func<IGrouping<int, OrderDetail>, DatedStatistics>> selectExpr = (group) => new DatedStatistics()
            {
                StartDate = groupingExprs.TimeFromSegment.Invoke(group.Key),
                Statistics = CalculateRevenueFromOrderDetails(group)
            };
            // "expand" here is part of linqkit's extensions which allows us to use expressions
            // directly inside other expressions, instead of having to run them through
            // expresssion.lambda() and the like
            var revenueBySegment = orderProvider().GroupBy(groupByExpr.Expand()).Select(selectExpr.Expand()).ToList();

            // Perform left join to ensure all segments are represented
            return
            (
                from date in GetSegmentStartDatesInBetween(groupingExprs, fromDate, toDate)
                join rev in revenueBySegment on date equals rev.StartDate into joined
                from j in joined.DefaultIfEmpty()
                select j ?? new DatedStatistics() { StartDate = date, Statistics = new() }
            )
            .ToList();
        }

        // Helper method to calculate revenue from orders
        [Expandable(nameof(CalculateRevenueFromOrdersImpl))]
		public static SaleStatistics CalculateRevenueFromOrders(IEnumerable<Order> orders)
		{
			return CalculateRevenueFromOrdersImpl().Compile().Invoke(orders);
		}

        // Implementation of revenue calculation from orders
        static Expression<Func<IEnumerable<Order>, SaleStatistics>> CalculateRevenueFromOrdersImpl()
		{
			return (o) => new SaleStatistics()
			{
				NumberOfOrders = o.Count(),
				UnitsSold = o.SelectMany(x => x.OrderDetails).Sum(x => x.Quantity),
				TotalRevenue = o.Sum(x => x.DiscountedPrice),
                GrossSales = o.Sum(x => x.TotalPrice),
				Customers = o.Select(x => x.BuyerID).Distinct().Count()
			};
		}
        // Helper method to calculate revenue from order details
        [Expandable(nameof(CalculateRevenueFromOrderDetailsImpl))]
		public static SaleStatistics CalculateRevenueFromOrderDetails(IEnumerable<OrderDetail> orders)
		{
			return CalculateRevenueFromOrderDetailsImpl().Compile().Invoke(orders);
		}

        // Implementation of revenue calculation from order details
        static Expression<Func<IEnumerable<OrderDetail>, SaleStatistics>> CalculateRevenueFromOrderDetailsImpl()
		{
			return (d) => new SaleStatistics()
			{
				NumberOfOrders = d.Select(x => x.OrderId).Distinct().Count(),
				UnitsSold = d.Sum(x => x.Quantity),
                TotalRevenue = null,
                GrossSales = d.Sum(x => x.ProductPrice * (long)x.Quantity),
				Customers = d.Select(x => x.Order.BuyerID).Distinct().Count()
			};
		}


        // take the top entities by quantities sold
        protected ICollection<KeyValuePair<T, SaleStatistics>> TakeTop<T>(IQueryable<IGrouping<T, OrderDetail>> grouped, int num) where T : class
        {
            return grouped
                .Select(x => new { key = x.Key, rev = CalculateRevenueFromOrderDetails(x) })
                .OrderByDescending(x => x.rev.UnitsSold).Take(num)
                .ToDictionary(x => x.key, x => x.rev);
        }
        // fill full information for products as .GroupBy operations like to strip away foreign keys
        protected void FillFullProductInformation(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                var full = _context.Products.Include(x => x.Brand).Include(x => x.ProductImages).SingleOrDefault(x => x.ID == product.ID)!;
                product.FillFromOther(full);
            }
        }
    }
}
