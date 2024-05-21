using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public ProductController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        private IQueryable<Product> GetProducts()
        {
            return _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Brand)
                .AsQueryable();
        }

        public IActionResult Index(ProductIndexViewArgs args)
        {
            var products = GetProducts();
            if (args.Search != null) products = products.Where(x => x.Name.ToString().Contains(args.Search.ToString()));
            if (args.BrandID.HasValue) products = products.Where(p => p.BrandId == args.BrandID.Value);
            if (args.MinPrice.HasValue) products = products.Where(x => x.Price >= args.MinPrice);
            if (args.MaxPrice.HasValue) products = products.Where(x => x.Price <= args.MaxPrice);

            return View(new ProductIndexViewModel()
            {
                Products = products.ToList(),
                Arguments = args
            });
        }

        public IActionResult Detail(int id)
        {
            var product = GetProducts().Where(p => p.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}
