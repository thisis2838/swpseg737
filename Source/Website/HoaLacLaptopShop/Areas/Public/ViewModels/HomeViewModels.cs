using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class HomeViewModel
    {
        public required List<Product> PopularLaptops { get; init; }
        public required List<Product> PopularAccessories { get; init; }
        public required Dictionary<Brand, List<Product>> ProductsByBrand { get; init; }
        public required List<NewsPost> LatestNews { get; init; }
    }
}
