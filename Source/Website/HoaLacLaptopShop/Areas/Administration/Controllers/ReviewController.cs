using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Marketing")]
    public class ReviewController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;
        public ReviewController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(ReviewIndexViewArgs args)
        {
            var reviews = _context.ProductReviews
                .Include(p => p.Product).ThenInclude(p => p.ProductImages)
                .Include(p => p.Product).ThenInclude(p => p.Brand)
                .Include(p => p.Reviewer)
                .OrderByDescending(p => p.ReviewTime)
                .AsQueryable();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.Search))
                {
                    reviews = reviews.Where(x => 
                        x.Reviewer.Name.ToLower().Contains(args.Search.ToLower())
                        || x.Content.ToLower().Contains(args.Search.ToLower())
                        || x.Product.Name.ToLower().Contains(args.Search.ToLower())
                        || x.Product.Brand.Name.ToLower().Contains(args.Search.ToLower())
                    );
                }
                if (args.StarCount.HasValue && args.StarCount.Value > 0)
                {
                    reviews = reviews.Where(x => x.Rating == args.StarCount.Value);
                }
            }

            const int REVIEWS_PER_PAGE = 20;
            var pages = (int)Math.Ceiling((await reviews.CountAsync()) / (float)REVIEWS_PER_PAGE);
            if (!ModelState.IsValid) args.Page = 1;
            reviews = reviews.Skip((args.Page - 1) * REVIEWS_PER_PAGE).Take(REVIEWS_PER_PAGE);

            var vm = new ReviewIndexViewModel()
            {
                ProductReviews = await reviews.ToListAsync(),
                TotalPages = pages
            };
            vm.FillFromOther(args);
            return View(vm);
        }

        public IActionResult Details(int pid, int rid)
        {
            var review = _context.ProductReviews
                .Include(p => p.Product).ThenInclude(p => p.ProductImages)
                .Include(p => p.Product).ThenInclude(p => p.Brand)
                .Include(p => p.Reviewer)
                .Where(pr => pr.ProductId == pid && pr.ReviewerId == rid)
                .FirstOrDefault();
            if (review is null)
            {
                this.AddError("The requested review could not be found.");
                return NotFound();
            }
            return View(review);
        }

        public IActionResult Delete(int pid, int rid)
        {
            var review = _context.ProductReviews.Where(pr => pr.ProductId == pid && pr.ReviewerId == rid).FirstOrDefault();
            if (review is null)
            {
                this.AddError("The requested review could not be found.");
                return NotFound();
            }
            _context.ProductReviews.Remove(review);
            _context.SaveChanges();
            this.AddMessage("Successfully deleted review.");
            return RedirectToAction("Index");
        }
    }
}
