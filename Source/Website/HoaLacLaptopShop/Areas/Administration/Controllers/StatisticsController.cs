﻿using AngleSharp.Common;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
	[Area("Administration")]
	[Authorize(Roles = "Admin,Marketing")]
	public class StatisticsController : Controller
	{
		private readonly HoaLacLaptopShopContext _context = null!;
		public StatisticsController(HoaLacLaptopShopContext context)
		{
			_context = context;
		}

		public IActionResult Sales()
		{
			var order = _context.Orders.Include(o => o.OrderDetails)
				.Where(o => o.Status != OrderStatus.Created)
				.ToList();
			var earningOrder = order.Where(o => o.Status == OrderStatus.Finished).ToList();

			var salesData = CalculateSalesData(order);
			var salesMoney = CalculateSalesNumber(order).GetItemByIndex(0);
			var salesPercentage = CalculateSalesNumber(order).GetItemByIndex(1);
			var orderCount = OrderCount(order)[0];
			var orderPercentage = OrderCount(order)[1];
			var userCount = CalculateVistorsNumber(order)[0];
			var userPercentage = CalculateVistorsNumber(order)[1];

			var topSellingProducts = _context.OrderDetails
									.Include(od => od.Product)
										.ThenInclude(p => p.ProductImages)
									.Include(od => od.Product.Brand)
									.GroupBy(od => od.ProductId)
									.Select(g => new
									{
										Product = g.First().Product,
										Count = g.Count()
									})
									.OrderByDescending(x => x.Count)
									.Take(5)
									.ToList();
			var brandCounts = _context.Orders.SelectMany(o => o.OrderDetails).GroupBy(od => od.Product.Brand)
				   .Select(g => new { Brand = g.Key, Count = g.Count() })
				   .OrderByDescending(b => b.Count)
				   .ToList();

			var top4Brands = brandCounts.Take(4).ToList();
			var otherCount = brandCounts.Skip(4).Sum(b => b.Count);
			var brandData = new List<KeyValuePair<string, int>>();
			brandData.AddRange(top4Brands.Select(b => new KeyValuePair<string, int>(b.Brand.Name, b.Count)));
			if (otherCount > 0)
			{
				brandData.Add(new KeyValuePair<string, int>("Other", otherCount));
			}

			ViewBag.BrandData = brandData;
			ViewBag.TopSellingProducts = topSellingProducts;
			ViewBag.SalesData = salesData;
			ViewBag.SalesMoney = salesMoney;
			ViewBag.SalesPercentage = salesPercentage;
			ViewBag.OrderCount = orderCount;
			ViewBag.OrderPercentage = orderPercentage;
			ViewBag.UserCount = userCount;
			ViewBag.UserPercentage = userPercentage;
			ViewBag.TopSellingProducts = topSellingProducts;

			return View(order);
		}

		public List<Decimal> CalculateVistorsNumber(List<Order> orders)
		{
			DateTime now = DateTime.Now;
			DateTime lastWeekStart = now.AddDays(-7);
			DateTime twoWeeksAgoStart = lastWeekStart.AddDays(-7);

			// count the customers of last 7 days
			var userIdsLastWeekCount = _context.Orders
				.Where(o => o.Status != OrderStatus.Created && o.OrderTime >= lastWeekStart && o.OrderTime < now)
				.Select(o => o.BuyerID)
				.Distinct()
				.Count();
			// count the customers of last 
			var userIdsPreviousWeekCount = _context.Orders
				.Where(o => o.Status != OrderStatus.Created && o.OrderTime >= twoWeeksAgoStart && o.OrderTime < lastWeekStart)
				.Select(o => o.BuyerID)
				.Distinct()
				.Count();

			decimal percentageChange = userIdsPreviousWeekCount == 0
				? (userIdsLastWeekCount == 0 ? 0 : 100)
				: ((decimal)(userIdsLastWeekCount - userIdsPreviousWeekCount) / userIdsPreviousWeekCount) * 100;

			return new List<decimal> { userIdsLastWeekCount, percentageChange };
		}
		public List<Decimal> CalculateSalesNumber(List<Order> orders)
		{
			DateTime currentDate = DateTime.Now;
			// Calculate how many days have passed since the most recent Monday
			int dayOfWeek = ((int)currentDate.DayOfWeek + 6) % 7;
			DateTime mostRecentMonday = currentDate.AddDays(-dayOfWeek);

			// Calculate the sales of this and last week, then compare
			decimal thisWeekSale = 0;
			for (int i = 0; i <= dayOfWeek; i++)
			{
				DateTime targetDay = mostRecentMonday.AddDays(i);
				decimal totalSalesForDay = orders
					.Where(order => order.OrderTime.Date == targetDay.Date)
					.Sum(order => order.TotalPrice - order.DiscountedPrice);

				thisWeekSale += totalSalesForDay;
			}

			decimal lastWeekSale = 0;
			DateTime lastWeekMonday = currentDate.AddDays(-7 - dayOfWeek);
			for (int i = 0; i <= dayOfWeek; i++)
			{
				DateTime targetDay = lastWeekMonday.AddDays(i);
				decimal totalSalesForDay = orders
					.Where(order => order.OrderTime.Date == targetDay.Date)
					.Sum(order => order.TotalPrice - order.DiscountedPrice);
				lastWeekSale += totalSalesForDay;
			}
			if (lastWeekSale == 0) lastWeekSale = 1;

			// Calculate the percentage change
			decimal percentageChange = ((thisWeekSale - lastWeekSale) / lastWeekSale) * 100 > 1000 ? 1000 : ((thisWeekSale - lastWeekSale) / lastWeekSale) * 100;
			List<Decimal> salesData = new List<Decimal>
			{
				thisWeekSale,
				percentageChange
			};
			return salesData;
		}

		public List<decimal> CalculateSalesData(List<Order> orders)
		{
			DateTime currentDate = DateTime.Now.Date;
			List<decimal> salesData = new List<decimal>();

			for (int i = 0; i < 7; i++)
			{
				DateTime targetDate = currentDate.AddDays(-i);
				decimal totalSales = orders
					.Where(o => o.OrderTime.Date == targetDate)
					.Sum(o => o.TotalPrice - o.DiscountedPrice) / 1000000;

				salesData.Insert(0, totalSales);
			}

			return salesData;
		}

		public List<decimal> OrderCount(List<Order> orders)
		{
			DateTime currentDate = DateTime.Now;
			// Calculate how many days have passed since the most recent Monday
			int dayOfWeek = ((int)currentDate.DayOfWeek + 6) % 7;
			DateTime mostRecentMonday = currentDate.AddDays(-dayOfWeek);
			DateTime lastWeekMonday = currentDate.AddDays(-7 - dayOfWeek);

			// Calculate the sales of this and last week, then compare
			decimal thisWeekOrders = _context.Orders.Count(o => o.Status != OrderStatus.Created && (o.OrderTime <= currentDate && o.OrderTime >= mostRecentMonday));
			decimal lastWeekOrders = orders.Count(o => o.Status != OrderStatus.Created && (o.OrderTime >= lastWeekMonday && o.OrderTime < mostRecentMonday));

			decimal percentage = lastWeekOrders == 0 ? (thisWeekOrders - 1) * 100 : ((thisWeekOrders - lastWeekOrders) / lastWeekOrders) * 100;
			if (percentage > 1000) percentage = 1000;
			List<decimal> orderData = new List<decimal>
			{
				thisWeekOrders,
				percentage
			};
			return orderData;
		}

	}
}
