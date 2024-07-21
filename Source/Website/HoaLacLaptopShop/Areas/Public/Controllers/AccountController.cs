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
            ViewBag.ReturnUrl = returnUrl;
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
            ViewBag.ReturnUrl = returnUrl;
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
            if (Url.IsLocalUrl(returnUrl))
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

        [Authorize]
        public IActionResult Index()
        {
            return View(HttpContext.GetCurrentUser());
        }

        [Authorize]
        public ActionResult Edit()
        {
            var currentUser = HttpContext.GetCurrentUser()!;
            var edit = new AccountEditViewModel();
            edit.FillFromOther(currentUser);
            return View(edit);
        }

        [Authorize]
        public ActionResult Details()
        {
            var currentUser = HttpContext.GetCurrentUser()!;
            return View(new User()
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
        [ModelStateInclude
        (
            nameof(AccountEditViewModel.ID),
            nameof(AccountEditViewModel.Name),
            nameof(AccountEditViewModel.Email),
            nameof(AccountEditViewModel.CurrentPassword),
            nameof(AccountEditViewModel.NewPassword),
            nameof(AccountEditViewModel.PhoneNumber)
        )]
        [Authorize]
        public async Task<ActionResult> Edit(AccountEditViewModel model, string gender)
        {
            if (model.ID != HttpContext.GetCurrentUserID())
            {
                this.AddError("You are not allowed to edit this user.");
                return Unauthorized();
            }

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
                        this.AddError("Incorrect current password");
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
        [Authorize]
        public async Task<IActionResult> OrderHistory()
        {
            var id = HttpContext.GetCurrentUser()!.ID;
            var user = _context.Users.Find(id)!;
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                .Include(o => o.Voucher)
                .Where(o => o.BuyerID == id)
                .ToListAsync();
            return View(order);
        }
        [Authorize]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(oi => oi.Product)
                .Include(o => o.Buyer)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (order is null)
            {
                return NotFound();
            }
            return View(order);
        }

        [Authorize]
        public async Task<IActionResult> ReviewHistory(int page = 1)
        {
            var id = HttpContext.GetCurrentUser()!.ID;
            var user = _context.Users.Find(id)!;
            var review = await _context.ProductReviews
                .Include(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.ReviewerId == id)
                .OrderBy(p => p.ReviewTime)
                .ToListAsync();
            var curPage = review.Skip((page - 1) * 12).Take(12);
            return View(new ReviewViewModel
            {
                ProductReviews = curPage.ToList(),
                TotalCount = review.Count,
                TargetPage = page
            });
        }
        [Authorize]
        public async Task<IActionResult> ReviewDetails(int pid, int rid)
        {
            var product = _context.Products.Where(p => p.ID == pid).Include(p => p.ProductImages).Include(p => p.Brand).FirstOrDefault();
            var reviewer = _context.Users.Where(u => u.ID == rid).FirstOrDefault();
            var review = _context.ProductReviews.Where(pr => pr.ProductId == pid && pr.ReviewerId == rid).FirstOrDefault();
            return View(new ReviewDetailViewModel
            {
                Product = product,
                User = reviewer,
                ProductReview = review
            });
        }
    }
}
