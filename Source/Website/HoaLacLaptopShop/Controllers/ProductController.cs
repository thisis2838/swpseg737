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
                Name = p.Name,
                Description = p.Description ?? "",
                Link = _db.ProductImages.Where(pi => pi.ProductId == p.ID).FirstOrDefault().Link ?? "",
                Price = p.Price,
            });
            return View(rs);
        }
    }
}
