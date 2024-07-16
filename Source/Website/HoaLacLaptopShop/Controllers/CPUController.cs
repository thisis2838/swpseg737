using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class CPUController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public CPUController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        //GET: CPU/Index
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

            var cpuseries = _context.LaptopCPUSeries.Include(c => c.Manufacturer);
            return View(await cpuseries.ToListAsync());
        }

        //GET: CPUCreate
        public IActionResult Create()
        {
            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name");
            return View();
        }
        //POST: CPUCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,ManufacturerID")] LaptopCPUSeries cpuSeries)
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
            if (ModelState.IsValid)
            {
                bool codeExists = await _context.LaptopCPUSeries.AnyAsync(c => c.Name == cpuSeries.Name && c.ID != cpuSeries.ID);
                if (codeExists)
                {
                    ModelState.AddModelError("Name", "CPU already exists.");
                    ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", cpuSeries.ManufacturerID);
                    return View(cpuSeries);
                }
                try
                {
                    _context.Add(cpuSeries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpuExists(cpuSeries.ID))
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
            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", cpuSeries.ManufacturerID);
            return View(cpuSeries);
        }
        //GET: CPUUpdate
        public async Task<IActionResult> Update(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var cpuSeries = await _context.LaptopCPUSeries.FindAsync(id);
            if (cpuSeries == null)
            {
                return NotFound();
            }

            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", cpuSeries.ManufacturerID);
            return View(cpuSeries);
        }
        //POST: CPUUpdate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ID,Name,Description,ManufacturerID")] LaptopCPUSeries updateCPU)
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
            if (id != updateCPU.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateCPU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CpuExists(updateCPU.ID))
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

            ViewBag.Manufacturers = new SelectList(_context.Brands, "ID", "Name", updateCPU.ManufacturerID);
            return View(updateCPU);
        }
        // GET: CPU/Delete
        public async Task<IActionResult> Delete(int id)
        {

            var cpuSeries = await _context.LaptopCPUSeries
                .Include(cs => cs.Laptops) 
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cpuSeries == null)
            {
                return NotFound();
            }

            if (cpuSeries.Laptops.Any())
            {
                
                ModelState.AddModelError("Name", "Cannot delete this CPU series as it is associated with one or more laptops.");
                return View(cpuSeries); 
            }

            return View(cpuSeries);
        }
        // POST: CPU/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
            var cpuSeries = await _context.LaptopCPUSeries
                .Include(cs => cs.Laptops)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cpuSeries == null)
            {
                return NotFound();
            }

            if (cpuSeries.Laptops.Any())
            {
                ModelState.AddModelError("", "Cannot delete this CPU series as it is associated with one or more laptops.");
                // Return the view with the model to display the error message
                return View("Delete", cpuSeries);
            }

            _context.LaptopCPUSeries.Remove(cpuSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET: CPU/Search
        public async Task<IActionResult> Search(string query)
        {
            var cpuSeries = _context.LaptopCPUSeries.Include(c => c.Manufacturer).AsQueryable();

            if (!String.IsNullOrEmpty(query))
            {
                cpuSeries = cpuSeries.Where(s => s.Name.Contains(query));
            }

            return View("Index", await cpuSeries.ToListAsync());
        }
        public bool CpuExists(int id)
        {
            return _context.LaptopCPUSeries.Any(e => e.ID == id);
        }
    }
}
