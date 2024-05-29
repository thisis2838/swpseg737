using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HoaLacLaptopShop.Controllers
{
    public class HomeController : Controller
    {
		private readonly HoaLacLaptopShopContext _context = null!;

		public HomeController(HoaLacLaptopShopContext context)
		{
			_context = context;
		}
        public IActionResult Index()
        {
            var products = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.OrderDetails)
                .Include(x => x.Brand);
			return View(new HomeViewModel 
            {
                PopularLaptops = products.Where(x => x.IsLaptop).OrderByDescending(x => x.OrderDetails.Count).Take(10).ToList(),
                PopularAccessories = products.Where(x => !x.IsLaptop).OrderByDescending(x => x.OrderDetails.Count).Take(10).ToList(),
                ProductsByBrand = products.Take(100).GroupBy(x => x.Brand).AsEnumerable().ToDictionary(x => x.Key!, x => x.ToList()),
                LatestNews = _context.NewsPosts.OrderByDescending(x => x.Time).Take(3).ToList()
			});
        }
        public IActionResult About()
        {
            return View(new AboutViewModel()
            {
                TotalProducts = _context.Products.Count(),
                TotalOrder = _context.Orders.Count(),
                TotalCustomersServed = _context.Orders.GroupBy(x => x.BuyerID).Count()
            });
        }

    }
}
