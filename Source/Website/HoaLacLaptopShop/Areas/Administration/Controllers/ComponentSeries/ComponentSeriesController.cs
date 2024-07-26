using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HoaLacLaptopShop.Areas.Administration.Controllers.ComponentSeries
{
    public abstract class ComponentSeriesController : Controller
    {
        protected const int COMPONENTS_PER_PAGE = 20;

        protected HoaLacLaptopShopContext Context { get; init; }
        public ComponentSeriesController(HoaLacLaptopShopContext context)
        {
            Context = context;
        }

        [NonAction]
        protected async Task InitializeBrandSelection()
        {
            ViewBag.Manufacturers = new SelectList(await Context.Brands.ToListAsync(), nameof(Brand.ID), nameof(Brand.Name));
        }
    }
}
