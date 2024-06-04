using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;
        
        public AdminController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }
        public IActionResult Product()
        {
            return View();
        }
        
        public IActionResult Order()
        {
            var order = _context.Orders.Include(o => o.Buyer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(oi => oi.Product).ToList();
            return View(order);
        }

    }
}
