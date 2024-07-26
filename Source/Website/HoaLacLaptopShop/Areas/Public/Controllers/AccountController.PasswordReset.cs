using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using HoaLacLaptopShop.Areas.Public.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public partial class AccountController
    {
        private const string CUR_PASS_RESET_KEY = "AccountController:CurrentPasswordResetKey";

        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordReset(string resetEmail)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == resetEmail);
                if (user == null)
                {
                    ModelState.AddModelError(nameof(resetEmail), "Unknown email.");
                    return View();
                }
                int code = new Random().Next(100000, 1000000);
                var subject = "Hoalac Laptops Reset Password Code";
                var result = await _viewRenderService.RenderToStringAsync("Account/PasswordResetEmailTemplate", code.ToString());
                try
                {
                    await _emailSender.SendEmailAsync(resetEmail, subject, result);
                }
                catch (Exception)
                {
                    this.AddError("Cannot send email! Please try again later.");
                    return View();
                }
                HttpContext.Session.Set(CUR_PASS_RESET_KEY, new PasswordResetChallengeData()
                {
                    Email = user.Email,
                    Code = code,
                    SubmitTime = DateTime.Now
                });
                return RedirectToAction(nameof(PasswordResetChallenge), new { email = user.Email });
            }

            return View();
        }

        [HttpGet]
        public ActionResult PasswordResetChallenge(string email)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already. Please log out to register.");
                return RedirectToAction("Index", "Home");
            }

            if (!HttpContext.Session.Keys.Contains(CUR_PASS_RESET_KEY))
            {
                this.AddError("You are not trying to reset your password.");
                return RedirectToAction("Index", "Home");
            }
            return View(model: email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PasswordResetConfirm(string resetCode)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already.");
                return RedirectToAction("Index", "Home");
            }

            var reset = HttpContext.Session.Get<PasswordResetChallengeData>(CUR_PASS_RESET_KEY);
            if (reset is null)
            {
                this.AddError("Your password reset session has expired! Please try again.");
                return RedirectToAction(nameof(PasswordReset));
            }
            if (reset.TriesLeft <= 0)
            {
                this.AddError("You have entered the code wrong too many times! Please try again.");
                HttpContext.Session.Remove(CUR_PASS_RESET_KEY);
                return RedirectToAction("Index", "Home");
            }
            if (!resetCode.Equals(reset.Code.ToString()))
            {
                this.AddError($"Invalid reset password code. You have {reset.TriesLeft} tries left.");
                reset.TriesLeft--;
                HttpContext.Session.Set(CUR_PASS_RESET_KEY, reset);
                return RedirectToAction(nameof(PasswordResetChallenge), new {email = reset.Email});
            }
            if (DateTime.Now - reset.SubmitTime > TimeSpan.FromMinutes(5))
            {
                this.AddError("Your code has expired! Please enter the newly generated code.");
                return RedirectToAction(nameof(PasswordReset), new { email = reset.Email });
            }
            return RedirectToAction(nameof(PasswordResetComplete));
        }

        [HttpGet]
        public ActionResult PasswordResetComplete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordResetComplete(string newpass, string confirmpass)
        {
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in and cannot reset your password.");
                return RedirectToAction("Index", "Home");
            }
            if (!HttpContext.Session.Keys.Contains(CUR_PASS_RESET_KEY))
            {
                this.AddError("You cannot reset your password at this time.");
                return RedirectToAction("Index", "Home");
            }
            if (!newpass.Equals(confirmpass))
            {
                ModelState.AddModelError(nameof(newpass), "Passwords do not match");
                ModelState.AddModelError(nameof(confirmpass), "Passwords do not match");
                return View();
            }

            var reset = HttpContext.Session.Get<ResetPasswordViewModel>(CUR_PASS_RESET_KEY);
            string newHash = new PasswordHasher<User>().HashPassword(null!, newpass);
            await _context.Users.ExecuteUpdateAsync(x => x.SetProperty(y => y.PassHash, newHash));
            this.AddMessage("Reset password successfully. You can now log in using your new password.");
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        public class PasswordResetChallengeData
        {
            public required string Email { get; set; }
            public required DateTime SubmitTime { get; set; }
            public required int Code { get; set; }
            public int TriesLeft { get; set; } = 5;
        }
    }
}
