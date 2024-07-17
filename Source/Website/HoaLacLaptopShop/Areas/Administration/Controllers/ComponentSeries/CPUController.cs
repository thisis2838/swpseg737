﻿using HoaLacLaptopShop.Areas.Administration.ViewModels.ComponentSeries;
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
    public class CPUController : ComponentSeriesController
    {
        public CPUController(HoaLacLaptopShopContext context) : base(context) { }

        public async Task<IActionResult> Index(CPUIndexArgs args)
        {
            var cpus = Context.LaptopCPUSeries.Include(c => c.Manufacturer).AsQueryable();
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.Search))
                {
                    cpus = cpus.Where(x => x.Name.Contains(args.Search) || x.Manufacturer.Name.Contains(args.Search));
                }
            }
            return View(new CPUIndexViewModel()
            {
                Search = args.Search,
                CPUSeries = await cpus.ToListAsync()
            });
        }

        public async Task<IActionResult> Add()
        {
            await InitializeBrandSelection();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateExclude(nameof(LaptopCPUSeries.Manufacturer))]
        public async Task<IActionResult> Add(LaptopCPUSeries cpuSeries)
        {
            if (ModelState.IsValid)
            {
                Context.Add(cpuSeries);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await InitializeBrandSelection();
            return View(cpuSeries);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("No CPU Series ID provided for Edit");
            }

            var cpuSeries = await Context.LaptopCPUSeries.FindAsync(id);
            if (cpuSeries == null)
            {
                return NotFound("No CPU Series with such an ID exists.");
            }

            await InitializeBrandSelection();
            return View(cpuSeries);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateExclude(nameof(LaptopCPUSeries.Manufacturer))]
        public async Task<IActionResult> Edit(LaptopCPUSeries updateCPU)
        {
            if (ModelState.IsValid)
            {
                Context.Update(updateCPU);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await InitializeBrandSelection();
            return View(updateCPU);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var cpuSeries = await Context.LaptopCPUSeries
                .Include(cs => cs.Laptops)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cpuSeries == null)
            {
                return NotFound("No CPU Series with such an ID exists.");
            }

            if (cpuSeries.Laptops.Any())
            {
                this.AddError("Cannot delete this CPU series as it is associated with one or more laptops.");
                return RedirectToAction(nameof(Edit), new { id });
            }

            Context.LaptopCPUSeries.Remove(cpuSeries);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
