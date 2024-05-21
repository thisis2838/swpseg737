using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.ViewModels
{
    public class ProductIndexViewModel
    {
        public required List<Product> Products;
        public ProductIndexViewArgs Arguments;

    }

    public class ProductIndexViewArgs
    {
        public string? Search { get; set; } = null;
        public int? BrandID  { get; init; } = null;
        public int? MinPrice { get; init; } = null;
        public int? MaxPrice { get; init; } = null;
        public List<Brand>? Brands { get; init; } = null;
    }
}
