using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin,Marketing")]
    [Area("Administration")]
    public class NewsPostsController : Shared.Controllers.NewsPostsController
    {
        public NewsPostsController
        (
            HoaLacLaptopShopContext context,
            IWebHostEnvironment env
        )
        : base(context, env)
        {
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(ValueLengthLimit = 100*1000*1000)]
        public async Task<IActionResult> Create([FromForm][Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            ModelState.Remove(nameof(NewsPost.AuthorId));
            ModelState.Remove(nameof(NewsPost.Token));

            if (ModelState.IsValid)
            {
                newsPost.Time = DateTime.Now;
                newsPost.AuthorId = HttpContext.GetCurrentUser()!.ID;
                newsPost.Token = ResourceHelper.GenerateResourceToken();
                SaveContent(newsPost, newsPost.Content ?? "");

                Context.Add(newsPost);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit), new { id = newsPost.ID });
            }
            return View(newsPost);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await Context.NewsPosts.FindAsync(id);
            if (newsPost == null)
            {
                return NotFound();
            }
            if (!HttpContext.GetCurrentUser()!.IsAdmin && newsPost.AuthorId != HttpContext.GetCurrentUserID())
            {
                return Unauthorized();
            }

            var content = await GetContent(newsPost);
            if (content is null) { return NotFound(); }
            return View(new NewsPostDetailsViewModel(newsPost, content));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(ValueLengthLimit = 100 * 1000 * 1000)]
        public async Task<IActionResult> Edit(int? id, [FromForm][Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            if (id != newsPost.ID) return NotFound();
            var targetPost = await Context.NewsPosts.FindAsync(id);
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

                    Context.Update(targetPost);
                    await Context.SaveChangesAsync();
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
                return RedirectToAction(nameof(Index));
            }
            return View(newsPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var newsPost = await Context.NewsPosts.FindAsync(id);
            if (newsPost != null)
            {
                if (!HttpContext.GetCurrentUser()!.IsAdmin && newsPost.AuthorId != HttpContext.GetCurrentUserID())
                {
                    return Unauthorized();
                }
                Context.NewsPosts.Remove(newsPost);
            }
            else
            {
                return NotFound();
            }

            await Context.SaveChangesAsync();
            DeleteContent(newsPost);
            return RedirectToAction(nameof(Index));
        }

        private bool NewsPostExists(int id)
        {
            return Context.NewsPosts.Any(e => e.ID == id);
        }
    }
}
