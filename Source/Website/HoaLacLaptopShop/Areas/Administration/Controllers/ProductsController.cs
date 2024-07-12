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
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Services;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.VisualBasic;
using NuGet.Protocol;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Packaging;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin,Sales")]
    public class ProductsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context = null!;
        private readonly IWebHostEnvironment _environment;
        private readonly ILocalResourceService _local = null!;

        public ProductsController
        (
            HoaLacLaptopShopContext context, 
            IWebHostEnvironment environment,
            ILocalResourceService local
        )
        {
            _context = context;
            _environment = environment;
            _local = local;
        }

        private IQueryable<Product> GetProducts(int page, bool includeDisabled = false)
        {
            return _context.Products
                .OrderByDescending(x => x.ID)
                .Where(x => !x.IsDisabled || includeDisabled)
                .Include(x => x.ProductImages).Include(x => x.Brand)
                .Skip((page - 1) * 10).Take(10);
        }
        private async Task InitializeSelections()
        {
            ViewData["Selections"] = new ProductUpdateSelections()
            {
                Brands = (await _context.Brands.ToListAsync())
                    .Select(b => new SelectListItem(b.Name, b.ID.ToString()))
                    .ToList(),
                GPUs = (await _context.LaptopGPUSeries.ToListAsync())
                    .Select(b => new SelectListItem(b.Name, b.ID.ToString()))
                    .ToList(),
                CPUs = (await _context.LaptopCPUSeries.ToListAsync())
                    .Select(b => new SelectListItem(b.Name, b.ID.ToString()))
                    .ToList(),
                ScreenResolutions = (await _context.Laptops.Select(x => x.ScreenResolution).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x, x))
                    .ToList(),
                ScreenSizes = (await _context.Laptops.Select(x => x.ScreenSize).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x.ToString(), x.ToString()))
                    .ToList(),
                ScreenAspectRatios = (await _context.Laptops.Select(x => x.ScreenAspectRatio).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x, x))
                    .ToList(),
                ScreenRefreshRates = (await _context.Laptops.Select(x => x.RefreshRate).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x.ToString(), x.ToString()))
                    .ToList(),
                StorageSizes =(await _context.Laptops.Select(x => x.StorageSize).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x.ToString(), x.ToString()))
                    .ToList(),
                RAMSizes =(await _context.Laptops.Select(x => x.RAM).Distinct().ToListAsync())
                    .Select(x => new SelectListItem(x.ToString(), x.ToString()))
                    .ToList(),
            };
        }

        public IActionResult Index(ProductIndexArgs? args)
        {
            args ??= new ProductIndexArgs();
            var products = GetProducts(args.TargetPage, args.ShowDisabled);
            return View(new ProductIndexViewModel
            {
                Products = products.ToList(),
                TotalCount = _context.Products.Count(),
                ShowDisabled = args.ShowDisabled,
                TargetPage = args.TargetPage,
            });
        }

        public async Task<IActionResult> Create()
        {
            var pro = new ProductUpdateViewModel();
            await InitializeSelections();
            return View(pro);
        }
        [HttpPost]
        [ModelStateExclude
        (
            nameof(Product.RowVersion),
            nameof(Product.Brand),
            $"{nameof(Product.Laptop)}.{nameof(Laptop.CPUSeries)}",
            $"{nameof(Product.Laptop)}.{nameof(Laptop.GPUSeries)}",
            $"{nameof(Product.ReviewCount)}.{nameof(Product.ReviewTotal)}",
            nameof(image1), nameof(image2), nameof(image3)
        )]
        public async Task<IActionResult> Create
        (
            ProductUpdateViewModel product,
            IFormFile image1, IFormFile image2, IFormFile image3
        )
        {
            if (product.IsLaptop)
            {
                _context.FillForeignKeys((Product)product);
                _context.FillForeignKeys(product.Laptop);
            }
            else
            {
                RemoveLaptopModelState();
            }

            await InitializeSelections();
            
            if (ModelState.IsValid)
            {
                if (!_context.Brands.Any(b => b.ID == product.BrandId))
                {
                    ModelState.AddModelError(nameof(Product.BrandId), "Invalid brand");
                    return View(product);
                }

                product.ProductImages = new List<ProductImage>();
                if (image1 == null && image2 == null && image3 == null)
                {
                    ModelState.AddModelError(nameof(Product.ProductImages), "At least one image must be specified.");
                    return View(product);
                }
                if (!await SaveImagesAsync(product, [image1, image2, image3]))
                {
                    return View(product);
                }

                product.Laptop = product.IsLaptop ? product.Laptop : null;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                this.AddMessage("Product added successfully.");
                return RedirectToAction(nameof(Create));
            }
            else
            {
                await InitializeSelections();
                return View(product);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pro = _context.Products.Include(p => p.ProductImages).Include(p => p.Laptop)
                .Where(p => p.ID == id)
                .FirstOrDefault();
            if (pro is null)
            {
                this.AddError("No such product exists.");
                return NotFound();
            }

            await InitializeSelections();
            return View(pro);
        }
        [HttpPost]
        [ModelStateExclude
        (
            nameof(Product.RowVersion),
            nameof(Product.Brand),
            $"{nameof(Product.Laptop)}.{nameof(Laptop.CPUSeries)}",
            $"{nameof(Product.Laptop)}.{nameof(Laptop.GPUSeries)}",
            $"{nameof(Product.ReviewCount)}.{nameof(Product.ReviewTotal)}",
            nameof(image1), nameof(image2), nameof(image3)
        )]
        public async Task<IActionResult> Edit(Product product, IFormFile? image1, IFormFile? image2, IFormFile? image3)
        {
            var existingProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Laptop)
                .FirstOrDefaultAsync(p => p.ID == product.ID);
            if (existingProduct == null)
            {
                return NotFound();
            }
            product.ProductImages = existingProduct.ProductImages;

            if (product.IsLaptop)
            {
                _context.FillForeignKeys(product);
                _context.FillForeignKeys(product.Laptop);
            }
            else
            {
                RemoveLaptopModelState();
            }
            if (ModelState.IsValid)
            {
                // Update product properties
                existingProduct.FillFromOther(product, 
                [
                    nameof(Product.Name), 
                    nameof(Product.Price),
                    nameof(Product.Stock),
                    nameof(Product.BrandId),
                    nameof(Product.Description),
                ]);

                if (product.IsLaptop && !existingProduct.IsLaptop)
                {
                    this.AddWarning("Ignored laptop-specific options as product is not a laptop.");
                }
                else if (existingProduct.IsLaptop)
                {
                    Trace.Assert(existingProduct.Laptop != null && product.Laptop != null);
                    existingProduct.Laptop.FillFromOther(product.Laptop, exclude:
                    [
                        nameof(Laptop.Product),
                        nameof(Laptop.ProductID)
                    ]);
                }
                else
                {
                    Trace.Assert(existingProduct.Laptop is null);
                }

                if (!await SaveImagesAsync(existingProduct, [image1, image2, image3]))
                {
                    return View(product);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await InitializeSelections();
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Where(p => p.ID == id).FirstOrDefault()!;
            product.IsDisabled = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SaveImagesAsync(Product p, IList<IFormFile?> images)
        {
            var tokens = new List<string?>();
            string getPath(string token) => _local.GetRelativePath(ResourceType.Images, "products", token + ".jpeg");

            foreach (var image in images)
            {
                if (image is null)
                {
                    tokens.Add(null);
                    continue;
                }

                string token = ResourceHelper.GenerateResourceToken();
                try
                {
                    using (var localImage = Image.Load(image.OpenReadStream()))
                    using (var file = _local.FileOpen(getPath(token)))
                    {
                        await localImage.SaveAsync(file, new JpegEncoder());
                        tokens.Add(token);
                    }
                }
                catch (Exception ex)
                {
                    foreach (var savedToken in tokens)
                    {
                        if (savedToken != null) 
                            _local.FileRemove(getPath(savedToken));
                    }
                    if (ex is InvalidImageContentException || ex is UnknownImageFormatException)
                    {
                        ModelState.AddModelError(nameof(Product.ProductImages), "One or more images was in an invalid or unparsable format.");
                        return false;
                    }
                    throw;
                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {  
                if (tokens[i] != null)
                {
                    if (i < p.ProductImages.Count)
                    {
                        _local.FileRemove(getPath(p.ProductImages.ElementAt(i).Token));
                        p.ProductImages.ElementAt(i).Token = tokens[i]!;
                    }
                    else
                    {
                        p.ProductImages.Add(new ProductImage()
                        {
                            DisplayIndex = p.ProductImages.Max(x => x.DisplayIndex) + 1,
                            Token = tokens[i]!,
                        });
                    }
                }
            }
            return true;
        }
        private void RemoveLaptopModelState()
        {
            var removed = ModelState.Where(x => x.Key.StartsWith("Laptop.")).Select(x => x.Key);
            foreach (var item in removed) ModelState.Remove(item);
        }
    }

    public class ProductUpdateSelections
    {
        public required ICollection<SelectListItem> Brands = null!;
        public required ICollection<SelectListItem> CPUs = null!;
        public required ICollection<SelectListItem> GPUs = null!;
        public required ICollection<SelectListItem> ScreenSizes = null!;
        public required ICollection<SelectListItem> ScreenResolutions = null!;
        public required ICollection<SelectListItem> ScreenAspectRatios = null!;
        public required ICollection<SelectListItem> ScreenRefreshRates = null!;
        public required ICollection<SelectListItem> StorageSizes = null!;
        public required ICollection<SelectListItem> RAMSizes = null!;
    }
}
