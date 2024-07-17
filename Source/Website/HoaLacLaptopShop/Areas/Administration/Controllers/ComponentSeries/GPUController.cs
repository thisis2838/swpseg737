using HoaLacLaptopShop.Areas.Administration.ViewModels.ComponentSeries;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HoaLacLaptopShop.Areas.Administration.Controllers.ComponentSeries
{
    [Area("Administration")]
    [Authorize(Roles = "Sales")]
    [Route("Admin/ComponentSeries/[controller]/{action=Index}/{id?}")]
    public class GPUController : ComponentSeriesController
    {
        public GPUController(HoaLacLaptopShopContext context) : base(context) { }

        public async Task<IActionResult> Index(GPUIndexArgs args)
        {
            var gpus = Context.LaptopGPUSeries.Include(c => c.Manufacturer).AsQueryable();
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.Search))
                {
                    gpus = gpus.Where(x => x.Name.Contains(args.Search) || x.Manufacturer.Name.Contains(args.Search));
                }
            }
            return View(new GPUIndexViewModel()
            {
                Search = args.Search,
                GPUSeries = await gpus.ToListAsync()
            });
        }

        public async Task<IActionResult> Add()
        {
            await InitializeBrandSelection();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateExclude(nameof(LaptopGPUSeries.Manufacturer))]
        public async Task<IActionResult> Add(LaptopGPUSeries gpuSeries)
        {
            if (ModelState.IsValid)
            {
                Context.Add(gpuSeries);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await InitializeBrandSelection();
            return View(gpuSeries);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("No GPU Series ID provided for Edit");
            }

            var gpuSeries = await Context.LaptopGPUSeries.FindAsync(id);
            if (gpuSeries == null)
            {
                return NotFound("No GPU Series with such an ID exists.");
            }

            await InitializeBrandSelection();
            return View(gpuSeries);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateExclude(nameof(LaptopGPUSeries.Manufacturer))]
        public async Task<IActionResult> Edit(LaptopGPUSeries updateGPU)
        {
            if (ModelState.IsValid)
            {
                Context.Update(updateGPU);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await InitializeBrandSelection();
            return View(updateGPU);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var gpuSeries = await Context.LaptopGPUSeries
                .Include(cs => cs.Laptops)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gpuSeries == null)
            {
                return NotFound("No GPU Series with such an ID exists.");
            }

            if (gpuSeries.Laptops.Any())
            {
                this.AddError("Cannot delete this GPU series as it is associated with one or more laptops.");
                return RedirectToAction(nameof(Edit), new { id });
            }

            Context.LaptopGPUSeries.Remove(gpuSeries);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
