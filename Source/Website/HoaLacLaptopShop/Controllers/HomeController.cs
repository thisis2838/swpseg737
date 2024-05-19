using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
			return View(new HomeViewModel 
            {
                PopularLaptops = _context.Products.Where(x => x.IsLaptop).OrderByDescending(x => x.OrderDetails.Count).Take(10).ToList(),
                PopularAccessories = _context.Products.Where(x => !x.IsLaptop).OrderByDescending(x => x.OrderDetails.Count).Take(10).ToList(),
                ProductsByBrand = _context.Products.Take(100).GroupBy(x => x.Brand).AsEnumerable().ToDictionary(x => x.Key!, x => x.ToList()),
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
