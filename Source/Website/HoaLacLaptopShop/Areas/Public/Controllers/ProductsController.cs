using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public ProductsController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        private IQueryable<Product> GetProducts()
        {
            return _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Brand);
        }

        public IActionResult Index(ProductIndexQuery args)
        {
            var products = GetProducts();
            var min = products.Min(x => x.Price);
            var max = products.Max(x => x.Price);
            products = products.Where(x => x.IsLaptop && args.ShowLaptops || !x.IsLaptop && args.ShowAccessories);
            if (args.Search != null) products = products.Where(x => x.Name.ToString().Contains(args.Search.ToString()));
            if (args.MinPrice.HasValue) products = products.Where(x => x.Price >= args.MinPrice);
            if (args.MaxPrice.HasValue) products = products.Where(x => x.Price <= args.MaxPrice);

            var cpus = new List<LaptopCPUSeries>();
            var gpus = new List<LaptopGPUSeries>();
            if (args.ShowLaptops)
            {
                cpus = _context.LaptopCPUSeries.ToList();
                gpus = _context.LaptopGPUSeries.ToList();
                products = products.Include(x => x.Laptop);

                // update selectable cpus and filter products accordingly
                if (args.SelectedCPUIDs != null)
                    args.SelectedCPUIDs = args.SelectedCPUIDs.Where(x => cpus.Select(y => y.ID).Contains(x)).ToList();
                if ((args.SelectedCPUIDs?.Count ?? 0) == 0)
                    args.SelectedCPUIDs = _context.LaptopCPUSeries.Select(x => x.ID).ToList();
                else
                    products = products.Where(x => !x.IsLaptop || args.SelectedCPUIDs!.Contains(x.Laptop!.CPUSeriesID));

                // update selectable gpus and filter products accordingly
                if (args.SelectedGPUIDs != null)
                    args.SelectedGPUIDs = args.SelectedGPUIDs.Where(x => gpus.Select(y => y.ID).Contains(x)).ToList();
                if ((args.SelectedGPUIDs?.Count ?? 0) == 0)
                    args.SelectedGPUIDs = _context.LaptopGPUSeries.Select(x => x.ID).ToList();
                else
                    products = products.Where(x => !x.IsLaptop || args.SelectedGPUIDs!.Contains(x.Laptop!.GPUSeriesID!.Value));
            }

            var list = products.ToList();
            var brands = list.GroupBy(x => x.Brand).Select(x => new BrandEntry(x.Key, x.Count())).ToList();
            if (args.SelectedBrandIDs != null)
                args.SelectedBrandIDs = args.SelectedBrandIDs.Where(x => brands.Select(y => y.Brand.ID).Contains(x)).ToList();
            if ((args.SelectedBrandIDs?.Count ?? 0) == 0)
                args.SelectedBrandIDs = brands.Select(x => x.Brand.ID).ToList();
            else 
                list = list.Where(x => args.SelectedBrandIDs!.Contains(x.Brand!.ID)).ToList();

            return View(new ProductIndexViewModel
            {
                Products = list,
                MinPossiblePrice = min,
                MaxPossiblePrice = max,
                Brands = brands,
                CPUs = cpus,
                GPUs = gpus,
                CurrentQuery = args
            });
        }

        public IActionResult Details(int id)
        {
            var product = GetProducts()
                .Include(x => x.ProductReviews.OrderByDescending(r => r.ReviewTime)).ThenInclude(x => x.Reviewer)
                .Include(x => x.Laptop).ThenInclude(x => x.CPUSeries)
                .Include(x => x.Laptop).ThenInclude(x => x.GPUSeries)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            if (product is null)
            {
                this.AddError("No product with that ID exists!");
                return NotFound();
            }

            return View(product);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddReview(int pId, int uId, string review, string rating = "0")
        {
            var user = _context.Users.Where(u => u.ID == uId).FirstOrDefault();
            var product = _context.Products.Find(pId);
            if (product is null)
            {
                this.AddError("Product doesn't exist!");
                return RedirectToAction("Index", "Home");
            }

            var hasBought = _context.OrderDetails.Include(x => x.Order).Any(x => x.ProductId == pId && x.Order.BuyerID == uId);
            if (!hasBought)
            {
                this.AddError("You must buy this product before you can review it.");
                goto end;
            }
            var previousReview = _context.ProductReviews.Find(pId, uId);
            if (previousReview != null)
            {
                this.AddError("You have already reviewed this product!");
                goto end;
            }

            var pr = new ProductReview
            {
                ProductId = pId,
                ReviewerId = uId,
                Content = review,
                Rating = int.Parse(rating),
                ReviewTime = DateTime.Now
            };
            _context.ProductReviews.Add(pr);
            _context.SaveChanges();

            end:;
            return RedirectToAction("Details", "Products", new { id = product.ID });
        }

        public IActionResult EditReview(int pId, int uId, string review, string rating, string? delete)
        {
            var reviewOld = _context.ProductReviews.Where(pr => pr.ProductId == pId && pr.ReviewerId == uId).FirstOrDefault();
            if (delete == null)
            {
                if (reviewOld != null)
                {
                    reviewOld.Content = review;
                    reviewOld.Rating = Convert.ToInt32(rating);
                    reviewOld.ReviewTime = DateTime.Now;
                }
            }
            else
            {
                if (reviewOld != null)
                {
                    _context.Remove(reviewOld);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Details", "Products", new { id = pId });
        }
    }
}
