using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public partial class AccountController : Controller
    {
        [NonAction]
        private IQueryable<Order> Orders()
        {
            var id = HttpContext.GetCurrentUser()!.ID;
            return _context.Orders
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImages)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Voucher)
                .OrderBy(x => x.Status).ThenByDescending(x => x.OrderTime)
                .Where(x => x.BuyerID == id)
                .Where(x => x.Status != OrderStatus.Created);
        }
        [Authorize]
        public async Task<IActionResult> OrderHistory(OrderHistoryViewArgs? args = null)
        {
            args ??= new OrderHistoryViewArgs();
            var orders = Orders().Where(x => x.Status == (OrderStatus)args.Status);

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.Search))
                {
                    orders = orders.Where(x => x.OrderDetails.Any
                    (
                        y =>
                            y.Product.Name.ToLower().Contains(args.Search.ToLower())
                            || y.Product.Brand.Name.ToLower().Contains(args.Search.ToLower())
                    ));
                }
            }

            const int ORDERS_PER_PAGE = 20;
            var pages = (int)Math.Ceiling((await orders.CountAsync()) / (float)ORDERS_PER_PAGE);
            if (ModelState.IsValid) orders = orders.Skip((args.Page - 1) * ORDERS_PER_PAGE).Take(ORDERS_PER_PAGE);

            var vm = new OrderHistoryViewModel
            {
                Orders = await orders.ToListAsync(),
                TotalPages = pages,
            };
            vm.FillFromOther(args);
            return View(vm);
        }
        [Authorize]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await Orders().FirstOrDefaultAsync(x => x.ID == id);
            if (order is null)
            {
                this.AddError("The requested order could not be found");
                return NotFound();
            }
            return View(order);
        }

        [NonAction]
        private IQueryable<ProductReview> Reviews()
        {
            var id = HttpContext.GetCurrentUser()!.ID;
            return _context.ProductReviews
                .Include(x => x.Product).ThenInclude(x => x.ProductImages)
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .OrderByDescending(x => x.ReviewTime)
                .Where(pr => pr.ReviewerId == id);
        }
        [Authorize]
        public async Task<IActionResult> ReviewHistory(ReviewHistoryViewArgs? args = null)
        {
            args ??= new ReviewHistoryViewArgs();

            var reviews = Reviews();
            if (ModelState.IsValid)
            {
                if (args.StarCount.HasValue && args.StarCount.Value > 0)
                    reviews = reviews.Where(x => x.Rating == args.StarCount);
                if (!string.IsNullOrWhiteSpace(args.Search))
                    reviews = reviews.Where
                    (
                        x => x.Product.Name.ToLower().Contains(args.Search.ToLower())
                            || x.Product.Brand.Name.ToLower().Contains(args.Search.ToLower())
                            || x.Content.ToLower().Contains(args.Search.ToLower())
                    );
            }

            const int REVIEWS_PER_PAGE = 20;
            var pages = (int)Math.Ceiling((await reviews.CountAsync()) / (float)REVIEWS_PER_PAGE);
            if (ModelState.IsValid) reviews = reviews.Skip((args.Page - 1) * REVIEWS_PER_PAGE).Take(REVIEWS_PER_PAGE);

            var vm = new ReviewHistoryViewModel
            {
                ProductReviews = await reviews.ToListAsync(),
                TotalPages = pages,
            };
            vm.FillFromOther(args);
            return View(vm);
        }
    }
}
