using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;
        private readonly IEmailSenderService _emailSender;
        private readonly IViewRenderService _viewRenderService;

        private const string CUR_VERIF_KEY = "AccountController:CurrentVerificationKey";
        private const string CUR_PASS_RESET_KEY = "AccountController:CurrentPasswordResetKey";

        public AccountController
        (
            HoaLacLaptopShopContext context,
            IEmailSenderService emailSender,
            IViewRenderService viewRenderService
        )
        {
            _context = context;
            _emailSender = emailSender;
            _viewRenderService = viewRenderService;
        }

        [HttpGet]
        [Route("Login"), Route("Account/Login")]
        public ActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already...");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login"), Route("Account/Login")]
        public async Task<ActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already...");
                return RedirectToAction("Index", "Home");
            }
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Unknown email.");
                return View("Login", model);
            }

            if (user.PassHash is null)
            {
                this.SetError("You haven't set up a password. Please log in via a 3rd party instead.");
                return View(model);
            }
            var hash = new PasswordHasher<User>();
            if (hash.VerifyHashedPassword(user, user.PassHash!, model.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Password), "Incorrect password.");
                return View(model);
            }
            if (user.IsDeleted)
            {
                this.SetError("Your account has been deleted");
                return View(model);
            }
            await HttpContext.SignOut();
            await HttpContext.LoginAsUser(user, model.RememberMe);
            this.SetMessage($"Loggin in as {user.Name}");
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string resetEmail)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == resetEmail);
            if (user == null)
            {
                this.SetError("There is no account created with this email.");
                return View();
            }
            int code = new Random().Next(100000, 1000000);
            var subject = "Hoalac Laptops Reset Password Code";
            var result = await _viewRenderService.RenderToStringAsync("Account/ResetPasswordEmail", code.ToString());
            await _emailSender.SendEmailAsync(resetEmail, subject, result);
            HttpContext.Session.Set(CUR_PASS_RESET_KEY, new PasswordResetChallenge()
            {
                ResetPasswordViewModel = new ResetPasswordViewModel()
                {
                    Email = user.Email,
                },
                Code = code,
                SubmitTime = DateTime.Now
            });
            return RedirectToAction("ChallengePasswordReset", "Account", new { email = user.Email });
        }

        [HttpGet]
        public ActionResult CompletePasswordReset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompletePasswordReset(string newpass, string confirmpass)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already. Please log out to register.");
                return RedirectToAction("Index", "Home");
            }

            if (!HttpContext.Session.Keys.Contains(CUR_PASS_RESET_KEY))
            {
                this.SetError("You are not trying to reset your password.");
                return RedirectToAction("Index", "Home");
            }
            if (!newpass.Equals(confirmpass))
            {
                this.SetError("Password not matching! Please try again");
                return View();
            }
            var reset = HttpContext.Session.Get<ResetPasswordViewModel>(CUR_PASS_RESET_KEY);
            string newHash = new PasswordHasher<User>().HashPassword(null!, newpass);
            await _context.Users.ExecuteUpdateAsync(x => x.SetProperty(y => y.PassHash, newHash));
            this.SetMessage("Reset password successfully");
            return RedirectToAction("Login", "Account");
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
        [ActionName("CompleteRegistration")]
        public async Task<IActionResult> CompleteRegistrationPost(string activationCode)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already. Please log out to register");
                return RedirectToAction("Index", "Home");
            }

            var verif = HttpContext.Session.Get<RegisterChallenge>(CUR_VERIF_KEY);
            if (verif is null)
            {
                this.SetError("Your session has expired! Please register again.");
                return RedirectToAction("Register");
            }

            if (verif.TriesLeft <= 0)
            {
                this.SetError("You have entered the code wrong too many times! Please register again.");
                HttpContext.Session.Remove(CUR_VERIF_KEY);
                return RedirectToAction("Register");
            }

            if (!activationCode.Equals(verif.Code.ToString()))
            {
                this.SetError($"Invalid activation code. You have {verif.TriesLeft} tries left.");
                verif.TriesLeft--;
                HttpContext.Session.Set(CUR_VERIF_KEY, verif);
                return View();
            }
            if (DateTime.Now - verif.RegistrationTime > TimeSpan.FromMinutes(5))
            {
                this.SetError("Your code has expired! Please enter the newly generated code.");
                return RedirectToAction
                (
                    "ChallengeEmail",
                    new { model = verif.RegisterViewModel }
                );
            }

            var user = verif.RegisterViewModel as User;
            _context.Add(user);
            await _context.SaveChangesAsync();
            await HttpContext.SignOut();
            await HttpContext.LoginAsUser(user, false);
            this.SetMessage("Registered and logged in as " + user.Name);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [ActionName("CompleteRegistration")]
        public ActionResult CompleteRegistrationGet(string email)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already. Please log out to register.");
                return RedirectToAction("Index", "Home");
            }

            if (!HttpContext.Session.Keys.Contains(CUR_VERIF_KEY))
            {
                this.SetError("You don't have an ongoing registration!");
                return RedirectToAction("Index", "Home");
            }
            return View(model: email);
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

        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<ActionResult> Edit(AccountEditViewModel model, string gender)
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
                    user.Gender = gender.Equals("Male");
                    user.Name = model.Name;
                    user.PhoneNumber = model.PhoneNumber;
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
            return RedirectToAction("Index", "Home");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.ID == id);
        }

        public class RegisterChallenge
        {
            public required RegisterViewModel RegisterViewModel { get; set; }
            public required DateTime RegistrationTime { get; set; }
            public required int Code { get; set; }
            public int TriesLeft { get; set; } = 5;
        }

        public class PasswordResetChallenge
        {
            public required ResetPasswordViewModel ResetPasswordViewModel { get; set; }
            public required DateTime SubmitTime { get; set; }
            public required int Code { get; set; }
            public int TriesLeft { get; set; } = 5;
        }
    }
}
