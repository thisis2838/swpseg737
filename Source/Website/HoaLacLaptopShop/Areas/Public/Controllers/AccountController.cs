using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
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
        private readonly ITemporaryResourceService _temp;


        public AccountController
        (
            HoaLacLaptopShopContext context,
            IEmailSenderService emailSender,
            IViewRenderService viewRenderService,
            ITemporaryResourceService temp
        )
        {
            _context = context;
            _emailSender = emailSender;
            _viewRenderService = viewRenderService;
            _temp = temp;
        }

        [HttpGet]
        [Route("Login"), Route("Account/Login")]
        public ActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl ?? Url.Action("Index", "Home");
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already.");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login"), Route("Account/Login")]
        public async Task<ActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl ?? Url.Action("Index", "Home");
            if (HttpContext.IsLoggedIn())
            {
                this.AddError("You are logged in already...");
                return RedirectToAction("Index", "Home");
            }
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Unknown email.");
                return View("Login", model);
            }
            var hash = new PasswordHasher<User>();
            if (hash.VerifyHashedPassword(user, user.PassHash, model.Password) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError(nameof(LoginViewModel.Password), "Incorrect password.");
                return View(model);
            }
            if (user.IsDisabled)
            {
                this.AddError("Your account has been deleted");
                return View(model);
            }
            await HttpContext.SignOut();
            await HttpContext.LoginAsUser(user, model.RememberMe);
            this.AddMessage($"Logged in as {user.Name}");
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        [Route("Logout"), Route("Account/Logout")]
        public async Task<ActionResult> Logout()
        {
            this.AddMessage($"Logged out");
            _temp.RemoveAll();
            await HttpContext.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        [NonAction]
        private PurchaseSummary GetPurchaseSummary()
        {
            return new PurchaseSummary()
            {
                ProductsBought = Orders().SelectMany(x => x.OrderDetails).Select(x => x.ProductId).Distinct().Count(),
                OrdersPlaced = Orders().Count(),
                MoneySpent = Orders().Sum(x => x.DiscountedPrice),
                MoneySaved = Orders().Sum(x => x.TotalPrice - x.DiscountedPrice),
                VouchersUsed = Orders().Select(x => x.VoucherID).Where(x => x.HasValue).Distinct().Count()
            };
        }
        [NonAction]
        private ReviewSummary GetReviewSummary()
        {
            return new ReviewSummary()
            {
                ProductsReviewed = Reviews().Count(),
                AverageRating = Reviews().Count() == 0 ? 0 : Reviews().Sum(x => x.Rating) / Reviews().Count(),
            };
        }
        [Authorize]
        public ActionResult Details()
        {
            return View(new AccountDetailsViewModel()
            {
                Account = HttpContext.GetCurrentUser()!,
                PurchaseSummary = GetPurchaseSummary(),
                ReviewSummary = GetReviewSummary()
            });
        }

        [Authorize]
        public ActionResult Edit()
        {
            var currentUser = HttpContext.GetCurrentUser()!;
            var edit = new AccountEditViewModel();
            edit.FillFromOther(currentUser);
            return View(edit);
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        [ModelStateInclude
        (
            nameof(AccountEditViewModel.Name),
            nameof(AccountEditViewModel.CurrentPassword),
            nameof(AccountEditViewModel.NewPassword),
            nameof(AccountEditViewModel.PhoneNumber)
        )]
        [Authorize]
        public async Task<ActionResult> Edit(AccountEditViewModel model, string gender)
        {
            if (ModelState.IsValid)
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
                        this.AddError("Incorrect current password. Please try again.");
                        return View(model);
                    }
                    user.Gender = gender.Equals("Male");
                    user.Name = model.Name;
                    user.PhoneNumber = model.PhoneNumber;
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

            this.AddMessage("Successfully updated your account.");
            return RedirectToAction(nameof(Details));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(x => x.ID == id);
        }
    }
}
