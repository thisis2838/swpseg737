using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Controllers
{
    public class BrandController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public BrandController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        //GET: Brand/Index
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
            var brands = from b in _context.Brands select b;
            return View(await brands.ToListAsync());
        }
        //GET: Brand/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST: Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Country")]Brand brand)
        {
            if(ModelState.IsValid) 
            {
                bool codeExists = await _context.Brands.AnyAsync(b => b.Name == brand.Name && b.ID != brand.ID);
                if (codeExists)
                {
                    ModelState.AddModelError("Name", "Brand already exists.");
                    return View(brand);
                }
                try
                {
                    _context.Add(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.ID))
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
        //GET: Voucher/Update
        public async Task<IActionResult> Update(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var brand = await _context.Brands.FindAsync(id);
            if(brand == null)
            {
                return NotFound();
            }
            return View(brand); 
        }
        //POST: Voucher/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ID,Name,Description,Country")] Brand updateBrand)
        {
            if (ModelState.IsValid)
            {
                try {
                    _context.Update(updateBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(updateBrand.ID))
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
            return View(updateBrand);
        }
        //GET: Brand/Delete
         public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET: Brand/Search
        public async Task<IActionResult> Search(string query, string sortOrder)
        {

            var brand = from b in _context.Brands
                           select b;

            if (!String.IsNullOrEmpty(query))
            {
                brand = brand.Where(s => s.Name.Contains(query));
            }



            return View("Index", await brand.ToListAsync());
        }
        public bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.ID == id);
        }
    }
}
