using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        public AdminController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        private IQueryable<Product> GetProducts(int page)
        {
            return _context.Products
                .Skip((page - 1) * 10)
                .Take(10)
                .Include(x => x.ProductImages)
                .Include(x => x.Brand);
        }

        public IActionResult Product(int? page)
        {
            var products = GetProducts(page != null ? Convert.ToInt32(page) : 1);

            return View(new ProductAdminViewModel
            {
                Products = products.ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = page != null ? Convert.ToInt32(page) : 1
            }); ;
        }

        public IActionResult SearchProduct(string search)
        {
            var products = GetProducts(1);
            return View("Product",new ProductAdminViewModel
            {
                Products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = 1
            }); ;
        }


    }
}
