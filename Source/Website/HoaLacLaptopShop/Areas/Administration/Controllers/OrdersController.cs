using HoaLacLaptopShop.Areas.Public.Controllers;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin,Sales")]
    public class OrdersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public OrdersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                .ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                .Include(o => o.Buyer)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (order is null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Order input)
        {
            var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.ID == input.ID);
            if (order is null)
            {
                this.AddError("Couldn't find order.");
                return RedirectToAction("Index", "Orders");
            }
            if (order.Status != OrderStatus.Created)
            {
                this.AddError("Cannot edit order as it has reached the delivering stage.");
                return RedirectToAction("Details", "Orders", new{ model = order });
            }

            order.District = input.District;
            order.Province = input.Province;
            order.Ward = input.Ward;
            order.Street = input.Street;
            order.Note = input.Note;
            order.RecipientName = input.RecipientName;
            order.PhoneNumber = input.PhoneNumber;

            var checkedFields = new string[]
            {
                nameof(Order.ID),
                nameof(Order.District), nameof(Order.Province), nameof(Order.Ward), nameof(Order.Street),
                nameof(Order.Note), nameof(Order.RecipientName), nameof(Order.PhoneNumber)
            };
            if (checkedFields.All(x => ModelState[x]!.ValidationState == ModelValidationState.Valid))
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Orders", new { model = order });
        }
    }
}
