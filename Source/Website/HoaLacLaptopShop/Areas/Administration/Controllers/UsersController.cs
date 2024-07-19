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

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin,Sales,Marketing")]
    public class UsersController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public UsersController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }
        public ActionResult Index(string? searchTerm, int targetPage = 1)
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
            var curPage = users.Skip((targetPage - 1) * 12).Take(12);
            return View(new UserIndexViewModel
            {
                Users = curPage.ToList(),
                TotalCount = users.Count(),
                TargetPage = targetPage,
                SearchTerm = searchTerm!
            });
        }

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
                user.Gender = gender.Equals("Male");
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
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
                nameof(UserEditViewModel.PassHash),
                nameof(UserEditViewModel.Gender),
                nameof(UserEditViewModel.PhoneNumber),
                nameof(UserEditViewModel.IsAdmin),
                nameof(UserEditViewModel.IsMarketing),
                nameof(UserEditViewModel.IsSales)
            };
            if (fields.All(x => !ModelState.TryGetValue(x, out var valid) || valid.ValidationState == ModelValidationState.Valid))
            {
                try
                {
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
