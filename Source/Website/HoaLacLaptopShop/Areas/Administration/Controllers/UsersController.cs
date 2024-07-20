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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Areas.Administration.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using HoaLacLaptopShop.Filters;
using NuGet.Protocol;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public UsersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,Sales")]
        public ActionResult Index(int? page, string? searchTerm)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = 
                    users.Where
                    (u => 
                        u.Name.Contains(searchTerm) 
                        || u.Email.Contains(searchTerm) 
                        || u.PhoneNumber.Contains(searchTerm)
                    );
            }
            var curPage = users.Skip(((page ?? 1) - 1) * 12).Take(12);
            return View(new UserIndexViewModel
            {
                Users = curPage.ToList(),
                TotalCount = users.Count(),
                PageIndex = page != null ? Convert.ToInt32(page) : 1,
                SearchTerm = searchTerm!
            });
        }

        [Authorize(Roles = "Admin,Sales")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                this.AddError("User could not be found");
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                this.AddError("User could not be found");
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [ModelStateExclude(nameof(RegisterViewModel.PassHash))]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                this.AddError("User could not be found");
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                this.AddError("User could not be found");
                return NotFound();
            }
            var model = new UserEditViewModel();
            model.FillFromOther(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [ModelStateExclude(nameof(UserEditViewModel.PassHash))]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            var existing = await _context.Users.FindAsync(model.ID);
            if (existing is null)
            {
                this.AddError("No user with such an ID exists!");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.NewPassword != null)
                    {
                        var hasher = new PasswordHasher<User>();
                        model.PassHash = hasher.HashPassword(model, model.NewPassword);
                    }
                    else
                    {
                        model.PassHash = existing.PassHash;
                    }
                    existing.FillFromOther(model);
                    _context.Update(existing);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Disable(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDisabled = true;
            }
            else
            {
                this.AddError("User could not be found");
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reenable(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDisabled = false;
            }
            else
            {
                this.AddError("User could not be found");
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }

        [Authorize(Roles = "Admin,Sales")]
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
                this.AddError("User could not be found");
                return NotFound();
            }
        }
    }
}
