using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Helpers;

namespace HoaLacLaptopShop.Controllers
{
    public class NewsPostsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;

        public NewsPostsController(HoaLacLaptopShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(NewsPostIndexArgs? args = null)
        {
            var news = _context.NewsPosts.Include(n => n.Author).OrderByDescending(x => x.Time).AsQueryable();
            if (!string.IsNullOrWhiteSpace(args?.SearchTerm))
            {
                var terms = args.SearchTerm;
                var titleMatch = news.Where(x => x.Title.Contains(terms));
                var descMatch = news.Where(x => !x.Title.Contains(terms) && x.Content.Contains(terms));
                news = titleMatch.Concat(descMatch);
            }
            return View(new NewsPostIndexViewModel()
            {
                Posts = await news.ToListAsync(),
                SearchTerm = args?.SearchTerm ?? null!,
            });
        }

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

        [Authorize(Roles = "Sales")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Create([Bind("ID,Title,Content")] NewsPost newsPost)
        {
            ModelState.Remove(nameof(NewsPost.AuthorId));

            if (ModelState.IsValid)
            {
                newsPost.Time = DateTime.Now;
                newsPost.AuthorId = HttpContext.GetCurrentUser()!.ID;

                _context.Add(newsPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsPost);
        }

        [Authorize(Roles = "Sales")]
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
            if (!HttpContext.GetCurrentUser()!.IsAdmin && newsPost.AuthorId != HttpContext.GetCurrentUserID())
            {
                return Unauthorized();
            }

            return View(newsPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,Title,Content")] NewsPost newsPost)
        {
            if (id != newsPost.ID) return NotFound();
            var targetPost = await _context.NewsPosts.FindAsync(id);
            if (targetPost is null) return NotFound();

            if (!HttpContext.GetCurrentUser()!.IsAdmin && targetPost.AuthorId != HttpContext.GetCurrentUserID())
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    targetPost.Title = newsPost.Title;
                    targetPost.Content = newsPost.Content;
                    targetPost.Time = DateTime.Now;

                    _context.Update(targetPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsPostExists(targetPost.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(newsPost);
        }

        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await _context.NewsPosts.Include(n => n.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (newsPost == null)
            {
                return NotFound();
            }
            if (!HttpContext.GetCurrentUser()!.IsAdmin && newsPost.AuthorId != HttpContext.GetCurrentUserID())
            {
                return Unauthorized();
            }

            return View(newsPost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsPost = await _context.NewsPosts.FindAsync(id);
            if (newsPost != null)
            {
                if (!HttpContext.GetCurrentUser()!.IsAdmin && newsPost.AuthorId != HttpContext.GetCurrentUserID())
                {
                    return Unauthorized();
                }
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