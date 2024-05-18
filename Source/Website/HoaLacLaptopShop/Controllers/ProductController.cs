using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly HoaLacLaptopShopContext _db;

        public ProductController(HoaLacLaptopShopContext context)
        {
            _db = context;
        }
        public IActionResult Index(int? brand)
        {
            var products = _db.Products.AsQueryable();
            if (brand.HasValue)
            {
                products = products.Where(p => p.BrandId == brand.Value);
            }

            var rs = products.Select(p => new ProductVM
            {
                Id = p.ID,
                Name = p.Name,
                Description = p.Description ?? "",
                Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).Select(pi => pi.Link).ToList(),
                Price = p.Price,
                Stock = p.Stock,
                Brand = _db.Brands.Where(b => b.ID == p.BrandId).FirstOrDefault(),
            });
            return View(rs);
        }

        public IActionResult FilterByPrice(int minPrice, int maxPrice)
        {
            Console.WriteLine(minPrice + "##############$$$$$$$$$$$$$$$" + maxPrice);
            var products = _db.Products.Where(p => p.Price <= maxPrice && p.Price >= minPrice)
                              .Select(p => new ProductVM
                              {
                                  Id = p.ID,
                                  Name = p.Name,
                                  Description = p.Description ?? "",
                                  Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).Select(pi => pi.Link).ToList(),
                                  Price = p.Price,
                                  Stock = p.Stock,
                                  Brand = _db.Brands.Where(b => b.ID == p.BrandId).FirstOrDefault(),
                              })
                              .ToList();

            return View("Index",products);
        }

        public IActionResult Detail(int pId)
        {
            var product = _db.Products.Where(p => p.ID == pId).Select(p => new ProductVM
			{
				Id = p.ID,
				Name = p.Name,
				Description = p.Description ?? "",
				Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).Select(pi => pi.Link).ToList(),
				Price = p.Price,
                Stock = p.Stock,
                Brand = _db.Brands.Where(b => b.ID == p.BrandId).FirstOrDefault(),
                ProductReview = _db.ProductReviews.Where(pr => pr.ProductId == p.ID).ToList(),
                RelatedProducts = _db.Products.Where(rp => rp.ID != p.ID && rp.BrandId == p.BrandId).Select(p => new ProductVM
                {
                    Id = p.ID,
                    Name = p.Name,
                    Description = p.Description ?? "",
                    Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).Select(pi => pi.Link).ToList(),
                    Price = p.Price,
                    Stock = p.Stock,
                    Brand = _db.Brands.Where(b => b.ID == p.BrandId).FirstOrDefault(),
                }).ToList(),
            }).FirstOrDefault();
            return View(product);
        }
    }
}
