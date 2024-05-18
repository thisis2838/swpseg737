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
            });
            return View(rs);
        }

        public IActionResult FilterByPrice(float maxPrice)
        {
            var products = _db.Products.Where(p => p.Price <= maxPrice)
                              .Select(p => new ProductVM
                              {
                                  Id = p.ID,
                                  Name = p.Name,
                                  Description = p.Description ?? "",
                                  Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).Select(pi => pi.Link).ToList(),
                                  Price = p.Price
                              })
                              .ToList();

            return View("Index",products);
        }

        public IActionResult Detail(int pId)
        {
            var product = _db.Products.Where(p => p.ID == pId).FirstOrDefault();
            return View(product);
        }
    }
}
