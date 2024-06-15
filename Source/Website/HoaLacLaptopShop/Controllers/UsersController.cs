using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using HoaLacLaptopShop.Helpers;

namespace HoaLacLaptopShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public UsersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password,PhoneNumber,IsAdmin,IsMarketing,IsSales")] RegisterViewModel model, string gender)
        {
            ModelState.Remove(nameof(RegisterViewModel.PassHash));
            if (ModelState.IsValid)
            {
                var user = model as User;
                var hasher = new PasswordHasher<User>();
                user.PassHash = hasher.HashPassword(user, model.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,NewPassword,PhoneNumber,IsAdmin,IsMarketing,IsSales")] UserEditViewModel model, string gender)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var hasher = new PasswordHasher<User>();
                    model.PassHash = string.IsNullOrEmpty(model.NewPassword)
                        ? model.PassHash
                        : hasher.HashPassword(model, model.NewPassword);

                    _context.Update(model as User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(model.ID))
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
            return View(model);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        // Get: Users/OrderHistory
        public IActionResult OrderHistory()
        {
            String userId = HttpContext.GetCurrentUser().ID.ToString();
            if (userId != null)
            {
                var order = _context.Orders
                        .Include(o => o.OrderDetails)
                            .ThenInclude(oi => oi.Product)
                        .Include(o => o.Buyer)
                        .Where(o => o.BuyerID.ToString() == userId).ToList();
                return View(order);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
            }
        }

        public IActionResult OrderHistory(int id)
        {
            String userId = HttpContext.GetCurrentUser().ID.ToString();

            if (userId != null)
            {
                var order = _context.Orders
                        .Include(o => o.OrderDetails)
                            .ThenInclude(oi => oi.Product)
                        .Include(o => o.Voucher)
                        .FirstOrDefault(o => o.BuyerID.ToString() == userId && o.ID == id);
                if (order == null) return RedirectToAction("Index", "Error", new { type = KnownErrorType.NotFound });
                return View(order);
            }
            else
            {
                return RedirectToAction("Index", "Error", new { type = KnownErrorType.Forbidden });
            }
        }
        // Get: Users/OrderHistory
      
        
    }
}
