using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            IQueryable<Product> products() => _context.EnabledProducts
                .Include(x => x.ProductImages)
                .Include(x => x.Laptop).ThenInclude(x => x.CPUSeries).ThenInclude(x => x.Manufacturer)
                .Include(x => x.Laptop).ThenInclude(x => x.GPUSeries).ThenInclude(x => x.Manufacturer);
            return View(new HomeViewModel
            {
                PopularLaptops      = await products()
                                        .Include(x => x.OrderDetails)
                                        .Where(x => x.IsLaptop)
                                        .OrderByDescending(x => x.OrderDetails.Count)
                                        .Take(10).ToListAsync(),
                PopularAccessories  = await products()
                                        .Include(x => x.OrderDetails)
                                        .Where(x => !x.IsLaptop)
                                        .OrderByDescending(x => x.OrderDetails.Count)
                                        .Take(10).ToListAsync(),
                ProductsByBrand     = await products()
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
            IQueryable<Order> orders() => _context.Orders.Where(x => x.Status == OrderStatus.Finished);
            return View(new AboutViewModel()
            {
                TotalProducts = _context.EnabledProducts.Count(),
                TotalOrder = orders().Count(),
                TotalCustomersServed = orders().GroupBy(x => x.BuyerID).Count()
            });
        }
    }
}
