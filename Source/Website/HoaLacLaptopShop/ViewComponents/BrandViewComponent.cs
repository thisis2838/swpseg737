using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly HoaLacLaptopShopContext _db;

        public BrandViewComponent(HoaLacLaptopShopContext context)
        {
            _db = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _db.Brands.Select(b => new BrandVM
            {
                Id = b.ID,
                Name = b.Name,
                Quantity = b.Products.Count()
            });

            return View(data);
        }
    }
}
