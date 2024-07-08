using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authorization;
using HoaLacLaptopShop.Helpers;
using Ganss.Xss;
using HtmlAgilityPack;
using AngleSharp.Io;
using HeyRed.Mime;
using System.Net;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Areas.Shared.Controllers;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Services;
using HoaLacLaptopShop.Filters;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class NewsPostsController : HoaLacController
    {
        protected override string ManagedObjectsString => "News Posts";

        protected readonly HoaLacLaptopShopContext Context;
        protected readonly ILocalResourceService Local;

        public NewsPostsController
        (
            HoaLacLaptopShopContext context,
            ILocalResourceService local
        )
        {
            Context = context;
            Local = local;
        }

        [NonAction]
        protected string GetContentPath(NewsPost post)
        {
            return Local.GetRelativePath(ResourceType.Html , "news", post.Token + ".html");
        }
        [NonAction]
        protected string GetImagesFolder(NewsPost post)
        {
            return Local.GetRelativePath(ResourceType.Images, "news", post.Token);
        }
        [NonAction]
        protected string GetContent(NewsPost post)
        {
            var contentPath = GetContentPath(post);
            return (!Local.FileExists(contentPath)) 
                ? "<span>Missing content. Please contact an administrator.</span>"
                : Local.FileReadAll(contentPath);
        }

        public async Task<IActionResult> Index(NewsPostIndexArgs? args = null)
        {
            begin:;
            var news = Context.NewsPosts.Include(n => n.Author).OrderByDescending(x => x.Time).AsQueryable();
            IEnumerable<NewsPost> newsConv = null!;

            if (ModelState.IsValid && args != null)
            {
                if (!string.IsNullOrWhiteSpace(args.SearchTerm))
                {
                    news = news.Where(x => x.Title.ToLower().Contains(args.SearchTerm.ToLower()));
                }
                if (!string.IsNullOrWhiteSpace(args.PostedBy))
                {
                    news = news.Where(x => x.Author!.Name.ToLower().Contains(args.PostedBy.ToLower()));
                }
                
                DateTime minDate = new DateTime(1800, 1, 1);
                if (args.PostedAfter.HasValue)
                {
                    var after = args.PostedAfter.Value;
                    if (after < minDate)
                    {
                        ModelState.AddModelError
                        (
                            nameof(NewsPostIndexArgs.PostedAfter),
                            "Posted after date must be on or after 1800."
                        );
                        goto begin;
                    }
                    if (DateTime.Now < args.PostedAfter.Value)
                    {
                        this.AddWarning("Posted after date was put into the future! Resetting it to be today.");
                        args.PostedAfter = DateTime.Now;
                        ModelState.Remove(nameof(NewsPostIndexArgs.PostedAfter));
                    }

                    news = news.Where(x => x.Time.Date >= args.PostedAfter.Value);
                }
                if (args.PostedBefore.HasValue)
                {
                    var before = args.PostedBefore.Value;
                    if (before < minDate)
                    {
                        ModelState.AddModelError
                        (
                            nameof(NewsPostIndexArgs.PostedBefore),
                            "Posted before date must be on or after 1800."
                        );
                        goto begin;
                    }
                    news = news.Where(x => x.Time.Date <= args.PostedBefore.Value);
                }
                if (args.PostedBefore.HasValue && args.PostedAfter.HasValue)
                {
                    if (args.PostedBefore.Value < args.PostedAfter.Value)
                    {
                        ModelState.AddModelError
                        (
                            nameof(NewsPostIndexArgs.PostedBefore),
                            "Posted before date must not precede the posted after date."
                        );
                        goto begin;
                    }
                }

                if (!args.ShowLong && !args.ShowShort && !args.ShowMedium)
                {
                    this.AddWarning("Reset length showing preferences as all of them were disabled.");
                    args.ShowLong = args.ShowShort = args.ShowMedium = true;
                    ModelState.Remove(nameof(NewsPostIndexArgs.ShowShort));
                    ModelState.Remove(nameof(NewsPostIndexArgs.ShowMedium));
                    ModelState.Remove(nameof(NewsPostIndexArgs.ShowLong));
                }

                newsConv = await news.ToListAsync();
                if (!args.ShowShort) newsConv = newsConv.Where(x => x.Length != NewsPostLength.Short);
                if (!args.ShowMedium) newsConv = newsConv.Where(x => x.Length != NewsPostLength.Medium);
                if (!args.ShowLong) newsConv = newsConv.Where(x => x.Length != NewsPostLength.Long);
            }

            var vm = new NewsPostIndexViewModel() { Posts = newsConv?.ToList() ?? await news.ToListAsync() };
            if (args != null) vm.FillFromOther(args);
            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsPost = await Context.NewsPosts.Include(n => n.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (newsPost == null)
            {
                return NotFound();
            }

            var content = GetContent(newsPost);
            var vm = new NewsPostDetailsViewModel() { Content = content }; vm.FillFromOther(newsPost);
            return View(vm);
        }
    }
}