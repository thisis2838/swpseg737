using Ganss.Xss;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.RegularExpressions;

namespace HoaLacLaptopShop.Areas.Shared.Controllers
{
    public abstract class NewsPostsController : HoaLacController
    {
        protected override string ManagedObjectsString => "News Posts";

        protected readonly HoaLacLaptopShopContext Context;
        protected readonly IWebHostEnvironment Environment;

        public NewsPostsController
        (
            HoaLacLaptopShopContext context, 
            IWebHostEnvironment env
        )
        {
            Context = context;
            Environment = env;
        }

        [NonAction]
        protected string GetContentPath(NewsPost post)
        {
            return Path.Combine(Environment.WebRootPath, "html", "news", post.Token + ".html");
        }
        [NonAction]
        protected async Task<string?> GetContent(NewsPost post)
        {
            var contentPath = GetContentPath(post);
            if (!Path.Exists(contentPath))
            {
                return "<span>Missing content. Please contact an administrator.</span>";
            }
            return await System.IO.File.ReadAllTextAsync(GetContentPath(post));
        }
        [NonAction]
        protected void SaveContent(NewsPost post, string content)
        {
            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowDataAttributes = true;
            sanitizer.AllowedSchemes.Add("data");
            content = sanitizer.Sanitize(content);

            var document = new HtmlDocument();
            document.LoadHtml(content);

            var newsFile = Path.Combine(Environment.WebRootPath, "html", "news");
            Directory.CreateDirectory(newsFile);
            newsFile = Path.Combine(newsFile, post.Token + ".html");

            var resFolder = Path.Combine(Environment.WebRootPath, "images", "news", post.Token);
            Directory.CreateDirectory(resFolder);
            var oldFiles = Directory.GetFiles(resFolder);

            var images = document.DocumentNode.SelectNodes(".//img");
            if (images != null)
            {
                using (var client = new WebClient())
                {
                    int count = 0;
                    foreach (var image in images)
                    {
                        var imageName = ResourceHelper.GenerateResourceToken(++count);
                        string newPath() => Path.Combine(resFolder, imageName);

                        var source = image.GetAttributeValue("src", null);
                        if (source is null) continue;

                        var match = Regex.Match(source, @"^data:image/([A-Za-z0-9\-]+);base64,");
                        if (match.Success)
                        {
                            var data = Convert.FromBase64String(source.Substring(match.Length));
                            imageName += "." + match.Groups[1].Value;
                            System.IO.File.WriteAllBytes(newPath(), data);
                        }
                        else if (Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out var uri))
                        {
                            var ext = System.IO.Path.GetExtension(uri.ToString());
                            imageName += ext;
                            if (string.IsNullOrWhiteSpace(ext)) goto erase;

                            if (uri.IsAbsoluteUri)
                            {
                                client.DownloadFile(uri, newPath());
                            }
                            else
                            {
                                var oldPath = Environment.WebRootPath + uri.ToString();
                                if (!System.IO.File.Exists(oldPath)) goto erase;
                                System.IO.File.Move(oldPath, newPath());
                            }
                        }
                        else
                        {
                            goto erase;
                        }

                        image.SetAttributeValue("src", $"/images/news/{post.Token}/{imageName}");
                        continue;

                        erase:
                        image.Remove();
                        continue;
                    }
                }
            }

            document.Save(newsFile);
            oldFiles.ToList().ForEach(x =>
            {
                try { System.IO.File.Delete(x); }
                catch { }
            });
        }
        [NonAction]
        protected void DeleteContent(NewsPost post)
        {
            System.IO.File.Delete(GetContentPath(post));
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

            var content = await GetContent(newsPost);
            if (content is null) { return NotFound(); }
            return View(new NewsPostDetailsViewModel(newsPost, content));
        }
    }
}
