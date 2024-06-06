using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class ReviewController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public ReviewController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        private IQueryable<Product> GetProducts()
        {
            return _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Brand);
        }

        public IActionResult AddReview(int pId, int uId, string review, string rating)
        {
            var user = _context.Users.Where(u => u.ID == uId).FirstOrDefault();
            if (user != null)
            {
                var product = GetProducts()
                    .Include(x => x.ProductReviews.OrderByDescending(r => r.Time)).ThenInclude(x => x.Reviewer)
                    .Include(x => x.Laptop).ThenInclude(x => x.CPUSeries)
                    .Include(x => x.Laptop).ThenInclude(x => x.GPUSeries)
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                    .Where(p => p.ID == pId)
                    .FirstOrDefault();

                ProductReview pr = new ProductReview
                {
                    ProductId = pId,
                    ReviewerId = uId,
                    Content = review,
                    Rating = Convert.ToInt32(rating),
                    Time = DateTime.Now,
                    Reviewer = _context.Users.Where(u => u.ID == uId).FirstOrDefault(),
                    Product = _context.Products.Where(p => p.ID == pId).FirstOrDefault()
                };

                _context.ProductReviews.Add(pr);
                _context.SaveChanges();
                return RedirectToAction("Detail", "Products", product);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        public IActionResult EditReview(int pId, int uId, string review, string rating, string? delete)
        {
            var product = GetProducts()
                .Include(x => x.ProductReviews.OrderByDescending(r => r.Time)).ThenInclude(x => x.Reviewer)
                .Include(x => x.Laptop).ThenInclude(x => x.CPUSeries)
                .Include(x => x.Laptop).ThenInclude(x => x.GPUSeries)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                .Where(p => p.ID == pId)
                .FirstOrDefault();

            if (delete == null)
            {
                var reviewOld = _context.ProductReviews.Where(pr => pr.ProductId == pId && pr.ReviewerId == uId).FirstOrDefault();
                reviewOld.Content = review;
                reviewOld.Rating = Convert.ToInt32(rating);
                reviewOld.Time = DateTime.Now;
            } else
            {
                var reviewOld = _context.ProductReviews.Where(pr => pr.ProductId == pId && pr.ReviewerId == uId).FirstOrDefault();
                _context.Remove(reviewOld);
            }
            _context.SaveChanges();
            return RedirectToAction("Detail", "Products", product);

        }
    }
}
