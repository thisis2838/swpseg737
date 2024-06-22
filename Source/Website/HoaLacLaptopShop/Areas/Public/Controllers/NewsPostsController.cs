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
            var news = Context.NewsPosts.Include(n => n.Author).OrderByDescending(x => x.Time).AsQueryable();
            if (!string.IsNullOrWhiteSpace(args?.SearchTerm))
            {
                var terms = args.SearchTerm;
                var titleMatch = news.Where(x => x.Title.Contains(terms));
                /* TODO var descMatch = news.Where(x => !x.Title.Contains(terms) && x.Content.Contains(terms));
                news = titleMatch.Concat(descMatch);*/
                news = titleMatch;
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

            var newsPost = await Context.NewsPosts.Include(n => n.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (newsPost == null)
            {
                return NotFound();
            }

            var content = GetContent(newsPost);
            return View(new NewsPostDetailsViewModel(newsPost, content));
        }
    }
}