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
		public IActionResult Sales(GeneralStatsIndexArgs? args)
		{
			args ??= new GeneralStatsIndexArgs();
			DateTime now;
			{
				int dayOfWeek = ((int)DateTime.Now.DayOfWeek + 6) % 7;
				now = DateTime.Now.Date.AddDays(-dayOfWeek);
			}

			var days = args.TimeRange switch
			{
				TimeRange.LastWeek => 7,
				TimeRange.LastMonth => 7 * 4,
				TimeRange.LastQuarter => (7 * 4 * 3),
				TimeRange.LastYear => (7 * 4 * 3 * 4),
				_ => throw new Exception()
			};
			var start = now - TimeSpan.FromDays(days);

			// -- order based revenue -- //

			IQueryable<Order> orders() => _context.Orders.Include(x => x.OrderDetails)
				.AsNoTracking().AsExpandableEFCore()
				.Where(x => x.Status != OrderStatus.Created &&x.OrderTime <= now && x.OrderTime >= start);
			var totalRev = CalculateRevenueFromOrders(orders());
			var historical = CalculateHistoricalRevenue(orders, start, now, args.TimeSegment);

			var newCustomers = orders().Include(x => x.Buyer).ThenInclude(x => x.Orders)
				.Select(x => x.Buyer).Distinct()
				.Where(x => x.Orders.All(x => x.OrderTime >= start))
				.Count();

			// -- order details based revenue -- //

			IQueryable<OrderDetail> orderDetails() => _context
				.OrderDetails.AsNoTracking().AsExpandableEFCore()
				.Include(x => x.Order).Where(x => x.Order.Status != OrderStatus.Created && x.Order.OrderTime <= now && x.Order.OrderTime >= start)
				.Include(x => x.Product).ThenInclude(x => x.Brand);
			
			var topBrands = takeTop(orderDetails().GroupBy(x => x.Product.Brand), 10);
			var topProducts = takeTop(orderDetails().GroupBy(x => x.Product), 10);

			// efcore doesn't persist .includes after a groupby, for some reason...
			{
				var ids = topProducts.Select(x => x.Key.ID).ToList();
				var actual = _context.Products.Include(x => x.Brand).Include(x => x.ProductImages)
					.Where(x => ids.Contains(x.ID))
					.ToDictionary(x => x.ID, x => x);
				topProducts = topProducts.Select(x => new KeyValuePair<Product, Revenue>(actual[x.Key.ID], x.Value)).ToList();
			}

			var vm = new GeneralStatsViewModel()
			{
				TimeRange = args.TimeRange,
				TimeSegment = args.TimeSegment,
				GeneralRevenue = totalRev,
				HistoricalStats = historical,
				TopBrands = topBrands,
				TopProducts = topProducts,

				NewCustomers = newCustomers
			};

			return View(vm);
		}
        public IActionResult Brand(GeneralStatsIndexArgs? args, int Id)
        {
            args ??= new GeneralStatsIndexArgs();
            DateTime now;
            {
                int dayOfWeek = ((int)DateTime.Now.DayOfWeek + 6) % 7;
                now = DateTime.Now.Date.AddDays(-dayOfWeek);
            }
            var days = args.TimeRange switch
            {
                TimeRange.LastWeek => 7,
                TimeRange.LastMonth => 7 * 4,
                TimeRange.LastQuarter => (7 * 4 * 3),
                TimeRange.LastYear => (7 * 4 * 3 * 4),
                _ => throw new Exception()
            };
            var start = now - TimeSpan.FromDays(days);

            // Query for orders of the specific brand
            IQueryable<Order> orders() => _context.Orders
                .Include(x => x.OrderDetails)
                .ThenInclude(od => od.Product)
                .AsNoTracking().AsExpandableEFCore()
                .Where(x => x.Status != OrderStatus.Created &&
                            x.OrderTime <= now &&
                            x.OrderTime >= start &&
                            x.OrderDetails.Any(od => od.Product.BrandId == Id));

            var totalRev = CalculateRevenueFromOrders(orders());
            var historical = CalculateHistoricalRevenue(orders, start, now, args.TimeSegment);

            // Query for order details of the specific brand
            IQueryable<OrderDetail> orderDetails() => _context.OrderDetails
                .AsNoTracking().AsExpandableEFCore()
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(x => x.Order.Status != OrderStatus.Created &&
                            x.Order.OrderTime <= now &&
                            x.Order.OrderTime >= start &&
                            x.Product.BrandId == Id);

            // Get top 5 products for the brand
            var topProducts = takeTop(orderDetails().GroupBy(x => x.Product), 5);

            // Retrieve full product details
            var productIds = topProducts.Select(x => x.Key.ID).ToList();
            var actualProducts = _context.Products
                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Where(x => productIds.Contains(x.ID))
                .ToDictionary(x => x.ID, x => x);

            topProducts = topProducts
                .Select(x => new KeyValuePair<Product, Revenue>(actualProducts[x.Key.ID], x.Value))
                .ToList();

            // Get brand details
            var brand = _context.Brands.FirstOrDefault(b => b.ID == Id);
            if (brand == null)
            {
                return NotFound();
            }

            var vm = new BrandStatsViewModel()
            {
                TimeRange = args.TimeRange,
                TimeSegment = args.TimeSegment,
                Brand = brand,
                GeneralRevenue = totalRev,
                HistoricalStats = historical,
                TopProducts = topProducts
            };

            return View(vm);
        }

        public IActionResult Product(GeneralStatsIndexArgs? args, int Id)
        {
            args ??= new GeneralStatsIndexArgs();
            DateTime now;
            {
                int dayOfWeek = ((int)DateTime.Now.DayOfWeek + 6) % 7;
                now = DateTime.Now.Date.AddDays(-dayOfWeek);
            }
            var days = args.TimeRange switch
            {
                TimeRange.LastWeek => 7,
                TimeRange.LastMonth => 7 * 4,
                TimeRange.LastQuarter => (7 * 4 * 3),
                TimeRange.LastYear => (7 * 4 * 3 * 4),
                _ => throw new Exception()
            };
            var start = now - TimeSpan.FromDays(days);

            // Query for orders containing the specific product
            IQueryable<Order> orders() => _context.Orders
                .Include(x => x.OrderDetails)
                .AsNoTracking().AsExpandableEFCore()
                .Where(x => x.Status != OrderStatus.Created &&
                            x.OrderTime <= now &&
                            x.OrderTime >= start &&
                            x.OrderDetails.Any(od => od.ProductId == Id));

            var totalRev = CalculateRevenueFromOrders(orders());
            var historical = CalculateHistoricalRevenue(orders, start, now, args.TimeSegment);

            // Query for order details of the specific product
            IQueryable<OrderDetail> orderDetails() => _context.OrderDetails
                .AsNoTracking().AsExpandableEFCore()
                .Include(x => x.Order)
                .Where(x => x.Order.Status != OrderStatus.Created &&
                            x.Order.OrderTime <= now &&
                            x.Order.OrderTime >= start &&
                            x.ProductId == Id);

            // Get product details
            var product = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.ID == Id);

            if (product == null)
            {
                return NotFound();
            }

            var vm = new ProductStatsViewModel()
            {
                TimeRange = args.TimeRange,
                TimeSegment = args.TimeSegment,
                Product = product,
                GeneralRevenue = totalRev,
                HistoricalStats = historical
            };

            return View(vm);
        }
        private ICollection<KeyValuePair<T, Revenue>> takeTop<T>(IQueryable<IGrouping<T, OrderDetail>> grouped, int num) where T : class
        {
            return grouped
                .Select(x => new { key = x.Key, rev = CalculateRevenueFromOrderDetails(x) })
                .OrderByDescending(x => x.rev.UnitsSold)
                .Take(num)
                .ToDictionary(x => x.key, x => x.rev);
        }

    }
}
