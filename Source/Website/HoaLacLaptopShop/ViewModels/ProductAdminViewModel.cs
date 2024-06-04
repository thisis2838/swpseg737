using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.ViewModels
{
    public class ProductAdminViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalCount { get; set; }

        public int PageIndex { get; set; }
    }
}
