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

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
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
    }
}