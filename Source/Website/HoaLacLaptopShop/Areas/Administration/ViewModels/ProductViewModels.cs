using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class ProductIndexViewModel : ProductIndexArgs
    {
        public List<Product> Products { get; set; } = null!;
        public int TotalCount { get; set; }
    }
    public class ProductIndexArgs
    {
        public int TargetPage { get; set; } = 1;
        public bool ShowDisabled { get; set; } = false;
    }
    public class ProductUpdateViewModel : Product
    {
        public ProductUpdateViewModel()
        {
            Laptop = new Laptop();
            IsLaptop = true;
        }
    }
}
