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
                .Include(x => x.Voucher)
                .OrderBy(x => x.Status).ThenByDescending(x => x.OrderTime)
                .Where(x => x.BuyerID == id)
                .Where(x => x.Status != OrderStatus.Created);
        }
        [Authorize]
        public async Task<IActionResult> OrderHistory(OrderHistoryViewArgs? args = null)
        {
            args ??= new OrderHistoryViewArgs();
            return View(new OrderHistoryViewModel()
            {
                Status = args.Status,
                Orders = await Orders().Where(x => x.Status == (OrderStatus)args.Status).ToListAsync()
            });
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
                .OrderBy(x => x.ReviewTime)
                .Where(pr => pr.ReviewerId == id);
        }
        [Authorize]
        public async Task<IActionResult> ReviewHistory(int page = 1)
        {
            var id = HttpContext.GetCurrentUser()!.ID;
            var user = _context.Users.Find(id)!;

            var curPage = await Reviews().Skip((page - 1) * 12).Take(12).ToListAsync();
            return View(new ReviewViewModel
            {
                ProductReviews = curPage,
                TotalCount = await Reviews().CountAsync(),
                TargetPage = page
            });
        }
        [Authorize]
        public async Task<IActionResult> ReviewDetails(int pid)
        {
            var userID = HttpContext.GetCurrentUser()!.ID;
            var review = await Reviews() .FirstOrDefaultAsync(x => x.ProductId == pid);

            if (review is null)
            {
                this.AddError("The requested review could not be found.");
                return NotFound();
            }    
            return View(review);
        }
    }
}
