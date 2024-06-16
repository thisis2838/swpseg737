using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Areas.Public.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HoaLacLaptopShop.Areas.Shared.ViewModels;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public UsersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model, string gender)
        {
            var fields = new string[]
            {
                nameof(RegisterViewModel.ID),
                nameof(RegisterViewModel.Name),
                nameof(RegisterViewModel.Email),
                nameof(RegisterViewModel.Password),
                nameof(RegisterViewModel.PhoneNumber),
                nameof(RegisterViewModel.IsAdmin),
                nameof(RegisterViewModel.IsMarketing),
                nameof(RegisterViewModel.IsSales)
            };
            if (fields.All(x => !ModelState.TryGetValue(x, out var valid) || valid.ValidationState == ModelValidationState.Valid))
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserEditViewModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            var fields = new string[]
            {
                nameof(UserEditViewModel.ID),
                nameof(UserEditViewModel.Name),
                nameof(UserEditViewModel.Email),
                nameof(UserEditViewModel.NewPassword),
                nameof(UserEditViewModel.PhoneNumber),
                nameof(UserEditViewModel.IsAdmin),
                nameof(UserEditViewModel.IsMarketing),
                nameof(UserEditViewModel.IsSales)
            };
            if (fields.All(x => !ModelState.TryGetValue(x, out var valid) || valid.ValidationState == ModelValidationState.Valid))
            {
                try
                {
                    var hasher = new PasswordHasher<User>();
                    model.PassHash = string.IsNullOrEmpty(model.NewPassword) ? model.PassHash : hasher.HashPassword(model, model.NewPassword);
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            else
            {
                this.SetError("User could not be found");
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        public async Task<IActionResult> OrderHistory(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                var order = await _context.Orders
                    .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                    .Include(o => o.Voucher)
                    .Where(o => o.BuyerID == id)
                    .ToListAsync();
                return View(order);
            }
            else
            {
                this.SetError("User could not be found");
                return NotFound();
            }
        }
    }
}
