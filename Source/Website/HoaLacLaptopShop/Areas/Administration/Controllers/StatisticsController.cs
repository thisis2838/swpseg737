using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var order = _context.Orders.Include(o => o.Buyer).Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ToList();
            var salesData = CalculateSalesData(order);
            ViewBag.SalesData = salesData;
            return View(order);
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
