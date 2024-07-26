using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Areas.Public.Controllers;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
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
    [Authorize(Roles = "Sales")]
    public class OrdersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public OrdersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(OrderIndexViewArgs args)
        {
            var orders = _context.Orders
                .Include(o => o.Buyer)
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ThenInclude(x => x.Brand)
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ThenInclude(x => x.ProductImages)
                .OrderByDescending(x => x.OrderTime)
                .AsQueryable();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.ProductSearch))
                {
                    var search = args.ProductSearch.ToLower();
                    orders = orders.Where
                    (
                        x => 
                            x.OrderDetails.Any(y => y.Product.Name.Contains(search) || y.Product.Brand.Name.Contains(search))
                    );
                }
                if (!string.IsNullOrWhiteSpace(args.RecipientSearch))
                {
                    var search = args.RecipientSearch.ToLower();
                    orders = orders.Where
                    (
                        x =>
                            x.Buyer.Name.Contains(search) 
                            || x.RecipientName.Contains(search) || x.PhoneNumber.Contains(search)
                    );
                }
                if (!string.IsNullOrWhiteSpace(args.DestinationSearch))
                {
                    var search = args.DestinationSearch.ToLower();
                    orders = orders.Where
                    (
                        x =>
                            x.Street.Contains(search) || x.Ward.Contains(search) 
                            || x.District.Contains(search) || x.Province.Contains(search)
                    );
                }

            }

            if (!ModelState.IsValid) args.Status = Public.ViewModels.SelectableOrderStatus.Delivering;
            orders = orders.Where(x => x.Status == (OrderStatus)args.Status);

            const int ORDER_PER_PAGE = 20;
            var pages = (int)Math.Ceiling((await orders.CountAsync()) / (float)ORDER_PER_PAGE);
            if (!ModelState.IsValid) args.Page = 1;
            orders = orders.Skip((args.Page - 1) * ORDER_PER_PAGE).Take(ORDER_PER_PAGE);

            var vm = new OrderIndexViewModel()
            {
                Orders = await orders.ToListAsync(),
                TotalPages = pages
            };
            vm.FillFromOther(args);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ThenInclude(x => x.ProductImages)
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ThenInclude(x => x.Brand)
                .Include(o => o.Buyer)
                .Include(x => x.Voucher)
                .Where(x => x.Status != OrderStatus.Created)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (order is null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ModelStateInclude
        (
            nameof(Order.RecipientName),
            nameof(Order.PhoneNumber),
            nameof(Order.Province),
            nameof(Order.District),
            nameof(Order.Ward),
            nameof(Order.Street),
            nameof(Order.Status)
        )]
        public async Task<IActionResult> Edit(Order input)
        {
            var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.ID == input.ID);
            if (order is null)
            {
                this.AddError("The requested order could not be found");
                return NotFound();
            }
            if (order.Status == OrderStatus.Finished)
            {
                this.AddError("Cannot edit order as it has finished.");
                return RedirectToAction(nameof(Details), new { id = input.ID });
            }

            if (ModelState.IsValid)
            {
                order.District = input.District;
                order.Province = input.Province;
                order.Ward = input.Ward;
                order.Street = input.Street;
                order.RecipientName = input.RecipientName;
                order.PhoneNumber = input.PhoneNumber;
                order.Status = input.Status;

                _context.Update(order);
                await _context.SaveChangesAsync();
                this.AddMessage("Successfully edited order");
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Details), new { id = input.ID });
        }
    }
}
