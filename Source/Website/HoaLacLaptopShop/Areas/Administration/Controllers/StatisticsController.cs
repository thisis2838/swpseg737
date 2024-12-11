using AngleSharp.Common;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using LinqKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using NuGet.DependencyResolver;
using NuGet.Protocol;
using System;
using System.Linq.Expressions;
using static NuGet.Packaging.PackagingConstants;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
	[Area("Administration")]
	[Authorize(Roles = "Marketing")]
	public partial class StatisticsController : Controller
	{
		private readonly HoaLacLaptopShopContext _context = null!;
		public StatisticsController(HoaLacLaptopShopContext context)
		{
			_context = context;
		}


        // get orders for use in statistics
        [NonAction]
        private IQueryable<Order> GetOrders(DateTime from, DateTime to)
        {
            return _context.Orders
                .AsNoTracking().AsExpandableEFCore()
                .Include(x => x.OrderDetails)
                .Where(x => x.Status != OrderStatus.Created && x.OrderTime <= to && x.OrderTime >= from);
        }
        // get orders for use in statistics
        [NonAction]
        private IQueryable<OrderDetail> GetOrderDetails(DateTime from, DateTime to)
        {
            return _context
                .OrderDetails.AsNoTracking().AsExpandableEFCore()
                .Include(x => x.Order)
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Where(x => x.Order.Status != OrderStatus.Created && x.Order.OrderTime <= to && x.Order.OrderTime >= from);
        }
        [NonAction]
        private int TimeRangeToDays(TimeRange range)
        {
            return range switch
            {
                TimeRange.LastWeek => 7,
                TimeRange.LastMonth => 7 * 4,
                TimeRange.LastQuarter => (7 * 4 * 3),
                TimeRange.LastYear => (7 * 4 * 3 * 4),
                TimeRange.ShopLifetime => (int)Math.Ceiling((DateTime.Now - _context.Orders.Min(x => x.OrderTime)).TotalDays),
                _ => throw new Exception()
            };
        }

        public IActionResult Sales(GeneralStatsIndexArgs? args)
		{
			args ??= new GeneralStatsIndexArgs();
            var now = DateTime.Now.ToMondayOfWeek();
            var days = TimeRangeToDays(args.TimeRange);
            var start = now - TimeSpan.FromDays(days);

            // -- order based revenue -- //

            IQueryable<Order> orders() => GetOrders(start, now);
            var totalRev = CalculateRevenueFromOrders(orders());
			var historical = CalculateHistoricalRevenue(orders, start, now, args.TimeSegment);

            // -- order details based revenue -- //

            IQueryable<OrderDetail> orderDetails() => GetOrderDetails(start, now);
            var topBrands = TakeTop(orderDetails().GroupBy(x => x.Product.Brand), 10);
			var topProducts = TakeTop(orderDetails().GroupBy(x => x.Product), 10);
            FillFullProductInformation(topProducts.Select(x => x.Key));

            var vm = new GeneralStatsViewModel()
			{
				TimeRange = args.TimeRange,
				TimeSegment = args.TimeSegment,
				GeneralStats = totalRev,
				HistoricalStats = historical,
				TopBrands = topBrands,
				TopProducts = topProducts,
			};

			return View(vm);
		}

        public IActionResult Brand(GeneralStatsIndexArgs? args, int Id)
        {
            // Get brand details
            var brand = _context.Brands.FirstOrDefault(b => b.ID == Id);
            if (brand == null)
            {
                this.AddError("The requested brand could not be found.");
                return NotFound();
            }

            args ??= new GeneralStatsIndexArgs();
            var now = DateTime.Now.ToMondayOfWeek();
            var days = TimeRangeToDays(args.TimeRange);
            var start = now - TimeSpan.FromDays(days);

            // Query for order details of the specific brand
            IQueryable<OrderDetail> orderDetails() => GetOrderDetails(start, now).Where(x => x.Product.BrandId == Id);
            var totalRev = CalculateRevenueFromOrderDetails(orderDetails());
            var historical = CalculateHistoricalRevenue(orderDetails, start, now, args.TimeSegment);

            // Get top 5 products for the brand
            var topProducts = TakeTop(orderDetails().GroupBy(x => x.Product), 5);
            FillFullProductInformation(topProducts.Select(x => x.Key));
            
            var vm = new BrandStatsViewModel()
            {
                TimeRange = args.TimeRange,
                TimeSegment = args.TimeSegment,
                Brand = brand,
                GeneralStats = totalRev,
                HistoricalStats = historical,
                TopProducts = topProducts
            };

            return View(vm);
        }
        public IActionResult Product(GeneralStatsIndexArgs? args, int Id)
        {
            // Get product details
            var product = _context.Products.Include(p => p.Brand).Include(p => p.ProductImages).FirstOrDefault(p => p.ID == Id);
            if (product == null)
            {
                return NotFound();
            }

            args ??= new GeneralStatsIndexArgs();
            var now = DateTime.Now.ToMondayOfWeek();
            var days = TimeRangeToDays(args.TimeRange);
            var start = now - TimeSpan.FromDays(days);

            // Query for order details of the specific brand
            IQueryable<OrderDetail> orderDetails() => GetOrderDetails(start, now).Where(x => x.ProductId == Id);
            var totalRev = CalculateRevenueFromOrderDetails(orderDetails());
            var historical = CalculateHistoricalRevenue(orderDetails, start, now, args.TimeSegment);

            var vm = new ProductStatsViewModel()
            {
                TimeRange = args.TimeRange,
                TimeSegment = args.TimeSegment,
                Product = product,
                GeneralStats = totalRev,
                HistoricalStats = historical
            };

            return View(vm);
        }
    }
}
