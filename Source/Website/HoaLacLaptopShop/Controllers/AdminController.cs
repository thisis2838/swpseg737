using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;

        private readonly IWebHostEnvironment _environment;

        public AdminController(HoaLacLaptopShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IQueryable<Product> GetProducts(int page)
        {
            return _context.Products.Skip((page - 1) * 10).Take(10).Include(x => x.ProductImages).Include(x => x.Brand);
        }

        public IActionResult Product(int? page)
        {
            var products = GetProducts(page != null ? page.Value : 1);

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
            return View("Product", new ProductAdminViewModel
            {
                Products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = 1
            });
        }

        public IActionResult AddProduct()
        {
            var pro = new Product();
            ViewData["Brands"] = _context.Brands.ToList();
            ViewData["Cpus"] = _context.LaptopCPUSeries.ToList();
            ViewData["Gpus"] = _context.LaptopGPUSeries.ToList();
            return View(pro);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model, int? brand, int? cpu, int? gpu, float? screensize, string? screenresolution, string? storagetype, int? storagesize, int? refreshrate, int? ram, IFormFile file)
        {
            var products = GetProducts(1);
            ModelState.Remove(nameof(Models.Product.Brand));
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Brand = _context.Brands.Where(x => x.ID == brand).FirstOrDefault(),
                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock,
                    Description = model.Description,
                    IsLaptop = model.IsLaptop,
                };
                if (file != null && file.Length > 0)
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
                    using (var image = Image.Load(file.OpenReadStream()))
                    {
                        image.Save(filePath, new JpegEncoder());
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
                if (model.IsLaptop)
                {
                    Laptop laptop = new Laptop
                    {
                        CPUSeries = _context.LaptopCPUSeries.Where(x => x.ID == cpu).FirstOrDefault(),
                        GPUSeries = _context.LaptopGPUSeries.Where(x => x.ID == gpu).FirstOrDefault(),
                        ScreenSize = float.Parse(Convert.ToString(screensize)),
                        ScreenAspectRatio = "16:9",
                        StorageType = (storagetype == "SSD") ? LaptopStorageType.SSD : LaptopStorageType.HDD,
                        StorageSize = Convert.ToInt32(storagesize),
                        RefreshRate = Convert.ToInt32(refreshrate),
                        RAM = Convert.ToInt32(ram),

                    };
                    product.Laptop = laptop;
                }
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            return View("Product", new ProductAdminViewModel
            {
                Products = products.ToList(),
                TotalCount = _context.Products.Count(),
                PageIndex = 1
            });
        }
        
        public IActionResult Order()
        {
            var order = _context.Orders.Include(o => o.Buyer).Include(o => o.OrderDetails).ThenInclude(oi => oi.Product).ToList();
            return View(order);
        }
    }
}
