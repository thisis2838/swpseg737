using AngleSharp.Text;
using Ganss.Xss;
using HoaLacLaptopShop.Areas.Shared.ViewModels;
using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Filters;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.Services;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PreMailer.Net;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Memory;
using System.Net;
using System.Text.RegularExpressions;

namespace HoaLacLaptopShop.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Marketing")]
    public class NewsPostsController : Public.Controllers.NewsPostsController
    {
        private readonly ITemporaryResourceService _temp;
        private readonly ILogger<NewsPostsController> _logger;
        public NewsPostsController
        (
            HoaLacLaptopShopContext context,
            ILocalResourceService local,
            ITemporaryResourceService temp,
            ILogger<NewsPostsController> logger
        )
        : base(context, local)
        {
            _temp = temp;
            _logger = logger;
        }

        [NonAction]
        protected bool SaveContent(NewsPostDetailsViewModel post)
        {
            post.Content = PreMailer.Net.PreMailer.MoveCssInline(post.Content).Html;

            var sanitizer = new HtmlSanitizer();
            sanitizer.AllowDataAttributes = true;
            sanitizer.AllowedTags.Remove("head");
            sanitizer.AllowedTags.Remove("body");
            sanitizer.AllowedTags.Remove("input");
            sanitizer.AllowedTags.Remove("option");
            sanitizer.AllowedTags.Remove("select");
            sanitizer.AllowedTags.Remove("button");
            sanitizer.AllowedAttributes.Add("temp_res_id");
            sanitizer.AllowedSchemes.Add("data");
            post.Content = sanitizer.Sanitize(post.Content ?? "");

            var mediaPath = Local.GetRelativePath(ResourceType.Images, "news", post.Token);
            Local.DirectoryCreate(mediaPath);
            List<string> oldMedia = Local.DirectoryFiles(mediaPath).ToList();

            _temp.VerifyAll("news");
            var document = new HtmlDocument(); document.LoadHtml(post.Content);

            var images = document.DocumentNode.SelectNodes(".//img");
            bool imagesBad = false;
            if (images != null)
            {
                foreach (var image in images)
                {
                    var source = image.GetAttributeValue("src", null);
                    if (source is null)
                    {
                        this.AddWarning("An image was removed as it had no source. Please reupload that image.");
                    }
                    else
                    {
                        var tempID = image.GetAttributeValue("temp_res_id", null);
                        if (tempID != null)
                        {
                            image.Attributes.Remove("temp_res_id");
                            var resource = _temp.Get(tempID);
                            if (_temp.Verify(tempID))
                            {
                                var newPath = _temp.Move(tempID, mediaPath);
                                image.SetAttributeValue("src", newPath.Replace('\\', '/'));
                                continue;
                            }
                            this.AddError("An image was removed as it used an uploaded image which was not found. Please reupload that image.");
                        }
                        else if (Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out var uri))
                        {
                            if (!uri.IsAbsoluteUri)
                            {
                                var file = Local.GetRelativePath(uri.ToString());
                                if (!Local.FileExists(file))
                                {
                                    this.AddError("An image was removed as it used a local file which was not found. Please reupload that image.");
                                }
                                else
                                {
                                    oldMedia.RemoveAll(x => x.Equals(file, StringComparison.InvariantCultureIgnoreCase));
                                    continue;
                                }
                            }
                            else
                            {
                                this.AddError("Images from external sources are not allowed. Please upload them manually.");
                            }
                        }
                        else
                        {
                            this.AddWarning("An image was removed as it had an invalid source. Please reupload that image.");
                        }
                    }
                    
                    imagesBad = true;
                    image.Remove();
                    continue;
                }
            }
            post.Content = document.DocumentNode.OuterHtml;
            if (imagesBad == true) return false;

            post.ImageCount = images?.Count ?? 0;
            if (post.ImageCount > 20)
            {
                this.AddError("A news post must not have more than 20 images");
                return false;
            }

            var text = document.DocumentNode.SelectNodes(".//text()")?.
                Select(x => WebUtility.HtmlDecode(x.InnerText)) 
                ?? Enumerable.Empty<string>();
            var charCount = text.Sum(x => x.Length);
            if (charCount > 50000)
            {
                this.AddError("A news post cannot have more than 50000 characters");
                return false;
            }
            post.WordCount = text.SelectMany(x => Regex.Split(x, @"[\s\W]+")).Count();
            if (post.WordCount <= 10)
            {
                this.AddError("A news post must have more than 10 words");
                return false;
            }
            post.ReadingTime = (int)Math.Ceiling(post.WordCount / 265m + post.ImageCount * (1/6m));

            oldMedia.ForEach(Local.FileRemove);
            using var finalFile = Local.FileOpen(Local.GetRelativePath(ResourceType.Html, "news", post.Token + ".html"));
            document.Save(finalFile);
            return true;
        }
        [NonAction]
        protected void DeleteContent(NewsPost post)
        {
            Local.FileRemove(GetContentPath(post));
            Local.DirectoryRemove(GetImagesFolder(post));
        }

        [HttpPost, RequestFormLimits(ValueLengthLimit = 2 * 1000 * 1000)]
        public IActionResult UploadImage(IFormFile file)
        {
            JsonResult bad(string issue)
            {
                return Json(new
                {
                    success = false,
                    issue = issue,
                    id = "",
                    path = ""
                });
            }
            JsonResult good(string id, string path)
            {
                return Json(new
                {
                    success = true,
                    issue = "",
                    id,
                    path
                });
            }

            if (file is null)
            {
                return bad("File was lost in transport.");
            }
            if (file.Length > 1 * 1000 * 1000)
            {
                return bad("Image size must not be over 1 megabytes.");
            }

            try
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    if (image.Height < 100) return bad("Image height must not be under 100 pixels.");
                    if (image.Width < 100) return bad("Image width must not be under 100 pixels.");
                    if (image.Height > 4000) return bad("Image height must not be over 4000 pixels.");
                    if (image.Width > 4000) return bad("Image width must not be over 4000 pixels.");

                    using (var memory = new MemoryStream())
                    {
                        image.SaveAsJpeg(memory);
                        memory.Seek(0, SeekOrigin.Begin);
                        var temp = _temp.Add(memory, "news", ".jpeg");
                        return good(temp.ID, _temp.GetRelativePath(temp).Replace('\\', '/'));
                    }
                }
            }
            catch (UnknownImageFormatException)
            {
                return bad("Unknown image format.");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(ValueLengthLimit = 2 * 1000 * 1000)]
        [ModelStateInclude(nameof(NewsPostDetailsViewModel.Title))]
        public async Task<IActionResult> Create([FromForm][Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            if (ModelState.IsValid)
            {
                newsPost.Time = DateTime.Now;
                newsPost.AuthorId = HttpContext.GetCurrentUser()!.ID;
                newsPost.Token = ResourceHelper.GenerateResourceToken();
                if (!SaveContent(newsPost))
                {
                    return View(newsPost);
                } 

                Context.Add(newsPost);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            _temp.RemoveAll("news");
            var content = GetContent(newsPost);
            var vm = new NewsPostDetailsViewModel() { Content = content }; vm.FillFromOther(newsPost);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(ValueLengthLimit = 100 * 1000 * 1000)]
        [ModelStateInclude(nameof(NewsPostDetailsViewModel.Title))]
        public async Task<IActionResult> Edit(int? id, [FromForm][Bind("ID,Title,Content")] NewsPostDetailsViewModel newsPost)
        {
            if (id != newsPost.ID) return NotFound();
            var targetPost = await Context.NewsPosts.FindAsync(id);
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
                    targetPost.Time = DateTime.Now;
                    newsPost.FillFromOther(targetPost);
                    if (!SaveContent(newsPost))
                    {
                        return View(newsPost);
                    }
                    targetPost.FillFromOther(newsPost);

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
