using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class HomeController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public HomeController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = _context.Products.Include(x => x.ProductImages).AsSplitQuery();
            return View(new HomeViewModel
            {
                PopularLaptops      = await products
                                        .Include(x => x.OrderDetails)
                                        .Where(x => x.IsLaptop)
                                        .OrderByDescending(x => x.OrderDetails.Count)
                                        .Take(10).ToListAsync(),
                PopularAccessories  = await products
                                        .Include(x => x.OrderDetails)
                                        .Where(x => !x.IsLaptop)
                                        .OrderByDescending(x => x.OrderDetails.Count)
                                        .Take(10).ToListAsync(),
                ProductsByBrand     = await products
                                        .Include(x => x.Brand)
                                        .GroupBy(x => x.Brand)
                                        .Select(x => new { x.Key, Items = x.Take(5) })
                                        .ToDictionaryAsync(x => x.Key!, x => x.Items.ToList()),
                LatestNews          = await _context.NewsPosts
                                        .OrderByDescending(x => x.Time)
                                        .Take(3).ToListAsync()
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