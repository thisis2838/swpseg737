using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using HoaLacLaptopShop.Areas.Public.Controllers;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdminController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        private readonly IWebHostEnvironment _environment;

        public AdminController(HoaLacLaptopShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Order()
        {
            var order = _context.Orders.Include(o => o.Buyer).Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ToList();
            return View(order);
        }

        public IActionResult Dashboard()
        {
            var order = _context.Orders.Include(o => o.Buyer).Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ToList();
            var salesData = CalculateSalesData(order);
            ViewBag.SalesData = salesData;
            return View(order);
        }

        public IActionResult OrderDetail(int id)
        {
            var order = _context.Orders
                    .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                    .Include(o => o.Buyer)
                    .SingleOrDefault(o => o.ID == id);
            if (order == null)
            {
                return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrder(int id, string recipientName, string email, string phoneNumber,
                                  string city, string district, string ward, string street, string note)
        {
            var existingOrder = _context.Orders
                    .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                    .Include(o => o.Buyer)
                    .SingleOrDefault(o => o.ID == id);

            if (existingOrder == null) return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });

            existingOrder.RecipientName = recipientName;
            existingOrder.Buyer.Email = email; // Update nested property
            existingOrder.PhoneNumber = phoneNumber;
            existingOrder.Province = city;
            existingOrder.District = district;
            existingOrder.Ward = ward;
            existingOrder.Street = street;
            existingOrder.Note = note;

            return View("OrderDetail", existingOrder);
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
                    .Sum(o => o.TotalPrice - o.DiscountedPrice);

                salesData.Insert(0, totalSales);
            }

            return salesData;
        }
    }
}
