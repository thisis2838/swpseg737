using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            });
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
            var brandSelectList = _context.Brands.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();
            ViewData["Brands"] = brandSelectList;
            /*ViewData["Brands"] = _context.Brands.ToList();*/
            var cpuSelectList = _context.LaptopCPUSeries.Select(cpu => new SelectListItem
            {
                Value = cpu.ID.ToString(),
                Text = cpu.Name
            }).ToList();
            ViewData["Cpus"] = cpuSelectList;

            var gpuSelectList = _context.LaptopGPUSeries.Select(gpu => new SelectListItem
            {
                Value = gpu.ID.ToString(),
                Text = gpu.Name
            }).ToList();
            ViewData["Gpus"] = gpuSelectList;
            return View(pro);
        }

        public IActionResult Update(int id)
        {
            var pro = _context.Products.Where(p => p.ID == id).Include(p => p.ProductImages).Include(p => p.Laptop).FirstOrDefault();
            var brandSelectList = _context.Brands.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();
            ViewData["Brands"] = brandSelectList;
            /*ViewData["Brands"] = _context.Brands.ToList();*/
            var cpuSelectList = _context.LaptopCPUSeries.Select(cpu => new SelectListItem
            {
                Value = cpu.ID.ToString(),
                Text = cpu.Name
            }).ToList();
            ViewData["Cpus"] = cpuSelectList;

            var gpuSelectList = _context.LaptopGPUSeries.Select(gpu => new SelectListItem
            {
                Value = gpu.ID.ToString(),
                Text = gpu.Name
            }).ToList();
            ViewData["Gpus"] = gpuSelectList;
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product, IFormFile image1, IFormFile image2, IFormFile image3)
        {
            ModelState.Remove(nameof(image1));
            ModelState.Remove(nameof(image2));
            ModelState.Remove(nameof(image3));

            if (product.IsLaptop)
            {
                _context.FillForeignKeys(product);
                _context.FillForeignKeys(product.Laptop);
            }
            else
            {
                ModelState.Remove("Laptop.ScreenResolution");
                ModelState.Remove("Laptop.CPUSeriesID");
                ModelState.Remove("Laptop.GPUSeriesID");
                ModelState.Remove("Laptop.ScreenSize");
                ModelState.Remove("Laptop.StorageType");
                ModelState.Remove("Laptop.StorageSize");
                ModelState.Remove("Laptop.RefreshRate");
                ModelState.Remove("Laptop.RAM");
            }

            if (ModelState.IsValid)
            {
                var existingProduct = await _context.Products
                    .Include(p => p.ProductImages)
                    .Include(p => p.Laptop)
                    .FirstOrDefaultAsync(p => p.ID == product.ID);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Update product properties
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.BrandId = product.BrandId;
                existingProduct.Description = product.Description;

                if (product.IsLaptop)
                {
                    if (existingProduct.Laptop == null)
                    {
                        existingProduct.Laptop = new Laptop();
                    }

                    existingProduct.Laptop.CPUSeriesID = product.Laptop.CPUSeriesID;
                    existingProduct.Laptop.GPUSeriesID = product.Laptop.GPUSeriesID;
                    existingProduct.Laptop.ScreenSize = product.Laptop.ScreenSize;
                    existingProduct.Laptop.ScreenResolution = "16:9";
                    existingProduct.Laptop.StorageType = product.Laptop.StorageType;
                    existingProduct.Laptop.StorageSize = product.Laptop.StorageSize;
                    existingProduct.Laptop.RefreshRate = product.Laptop.RefreshRate;
                    existingProduct.Laptop.RAM = product.Laptop.RAM;
                }
                else
                {
                    existingProduct.Laptop = null;
                }

                // Remove and add images based on provided files
                await RemoveAndAddImagesAsync(existingProduct, image1, image2, image3);

                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine("Invalid: " + error.ErrorMessage);
                    }
                }
                var brandSelectList = _context.Brands.Select(b => new SelectListItem
                {
                    Value = b.ID.ToString(),
                    Text = b.Name
                }).ToList();
                ViewData["Brands"] = brandSelectList;
                /*ViewData["Brands"] = _context.Brands.ToList();*/
                var cpuSelectList = _context.LaptopCPUSeries.Select(cpu => new SelectListItem
                {
                    Value = cpu.ID.ToString(),
                    Text = cpu.Name
                }).ToList();
                ViewData["Cpus"] = cpuSelectList;

                var gpuSelectList = _context.LaptopGPUSeries.Select(gpu => new SelectListItem
                {
                    Value = gpu.ID.ToString(),
                    Text = gpu.Name
                }).ToList();
                ViewData["Gpus"] = gpuSelectList;
                return View(product);
            }
        }

        private async Task RemoveAndAddImagesAsync(Product product, IFormFile image1, IFormFile image2, IFormFile image3)
        {
            // Fetch existing product images
            var existingImages = _context.ProductImages.Where(pi => pi.ProductId == product.ID).ToList();

            // Remove images not replaced by new ones
            if (image1 != null)
            {
                var existingImage1 = existingImages.FirstOrDefault(pi => pi.DisplayIndex == 0);
                if (existingImage1 != null)
                {
                    _context.ProductImages.Remove(existingImage1);
                    existingImages.Remove(existingImage1);

                }
                var image1Result = await SaveImageAsync(image1, 0);
                product.ProductImages.Add(image1Result);
            }

            if (image2 != null)
            {
                var existingImage2 = existingImages.FirstOrDefault(pi => pi.DisplayIndex == 1);
                if (existingImage2 != null)
                {
                    _context.ProductImages.Remove(existingImage2);
                    existingImages.Remove(existingImage2);

                }
                var image2Result = await SaveImageAsync(image2, 1);
                product.ProductImages.Add(image2Result);
            }

            if (image3 != null)
            {
                var existingImage3 = existingImages.FirstOrDefault(pi => pi.DisplayIndex == 2);
                if (existingImage3 != null)
                {
                    _context.ProductImages.Remove(existingImage3);
                    existingImages.Remove(existingImage3);

                }
                var image3Result = await SaveImageAsync(image3, 2);
                product.ProductImages.Add(image3Result);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDetailViewModel product, string productType, IFormFile image1, IFormFile image2, IFormFile image3)
        {
            ModelState.Remove(nameof(image1));
            ModelState.Remove(nameof(image2));
            ModelState.Remove(nameof(image3));
            if (productType == "0")
            {
                product.IsLaptop = true;
            }
            else if (productType == "1")
            {
                product.IsLaptop = false;
            }
            else
            {
                // Nếu productType không phải "0" hoặc "1", xử lý lỗi hoặc cảnh báo
                ModelState.AddModelError("productType", "Product type must be '0' (Laptop) or '1' (Accessories).");
                // Hoặc có thể thiết lập mặc định cho IsLaptop hoặc làm gì đó khác tùy vào logic ứng dụng của bạn
            }
            if (product.IsLaptop)
            {
                _context.FillForeignKeys((Product)product);
                _context.FillForeignKeys(product.Laptop);

            }
            else
            {
                ModelState.Remove("Laptop.ScreenResolution");
                ModelState.Remove("Laptop.CPUSeriesID");
                ModelState.Remove("Laptop.GPUSeriesID");
                ModelState.Remove("Laptop.ScreenSize");
                ModelState.Remove("Laptop.StorageType");
                ModelState.Remove("Laptop.StorageSize");
                ModelState.Remove("Laptop.RefreshRate");
                ModelState.Remove("Laptop.RAM");
            }
            var brandSelectList = _context.Brands.Select(b => new SelectListItem
            {
                Value = b.ID.ToString(),
                Text = b.Name
            }).ToList();
            ViewData["Brands"] = brandSelectList;
            /*ViewData["Brands"] = _context.Brands.ToList();*/
            var cpuSelectList = _context.LaptopCPUSeries.Select(cpu => new SelectListItem
            {
                Value = cpu.ID.ToString(),
                Text = cpu.Name
            }).ToList();
            ViewData["Cpus"] = cpuSelectList;

            var gpuSelectList = _context.LaptopGPUSeries.Select(gpu => new SelectListItem
            {
                Value = gpu.ID.ToString(),
                Text = gpu.Name
            }).ToList();
            ViewData["Gpus"] = gpuSelectList;
            if (!_context.Brands.Any(b => b.ID == product.BrandId))
            {
                ModelState.AddModelError("BrandId", "Invalid brand");
                return View(product);
            }
            if (ModelState.IsValid)
            {
                var productImages = new List<ProductImage>();
                

                if (image1 == null && image2 == null && image3 == null)
                {

                    ModelState.AddModelError("Images", "Must contain at least 1 picture");
                    return View(product);
                }

                // Handle image1
                var image1Result = await SaveImageAsync(image1, 0);
                if (image1Result != null)
                {
                    productImages.Add(image1Result);
                }

                // Handle image2
                var image2Result = await SaveImageAsync(image2, 1);
                if (image2Result != null)
                {
                    productImages.Add(image2Result);
                }

                // Handle image3
                var image3Result = await SaveImageAsync(image3, 2);
                if (image3Result != null)
                {
                    productImages.Add(image3Result);
                }

                product.ProductImages = productImages;

                if (product.IsLaptop)
                {
                    product.Laptop!.ScreenAspectRatio = "16:9";
                }

                product.Laptop = product.IsLaptop ? product.Laptop : null;

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Product added successfully.";

                return RedirectToAction(nameof(Create));
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine("Invalid: " + error.ErrorMessage);
                    }
                }
                
                return View(product); // Ensure you return the view with the product model if the model state is invalid
            }

        }


        private async Task<ProductImage?> SaveImageAsync(IFormFile image, int displayIndex)
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

                // Create and return a new ProductImage object
                return new ProductImage
                {
                    DisplayIndex = displayIndex,
                    Token = uniqueFileName
                };
            }

            return null;
        }


        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.Where(p => p.ID == id).FirstOrDefault()!;
            product.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
