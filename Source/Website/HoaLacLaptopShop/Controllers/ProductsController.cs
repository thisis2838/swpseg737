using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace HoaLacLaptopShop.Controllers
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
            products = products.Where(x => (x.IsLaptop && args.ShowLaptops) || (!x.IsLaptop && args.ShowAccessories));
            if (args.Search != null) products = products.Where(x => x.Name.ToString().Contains(args.Search.ToString()));
            if (args.MinPrice.HasValue) products = products.Where(x => x.Price >= args.MinPrice);
            if (args.MaxPrice.HasValue) products = products.Where(x => x.Price <= args.MaxPrice);

            var list = products.ToList();
            var cpus = new List<LaptopCPUSeries>();
            var gpus = new List<LaptopGPUSeries>();
            if (args.ShowLaptops)
            {
                cpus = _context.LaptopCPUSeries.ToList();
                gpus = _context.LaptopGPUSeries.ToList();
                products = products.Where(x => x.IsLaptop).Include(x => x.Laptop).ThenInclude(x => x.CPUSeries);
                if (args.SelectedCpuIDs != null)
                {
                    args.SelectedCpuIDs = args.SelectedCpuIDs.Where(x => cpus.Select(y => y.ID).Contains(x)).ToList();
                    list = list.Where(x => args.SelectedCpuIDs.Contains(Convert.ToInt32(x.Laptop!.CPUSeriesID))).ToList();
                }
                if (args.SelectedCpuIDs is null || args.SelectedCpuIDs.Count == 0)
                    args.SelectedCpuIDs = _context.LaptopCPUSeries.Select(x => x.ID).ToList();

                if (args.SelectedGpuIDs != null)
                {
                    args.SelectedGpuIDs = args.SelectedGpuIDs.Where(x => gpus.Select(y => y.ID).Contains(x)).ToList();
                    list = list.Where(x => args.SelectedGpuIDs.Contains(Convert.ToInt32(x.Laptop!.GPUSeriesID))).ToList();
                }
                if (args.SelectedGpuIDs is null || args.SelectedGpuIDs.Count == 0)
                    args.SelectedGpuIDs = _context.LaptopGPUSeries.Select(x => x.ID).ToList();
            }
            var brands = list.GroupBy(x => x.Brand!).Select(x => new BrandEntry(x.Key, x.Count())).ToList();
            

            if (args.SelectedBrandIDs != null)
                args.SelectedBrandIDs = args.SelectedBrandIDs.Where(x => brands.Select(y => y.Brand.ID).Contains(x)).ToList();
            if (args.SelectedBrandIDs is null || args.SelectedBrandIDs.Count == 0)
                args.SelectedBrandIDs = brands.Select(x => x.Brand.ID).ToList();
            list = list.Where(x => args.SelectedBrandIDs.Contains(x.Brand!.ID)).ToList();

            return View(new ProductIndexViewModel(args)
            {
                Products = list,
                MinPossiblePrice = min,
                MaxPossiblePrice = max,
                Brands = brands,
                Cpus = cpus,
                Gpus = gpus,
            });
        }

        public IActionResult Detail(int id)
        {
            var product = GetProducts()
                .Include(x => x.ProductReviews.OrderByDescending(r => r.Time)).ThenInclude(x => x.Reviewer)
                .Include(x => x.Laptop).ThenInclude(x => x.CPUSeries)
                .Include(x => x.Laptop).ThenInclude(x => x.GPUSeries)
                .Include(x => x.OrderDetails).ThenInclude(x => x.Order)
                .Where(p => p.ID == id)
                .FirstOrDefault();
            return View(product);
        }
    }
}
