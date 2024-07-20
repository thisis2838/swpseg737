using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mail;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public partial class AccountController
    {
        private const string CUR_VERIF_KEY = "AccountController:CurrentVerificationKey";
        private static HttpClient _client = new HttpClient();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [ModelStateInclude
        (
            nameof(RegisterViewModel.ID),
            nameof(RegisterViewModel.Name),
            nameof(RegisterViewModel.Email),
            nameof(RegisterViewModel.Gender),
            nameof(RegisterViewModel.Password),
            nameof(RegisterViewModel.PhoneNumber)
        )]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already.");
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                if (_context.Users.Any(x => x.Email == model.Email))
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Email), "There is already an account with that email registered with the site.");
                    return View(model);
                }

                if (!MailAddress.TryCreate(model.Email, out var email))
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Email), "Invalid email.");
                    return View(model);
                }
                else
                {
                    /*
                    var host = email.Host;
                    try { await _client.GetAsync("http://" + host, HttpCompletionOption.ResponseHeadersRead); }
                    catch
                    {
                        ModelState.AddModelError(nameof(RegisterViewModel.Email), "The email must be for a valid email provider.");
                        return View(model);
                    }
                    */
                }
                

                int code = new Random().Next(100000, 1000000);
                var subject = "Hoalac Laptops Registration Verification Code";
                var result = await _viewRenderService.RenderToStringAsync("Account/RegisterEmailTemplate", code.ToString());
                await _emailSender.SendEmailAsync(model.Email, subject, result);

                var user = model as User;
                user.PassHash = new PasswordHasher<User>().HashPassword(user, model.Password);
                user.IsSales = user.IsMarketing = user.IsAdmin = false;
                HttpContext.Session.Set(CUR_VERIF_KEY, new RegisterChallengeData()
                {
                    RegisterViewModel = model,
                    Code = code,
                    RegistrationTime = DateTime.Now
                });
                return RedirectToAction(nameof(RegisterChallenge), new { email = model.Email });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult RegisterChallenge(string email)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already. Please log out to register.");
                return RedirectToAction("Index", "Home");
            }

            if (!HttpContext.Session.Keys.Contains(CUR_VERIF_KEY))
            {
                this.AddError("You don't have an ongoing registration!");
                return RedirectToAction("Index", "Home");
            }
            return View(model: email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterComplete(string activationCode)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already. Please log out to register");
                return RedirectToAction("Index", "Home");
            }

            var verif = HttpContext.Session.Get<RegisterChallengeData>(CUR_VERIF_KEY);
            if (verif is null)
            {
                this.AddError("Your session has expired! Please register again.");
                return RedirectToAction("Register");
            }

            if (verif.TriesLeft <= 0)
            {
                this.AddError("You have entered the code wrong too many times! Please register again.");
                HttpContext.Session.Remove(CUR_VERIF_KEY);
                return RedirectToAction("Register");
            }

            if (!activationCode.Equals(verif.Code.ToString()))
            {
                this.AddError($"Invalid activation code. You have {verif.TriesLeft} tries left.");
                verif.TriesLeft--;
                HttpContext.Session.Set(CUR_VERIF_KEY, verif);
                return RedirectToAction(nameof(RegisterChallenge), new {email = verif.RegisterViewModel.Email});
            }
            if (DateTime.Now - verif.RegistrationTime > TimeSpan.FromMinutes(5))
            {
                this.AddError("Your code has expired! Please enter the newly generated code.");
                return RedirectToAction
                (
                    nameof(Register),
                    new { model = verif.RegisterViewModel }
                );
            }

            var user = verif.RegisterViewModel as User;
            _context.Add(user);
            await _context.SaveChangesAsync();
            await HttpContext.SignOut();
            await HttpContext.LoginAsUser(user, false);
            this.AddMessage("Registered and logged in as " + user.Name);
            return RedirectToAction("Index", "Home");
        }
        
        public class RegisterChallengeData
        {
            public required RegisterViewModel RegisterViewModel { get; set; }
            public required DateTime RegistrationTime { get; set; }
            public required int Code { get; set; }
            public int TriesLeft { get; set; } = 5;
        }
    }
}
