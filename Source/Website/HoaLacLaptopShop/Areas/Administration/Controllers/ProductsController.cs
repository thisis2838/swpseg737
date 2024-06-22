using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Data;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin,Sales")]
    public class ProductsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(HoaLacLaptopShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IQueryable<Product> GetProducts(int page)
        {
            return _context.Products
                .Skip((page - 1) * 10).Take(10)
                .Include(x => x.ProductImages).Include(x => x.Brand);
        }

        public IActionResult Index(int? page)
        {
            var products = GetProducts(page != null ? page.Value : 1);
            return View(new ProductIndexViewModel
            {
                Products = products.ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = page != null ? Convert.ToInt32(page) : 1
            }); ;
        }

        public IActionResult SearchProduct(string search)
        {
            var products = GetProducts(1);
            return View("Product", new ProductIndexViewModel
            {
                Products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = 1
            });
        }

        public IActionResult Create()
        {
            var pro = new ProductDetailViewModel();
            ViewData["Brands"] = _context.Brands.ToList();
            ViewData["Cpus"] = _context.LaptopCPUSeries.ToList();
            ViewData["Gpus"] = _context.LaptopGPUSeries.ToList();
            return View(pro);
        }

        [HttpPost, Authorize(Roles = "Sales")]
        public async Task<IActionResult> Create(ProductDetailViewModel product, IFormFile image)
        {
            _context.FillForeignKeys((Product)product);
            _context.FillForeignKeys(product.Laptop);

            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    // Get the path to the wwwroot/images/products directory
                    string uploadDirectory = Path.Combine(_environment.WebRootPath, "images", "products");

                    // Ensure the directory exists; create it if not
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }
                    // Generate a unique filename for the uploaded image
                    string uniqueFileName = $"{DateTime.Now.Ticks:X}+{new Random().Next(0, 0xFFFF):X}";
                    // Combine the upload directory path with the unique filename and ".jpeg" extension
                    string filePath = Path.Combine(uploadDirectory, uniqueFileName + ".jpeg");
                    // Save the uploaded image to the specified file path as JPEG
                    using (var localImage = Image.Load(image.OpenReadStream()))
                    {
                        localImage.Save(filePath, new JpegEncoder());
                    }
                    List<ProductImage> pi = new List<ProductImage>
                    {
                        new ProductImage()
                        {
                            DisplayIndex = 0,
                            Token = uniqueFileName
                        }
                    };
                    product.ProductImages = pi;
                }

                product.Laptop = product.IsLaptop ? product.Laptop : null;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
