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
using Ganss.Xss;
using HtmlAgilityPack;
using AngleSharp.Io;
using HeyRed.Mime;
using System.Net;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace HoaLacLaptopShop.Controllers
{
    public class NewsPostsController : Controller
    {
        private readonly HoaLacLaptopShopContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<NewsPostsController> _logger;

        public NewsPostsController(HoaLacLaptopShopContext context, IWebHostEnvironment env, ILogger<NewsPostsController> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        public async Task<IActionResult> Index(NewsPostIndexArgs? args = null)
        {
            var news = _context.NewsPosts.Include(n => n.Author).OrderByDescending(x => x.Time).AsQueryable();
            if (!string.IsNullOrWhiteSpace(args?.SearchTerm))
            {
                var terms = args.SearchTerm;
                var titleMatch = news.Where(x => x.Title.Contains(terms));
                /* TODO var descMatch = news.Where(x => !x.Title.Contains(terms) && x.Content.Contains(terms));
                news = titleMatch.Concat(descMatch);*/
            }
            return View(new NewsPostIndexViewModel()
            {
                Posts = await news.ToListAsync(),
                SearchTerm = args?.SearchTerm ?? null!,
            });
        }

        private string GetContentPath(NewsPost post)
        {
            return Path.Combine(_env.WebRootPath, "html", "news", post.Token + ".html");
        }
        private async Task<String> GetContent(NewsPost post)
        {
            return await System.IO.File.ReadAllTextAsync(GetContentPath(post));
        }
        private void SaveContent(NewsPost post, string content)
        {
            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowDataAttributes = true;
            sanitizer.AllowedSchemes.Add("data");
            content = sanitizer.Sanitize(content);

            var document = new HtmlDocument();
            document.LoadHtml(content);

            var output = Path.Combine(_env.WebRootPath, "html", "news");
            Directory.CreateDirectory(output);
            output = Path.Combine(output, post.Token + ".html");
            document.Save(output);
        }
        private void DeleteContent(NewsPost post)
        {
            System.IO.File.Delete(GetContentPath(post));
        }

        public async Task<IActionResult> Details(int? id)
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

            return View(new NewsPostDetailsViewModel(newsPost, await GetContent(newsPost)));
        }

        [Authorize(Roles = "Sales")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Create([Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            ModelState.Remove(nameof(NewsPost.AuthorId));
            ModelState.Remove(nameof(NewsPost.Token));

            if (ModelState.IsValid)
            {
                newsPost.Time = DateTime.Now;
                newsPost.AuthorId = HttpContext.GetCurrentUser()!.ID;
                newsPost.Token = ResourceHelper.GenerateResourceToken();
                SaveContent(newsPost, newsPost.Content ?? "");

                _context.Add(newsPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new {id = newsPost.ID});
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

            return View(new NewsPostDetailsViewModel(newsPost, await GetContent(newsPost)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            if (id != newsPost.ID) return NotFound();
            var targetPost = await _context.NewsPosts.FindAsync(id);
            if (targetPost is null) return NotFound();

            if (!HttpContext.GetCurrentUser()!.IsAdmin && targetPost.AuthorId != HttpContext.GetCurrentUserID())
            {
                return Unauthorized();
            }

            ModelState.Remove(nameof(NewsPost.AuthorId));
            ModelState.Remove(nameof(NewsPost.Token));

            if (ModelState.IsValid)
            {
                try
                {
                    targetPost.Title = newsPost.Title;
                    SaveContent(targetPost, newsPost.Content ?? "");
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
                return RedirectToAction(nameof(Details), new { id = id });
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
            else
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            DeleteContent(newsPost);
            return RedirectToAction(nameof(Index));
        }

        private bool NewsPostExists(int id)
        {
            return _context.NewsPosts.Any(e => e.ID == id);
        }
    }
}