using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Data;

namespace HoaLacLaptopShop.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public LaptopsController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var hoaLacLaptopShopContext = _context.Laptops.Include(l => l.CpuSeriesNavigation).Include(l => l.GpuSeriesNavigation).Include(l => l.Product);
            return View(await hoaLacLaptopShopContext.ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.CpuSeriesNavigation)
                .Include(l => l.GpuSeriesNavigation)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            ViewData["CpuSeries"] = new SelectList(_context.LaptopCpuseries, "Id", "Id");
            ViewData["GpuSeries"] = new SelectList(_context.LaptopGpuseries, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CpuSeries,GpuSeries,ScreenSize,ScreenResolution,ScreenAspectRatio,StorageType,StorageSize,RefreshRate,Ram")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CpuSeries"] = new SelectList(_context.LaptopCpuseries, "Id", "Id", laptop.CpuSeries);
            ViewData["GpuSeries"] = new SelectList(_context.LaptopGpuseries, "Id", "Id", laptop.GpuSeries);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", laptop.ProductId);
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewData["CpuSeries"] = new SelectList(_context.LaptopCpuseries, "Id", "Id", laptop.CpuSeries);
            ViewData["GpuSeries"] = new SelectList(_context.LaptopGpuseries, "Id", "Id", laptop.GpuSeries);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", laptop.ProductId);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CpuSeries,GpuSeries,ScreenSize,ScreenResolution,ScreenAspectRatio,StorageType,StorageSize,RefreshRate,Ram")] Laptop laptop)
        {
            if (id != laptop.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.ProductId))
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
            ViewData["CpuSeries"] = new SelectList(_context.LaptopCpuseries, "Id", "Id", laptop.CpuSeries);
            ViewData["GpuSeries"] = new SelectList(_context.LaptopGpuseries, "Id", "Id", laptop.GpuSeries);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", laptop.ProductId);
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.CpuSeriesNavigation)
                .Include(l => l.GpuSeriesNavigation)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
            return _context.Laptops.Any(e => e.ProductId == id);
        }
    }
}
