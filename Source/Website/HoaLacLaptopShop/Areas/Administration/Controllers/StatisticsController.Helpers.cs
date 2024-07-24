using AngleSharp.Common;
using AngleSharp.Dom;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using NuGet.DependencyResolver;
using NuGet.Protocol;
using System;
using System.Linq.Expressions;
using static NuGet.Packaging.PackagingConstants;

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
		private ICollection<DatedRevenue> CalculateHistoricalRevenue
		(
			Func<IQueryable<Order>> orderProvider,
			DateTime fromDate, DateTime toDate,
			TimeSegment segment = TimeSegment.ByWeek
		)
		{
			fromDate = fromDate.Date; toDate = toDate.Date;

			// expression to turn order date into the segment number
			Expression<Func<DateTime, int>> timeToSegment = null!;
			// hackhack: for byday/week, we can only use datediff on the server and .totaldays on the client
			Expression<Func<DateTime, int>> timeToSegmentClient = null!;
			// expression to get the start date for a segment
			Expression<Func<int, DateTime>> timeFromSegment = null!;

			const int MONTHS_IN_YEAR = 12, QUARTERS_IN_YEAR = 4;
            // Define time segmentation logic based on the selected segment type
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

            // If client-side segmentation is not defined, use server-side
            timeToSegmentClient ??= timeToSegment;

            // Define expressions for grouping and selecting
            Expression<Func<Order, int>> groupByExpr = (o) => timeToSegment.Invoke(o.OrderTime);
			Expression<Func<IGrouping<int, Order>, DatedRevenue>> selectExpr = (group) => new DatedRevenue()
			{
				StartDate = timeFromSegment.Invoke(group.Key),
				Revenue = CalculateRevenueFromOrders(group)
			};
			// "expand" here is part of linqkit's extensions which allows us to use expressions
			// directly inside other expressions, instead of having to run them through
			// expresssion.lambda() and the like
			var revenueBySegment = orderProvider()
				.GroupBy(groupByExpr.Expand())
				.Select(selectExpr.Expand())
				.ToList();
            // Adjust from and to dates based on segmentation
            fromDate = timeFromSegment.Invoke(timeToSegmentClient.Invoke(fromDate));
			toDate = timeFromSegment.Invoke(timeToSegmentClient.Invoke(toDate));
            // Generate all start dates within the date range
            var startDates = Enumerable.Range(0, int.MaxValue)
				.Select(x =>
				{
					var date = timeFromSegment.Invoke(timeToSegmentClient.Invoke(fromDate) + x);
					if (date > toDate) return null;
					return (DateTime?)date;
				})
				// take until we're not over the end date
				.TakeWhile(x => x != null)
				.Select(x => x!.Value);
            // Perform left join to ensure all segments are represented
            return	
            (
				from date in startDates
				join rev in revenueBySegment on date equals rev.StartDate into joined
				from j in joined.DefaultIfEmpty()
				select j ?? new DatedRevenue() { StartDate = date, Revenue = new() }
			)
			.ToList();
		}

        // Helper method to calculate revenue from orders
        [Expandable(nameof(CalculateRevenueFromOrdersImpl))]
		public static Revenue CalculateRevenueFromOrders(IEnumerable<Order> orders)
		{
			return CalculateRevenueFromOrdersImpl().Compile().Invoke(orders);
		}

        // Implementation of revenue calculation from orders
        static Expression<Func<IEnumerable<Order>, Revenue>> CalculateRevenueFromOrdersImpl()
		{
			return (o) => new Revenue()
			{
				NumberOfOrders = o.Count(),
				UnitsSold = o.SelectMany(x => x.OrderDetails).Sum(x => x.Quantity),
				TotalRevenue = o.Sum(x => x.DiscountedPrice),
				Customers = o.Select(x => x.BuyerID).Distinct().Count()
			};
		}
        // Helper method to calculate revenue from order details
        [Expandable(nameof(CalculateRevenueFromOrderDetailsImpl))]
		public static Revenue CalculateRevenueFromOrderDetails(IEnumerable<OrderDetail> orders)
		{
			return CalculateRevenueFromOrderDetailsImpl().Compile().Invoke(orders);
		}

        // Implementation of revenue calculation from order details
        static Expression<Func<IEnumerable<OrderDetail>, Revenue>> CalculateRevenueFromOrderDetailsImpl()
		{
			return (d) => new Revenue()
			{
				NumberOfOrders = d.Select(x => x.OrderId).Distinct().Count(),
				UnitsSold = d.Sum(x => x.Quantity),
				TotalRevenue = d.Sum(x => x.Quantity * (long)x.ProductPrice),
				Customers = d.Select(x => x.Order.BuyerID).Distinct().Count()
			};
		}

	}
}
