using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public partial class AccountController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChallengeEmail(RegisterViewModel model, string gender)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already.");
                return RedirectToAction("Index", "Home");
            }

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
                    this.SetError("This email has already been used.");
                    return RedirectToAction("Register", new { model, gender });
                }

                int code = new Random().Next(100000, 1000000);
                var subject = "Hoalac Laptops Regitration Verification Code";
                var result = await _viewRenderService.RenderToStringAsync("Account/ConfirmEmail", code.ToString());
                await _emailSender.SendEmailAsync(model.Email, subject, result);

                var user = model as User;
                user.Gender = gender.Equals("Male");
                user.PassHash = new PasswordHasher<User>().HashPassword(user, model.Password);
                user.IsSales = user.IsMarketing = user.IsAdmin = false;
                HttpContext.Session.Set(CUR_VERIF_KEY, new RegisterChallenge()
                {
                    RegisterViewModel = model,
                    Code = code,
                    RegistrationTime = DateTime.Now
                });
                return RedirectToAction("CompleteRegistration", "Account", new { email = model.Email });
            }
            return RedirectToAction("Register", new { model, gender });
        }

        [HttpGet]
        [ActionName("ChallengePasswordReset")]
        public ActionResult ChallengePasswordResetGet(string email)
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
            return View(model: email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ChallengePasswordReset")]
        public IActionResult ChallengePasswordResetPost(string resetCode)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.SetError("You are logged in already.");
                return RedirectToAction("Index", "Home");
            }

            var reset = HttpContext.Session.Get<PasswordResetChallenge>(CUR_PASS_RESET_KEY);
            if (reset is null)
            {
                this.SetError("Your session has expired! Please try again.");
                return RedirectToAction("Index", "Home");
            }

            if (reset.TriesLeft <= 0)
            {
                this.SetError("You have entered the code wrong too many times! Please try again.");
                HttpContext.Session.Remove(CUR_PASS_RESET_KEY);
                return RedirectToAction("Index", "Home");
            }

            if (!resetCode.Equals(reset.Code.ToString()))
            {
                this.SetError($"Invalid reset password code. You have {reset.TriesLeft} tries left.");
                reset.TriesLeft--;
                HttpContext.Session.Set(CUR_PASS_RESET_KEY, reset);
                return View();
            }
            if (DateTime.Now - reset.SubmitTime > TimeSpan.FromMinutes(5))
            {
                this.SetError("Your code has expired! Please enter the newly generated code.");
                return RedirectToAction("ChallengePasswordReset");
            }
            return RedirectToAction("CompletePasswordReset", "Account");
        }
    }
}
