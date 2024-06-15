using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; } = null!;
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
    }

    public class ProductDetailViewModel : Product
    {
        public ProductDetailViewModel()
        {
            Laptop = new Laptop();
            IsLaptop = false;
        }
    }
}
