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
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult> Index(UserIndexViewArgs args)
        {
            var users = _context.Users.OrderByDescending(x => x.ID).AsQueryable();

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(args.Search))
                {
                    users =
                        users.Where(
                            u => u.Name.Contains(args.Search.ToLower())
                                || u.Email.Contains(args.Search.ToLower())
                                || u.PhoneNumber.Contains(args.Search.ToLower())
                        );
                }
            }

            const int USERS_PER_PAGE = 20;
            var pages = (int)Math.Ceiling((await users.CountAsync()) / (float)USERS_PER_PAGE);
            if (!ModelState.IsValid) args.Page = 1;
            users = users.Skip((args.Page - 1) * USERS_PER_PAGE).Take(USERS_PER_PAGE);

            var vm = new UserIndexViewModel()
            {
                Users = await users.ToListAsync(),
                TotalPages = pages
            };
            vm.FillFromOther(args);
            return View(vm);
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
                if (_context.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Email), "An account with this email already exists.");
                    return View(model);
                }

                var user = model as User;
                var hasher = new PasswordHasher<User>();
                user.PassHash = hasher.HashPassword(user, model.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                this.AddMessage("Successfully added user");
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
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
        [ModelStateExclude
        (
            nameof(UserEditViewModel.Email),
            nameof(UserEditViewModel.PassHash)
        )]
        public async Task<IActionResult> EditConfirm(UserEditViewModel model)
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
                    model.Email = existing.Email;
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

                this.AddMessage("Successfully edited user");
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

            if (HttpContext.GetCurrentUserID() == id)
            {
                this.AddError("You cannot disable yourself while logged in.");
                return RedirectToAction(nameof(Index));
            }

            await _context.SaveChangesAsync();
            this.AddMessage("Successfully disabled user");
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
            this.AddMessage("Successfully reenabled user");
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
