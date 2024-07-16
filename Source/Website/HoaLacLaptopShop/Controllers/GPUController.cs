using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class GPUController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public GPUController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        //GET: GPUSeries/Index
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("CurrentUserId");

            if (userId == null)
            {
                return RedirectToAction("Error403", "Error");
            }

            var user = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
            if (user == null)
            {
                return RedirectToAction("Error403", "Error");
            }

            var currentUser = _context.Users.SingleOrDefault(u => u.ID.ToString() == userId);
            if (currentUser != null && currentUser.IsSales == false)
            {
                return RedirectToAction("Error403", "Error");
            }
            var cpuseries = from c in _context.LaptopCPUSeries select c;
            return View(await cpuseries.ToListAsync());
        }
        //GET: CPUCreate
        public IActionResult Create()
        {
            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,ManufacturerID")] LaptopGPUSeries gpuSeries)
        {
            if (ModelState.IsValid)
            {
                bool codeExists = await _context.LaptopCPUSeries.AnyAsync(c => c.Name == gpuSeries.Name && c.ID != gpuSeries.ID);
                if (codeExists)
                {
                    ModelState.AddModelError("Name", "CPU already exists.");
                    ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", gpuSeries.ManufacturerID);
                    return View(gpuSeries);
                }
                try
                {
                    _context.Add(gpuSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpuExists(gpuSeries.ID))
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
            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", gpuSeries.ManufacturerID);
            return View(gpuSeries);
        }
        //GET: GPUSeries/Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpuSeries = await _context.LaptopGPUSeries.FindAsync(id);
            if (gpuSeries == null)
            {
                return NotFound();
            }

            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", gpuSeries.ManufacturerID);
            return View(gpuSeries);
        }

        //POST: GPUSeriesUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ID,Name,Description,ManufacturerID")] LaptopCPUSeries updateGPU)
        {
            if (id != updateGPU.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateGPU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpuExists(updateGPU.ID))
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

            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", updateGPU.ManufacturerID);
            return View(updateGPU);
        }
        // GET: GPUSeries/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var gpuSeries = await _context.LaptopGPUSeries
                .Include(cs => cs.Laptops)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gpuSeries == null)
            {
                return NotFound();
            }

            if (gpuSeries.Laptops.Any())
            {

                ModelState.AddModelError("", "Cannot delete this GPU series as it is associated with one or more laptops.");
                return View(gpuSeries);
            }

            return View(gpuSeries);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gpuSeries = await _context.LaptopGPUSeries
                .Include(cs => cs.Laptops)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gpuSeries == null)
            {
                return NotFound();
            }

            if (gpuSeries.Laptops.Any())
            {

                ModelState.AddModelError("", "Cannot delete this CPU series as it is associated with one or more laptops.");
                return View(gpuSeries);
            }

            _context.LaptopGPUSeries.Remove(gpuSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET: GPUSeriews/Search
        public async Task<IActionResult> Search(string query)
        {

            var gpuSeries = from g in _context.LaptopGPUSeries
                            select g;

            if (!String.IsNullOrEmpty(query))
            {
                gpuSeries = gpuSeries.Where(s => s.Name.Contains(query));
            }



            return View("Index", await gpuSeries.ToListAsync());
        }
        public bool CpuExists(int id)
        {
            return _context.LaptopGPUSeries.Any(e => e.ID == id);
        }
    }
}
