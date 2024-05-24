using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Models;
using System.Security.Cryptography;
using System.Text;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HoaLacLaptopShop.Controllers
{
    public class NewsPostsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public NewsPostsController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        // GET: NewsPosts
        public async Task<IActionResult> Index()
        {
            var hoaLacLaptopShopContext = _context.NewsPosts.Include(n => n.Author).OrderByDescending(x => x.Time);
            return View(await hoaLacLaptopShopContext.ToListAsync());
        }

        // GET: NewsPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await _context.NewsPosts
                .Include(n => n.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newsPost == null)
            {
                return NotFound();
            }

            return View(newsPost);
        }

<<<<<<< HEAD:Source/Website/HoaLacLaptopShop/Controllers/NewsPostsController.cs
        // GET: NewsPosts/Create
        public IActionResult Create()
=======
        // GET: Users/Register
        public IActionResult Register()
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d:Source/Website/HoaLacLaptopShop/Controllers/UsersController.cs
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

<<<<<<< HEAD:Source/Website/HoaLacLaptopShop/Controllers/NewsPostsController.cs
        // POST: NewsPosts/Create
=======
        public static string ToMd5Hash(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // POST: Users/Register
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d:Source/Website/HoaLacLaptopShop/Controllers/UsersController.cs
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD:Source/Website/HoaLacLaptopShop/Controllers/NewsPostsController.cs
        public async Task<IActionResult> Create([Bind("ID,Title,Content,AuthorId")] NewsPost newsPost)
        {
            if (ModelState.IsValid)
            {
                newsPost.Time = DateTime.Now;
                _context.Add(newsPost);
=======
        public async Task<IActionResult> Register([Bind("ID,Name,Email,PassHash,PhoneNumber")] User user, string gender)
        {
            if (ModelState.IsValid)
            {
                user.PassHash = ToMd5Hash(user.PassHash);
                if (gender.Equals("Male"))
                {
                    user.Gender = true;
                }
                else if (gender.Equals("Female"))
                {
                    user.Gender = false;
                }
                user.Role = 0;
                _context.Add(user);
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d:Source/Website/HoaLacLaptopShop/Controllers/UsersController.cs
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "ID", "ID", newsPost.AuthorId);
            return View(newsPost);
        }

<<<<<<< HEAD:Source/Website/HoaLacLaptopShop/Controllers/NewsPostsController.cs
        // GET: NewsPosts/Edit/5
=======
        #region Login
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(us => us.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Error", "Wrong login information");
                }
                else
                {
                    if (ToMd5Hash(model.Password) != ToMd5Hash(user.PassHash))
                    {
                        ModelState.AddModelError("Error", "Wrong login information");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, "Customer")
                        };
                        var claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return Redirect("/Home");
                        }
                    }
                }

            }
            await _context.SaveChangesAsync();
            return View();
        }
        #endregion

        // GET: Users/Edit/5
        [Authorize]
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d:Source/Website/HoaLacLaptopShop/Controllers/UsersController.cs
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await _context.NewsPosts.FindAsync(id);
            if (newsPost == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "ID", "ID", newsPost.AuthorId);
            return View(newsPost);
        }

        // POST: NewsPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Content,AuthorId")] NewsPost newsPost)
        {
            if (id != newsPost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    newsPost.Time = DateTime.Now;
                    _context.Update(newsPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsPostExists(newsPost.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new {id = newsPost.ID });
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "ID", "ID", newsPost.AuthorId);
            return View(newsPost);
        }

        // GET: NewsPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await _context.NewsPosts
                .Include(n => n.Author)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (newsPost == null)
            {
                return NotFound();
            }

            return View(newsPost);
        }

        // POST: NewsPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsPost = await _context.NewsPosts.FindAsync(id);
            if (newsPost != null)
            {
                _context.NewsPosts.Remove(newsPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsPostExists(int id)
        {
            return _context.NewsPosts.Any(e => e.ID == id);
        }
    }
}
