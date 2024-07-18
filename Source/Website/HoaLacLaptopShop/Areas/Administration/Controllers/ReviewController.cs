using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ReviewController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;
        public ReviewController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? targetPage)
        {
            var reviews = _context.ProductReviews.Include(p => p.Product).ThenInclude(p => p.ProductImages).Include(p => p.Reviewer).OrderBy(p => p.ReviewTime).ToList();
            return View(new ReviewViewModel
            {
                ProductReviews = reviews.Skip((targetPage == null ? 1 : targetPage.Value) * 10).Take(10).ToList(),
                TotalCount = reviews.Count,
                TargetPage = targetPage == null ? 1 : targetPage.Value,
            });
        }

        public IActionResult Detail(int pid, int rid)
        {
            var product = _context.Products.Where(p => p.ID == pid).Include(p => p.ProductImages).Include(p => p.Brand).FirstOrDefault();
            var reviewer = _context.Users.Where(u => u.ID == rid).FirstOrDefault();
            var review = _context.ProductReviews.Where(pr => pr.ProductId == pid && pr.ReviewerId == rid).FirstOrDefault();
            return View(new ReviewDetailViewModel
            {
                Product = product,
                User = reviewer,
                ProductReview = review
            });
        }

        public IActionResult Delete(int pid, int rid)
        {
            var review = _context.ProductReviews.Where(pr => pr.ProductId == pid && pr.ReviewerId == rid).FirstOrDefault();
            _context.ProductReviews.Remove(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
