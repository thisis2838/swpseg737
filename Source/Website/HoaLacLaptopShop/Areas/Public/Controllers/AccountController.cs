using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class AccountController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public AccountController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Login"), Route("Account/Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login"), Route("Account/Login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                this.SetError("Unknown email");
                return View("Login", model);
            }
            var hash = new PasswordHasher<User>();
            if (hash.VerifyHashedPassword(user, user.PassHash!, model.Password) == PasswordVerificationResult.Failed)
            {
                this.SetError("Incorrect password");
                return View("Login", model);
            }
            if (user.IsDeleted)
            {
                this.SetError("This account has been deleted");
                return View("Login", model);
            }
            await HttpContext.SignOut();
            await HttpContext.LoginAsUser(user);
            this.SetMessage($"Loggin in as {user.Name}");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Logout"), Route("Account/Logout")]
        public async Task<ActionResult> Logout()
        {
            this.SetMessage($"Logged out");
            await HttpContext.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(HttpContext.GetCurrentUser());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string gender)
        {
            var fields = new string[]
            {
                nameof(RegisterViewModel.ID),
                nameof(RegisterViewModel.Name),
                nameof(RegisterViewModel.Email),
                nameof(RegisterViewModel.Password),
                nameof(RegisterViewModel.PhoneNumber)
            };
            if (fields.All(x => !ModelState.TryGetValue(x, out var valid) || valid.ValidationState == ModelValidationState.Valid))
            {
                if (_context.Users.Any(x => x.Email == model.Email))
                {
                    this.SetError("This email has already been used");
                    return View(model);
                }
                var user = model as User;
                user.Gender = gender.Equals("Male");
                var hasher = new PasswordHasher<User>();
                user.PassHash = hasher.HashPassword(user, model.Password);
                user.IsSales = user.IsMarketing = user.IsAdmin = false;
                _context.Add(user);
                await _context.SaveChangesAsync();
                await HttpContext.SignOut();
                await HttpContext.LoginAsUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Edit()
        {
            var currentUser = HttpContext.GetCurrentUser()!;
            return View(new AccountEditViewModel()
            {
                ID = currentUser.ID,
                Email = currentUser.Email,
                Name = currentUser.Name,
                Gender = currentUser.Gender,
                PhoneNumber = currentUser.PhoneNumber,
                IsAdmin = currentUser.IsAdmin,
                IsMarketing = currentUser.IsMarketing,
                IsSales = currentUser.IsSales
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit(AccountEditViewModel model)
        {
            if (model.ID != HttpContext.GetCurrentUserID())
            {
                this.SetError("You are not allowed to edit this user.");
                return Unauthorized();
            }

            var fields = new string[]
            {
                nameof(AccountEditViewModel.ID),
                nameof(AccountEditViewModel.Name),
                nameof(AccountEditViewModel.Email),
                nameof(AccountEditViewModel.CurrentPassword),
                nameof(AccountEditViewModel.NewPassword),
                nameof(AccountEditViewModel.PhoneNumber)
            };
            if (fields.All(x => !ModelState.TryGetValue(x, out var valid) || valid.ValidationState == ModelValidationState.Valid))
            {
                try
                {
                    var hasher = new PasswordHasher<User>();
                    var user = HttpContext.GetCurrentUser()!;

                    model.PassHash = string.IsNullOrEmpty(model.NewPassword) 
                        ? user.PassHash
                        : hasher.HashPassword(user, model.NewPassword);
                    if (hasher.VerifyHashedPassword(user, user.PassHash, model.CurrentPassword) == PasswordVerificationResult.Failed)
                    {
                        this.SetError("Incorrect current password");
                        return View(model);
                    }
                    user.Email = model.Email;
                    user.PassHash = model.PassHash;
                    _context.Update(user);
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
            }
            return RedirectToAction("Index");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.ID == id);
        }
    }
}
