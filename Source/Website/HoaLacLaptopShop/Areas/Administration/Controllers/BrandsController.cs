using HoaLacLaptopShop.Areas.Administration.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class BrandsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public BrandsController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Sales,Marketing")]
        public async Task<IActionResult> Index(BrandIndexArgs args)
        {
            var brands = _context.Brands.AsQueryable();
            if (!string.IsNullOrWhiteSpace(args.Search))
            {
                brands = brands.Where
                (
                    b => b.Name.Contains(args.Search) || b.Description.Contains(args.Search)
                );
            }
            return View(new BrandIndexViewModel()
            {
                Search = args.Search,
                Brands = await brands.ToListAsync()
            });
        }

        [Authorize(Roles = "Sales")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateExclude(nameof(Brand.ID))]
        public async Task<IActionResult> Add(Brand brand)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Brands.AnyAsync(x => x.Name == brand.Name))
                {
                    ModelState.AddModelError("Name", "A brand with that name already exists");
                    return View(brand);
                }

                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        [HttpPost]
        [Authorize(Roles = "Sales")]
        [ValidateAntiForgeryToken]
        [ModelStateInclude
        (
            nameof(Brand.ID), 
            nameof(Brand.Name), 
            nameof(Brand.Description), 
            nameof(Brand.Country)
        )]
        public async Task<IActionResult> Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Brands.AnyAsync(x => x.ID == brand.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand is null)
            {
                this.AddError("The brand to be deleted was not found.");
                return BadRequest();
            }

            var brandisUsed =
                (await _context.Products.AnyAsync(x => x.BrandId == brand.ID))
                || (await _context.LaptopCPUSeries.AnyAsync(x => x.ManufacturerID == brand.ID))
                || (await _context.LaptopGPUSeries.AnyAsync(x => x.ManufacturerID == brand.ID));
            if (brandisUsed)
            {
                this.AddError("This brand cannot be removed as there are products assigned to it.");
                return RedirectToAction(nameof(Edit), new { id });
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
