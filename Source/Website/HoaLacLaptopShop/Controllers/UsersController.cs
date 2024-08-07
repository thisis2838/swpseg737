﻿using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Cryptography;
    using System.Text;
    using global::HoaLacLaptopShop.Models;
    using global::HoaLacLaptopShop.ViewModels;
    using Microsoft.AspNetCore.Identity;

    namespace HoaLacLaptopShop.Controllers
    {
        public class UsersController : Controller
        {
            private readonly HoaLacLaptopShopContext _context;

            public UsersController(HoaLacLaptopShopContext context)
            {
                _context = context;
            }

            // GET: Users
            public async Task<IActionResult> Index()
            {
                return View(await _context.Users.ToListAsync());
            }

            // GET: Users/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

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

            // GET: Users/Create
            public IActionResult Register()
            {
                return View();
            }

            // POST: Users/Register
            [HttpPost]
            [ValidateAntiForgeryToken]
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
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                return View(user);
            }

            // GET: Users/Login
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = _context.Users.SingleOrDefault(x => x.Email.Equals(model.Email));
                    if (user != null)
                    {
                        if (user.PassHash.Equals(ToMd5Hash(model.Password)))
                        {
                            HttpContext.Session.SetString("CurrentUserId", user.ID.ToString());
                            HttpContext.Session.SetString("Username", user.Name);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Error = "Invalid information";
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewBag.Error = "You need to login first";
                        return View(model);
                    }
                }
                return View(model);
            }

            // GET: Users/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }

            // POST: Users/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,PassHash,Gender,PhoneNumber,Role")] User user)
            {
                if (id != user.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.ID))
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
                return View(user);
            }

            // GET: Users/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(m => m.ID == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }

            // POST: Users/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool UserExists(int id)
            {
                return _context.Users.Any(e => e.ID == id);
            }
        }
    }
}
