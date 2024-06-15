using HoaLacLaptopShop.Models;
using System.ComponentModel;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class BrandEntry
    {
        public Brand Brand;
        public int ProductCount;

        public BrandEntry(Brand brand, int productCount)
        {
            Brand = brand;
            ProductCount = productCount;
        }
    }

    public class ProductIndexQuery
    {
        [DisplayName("Show Laptops")]
        public bool ShowLaptops { get; set; } = true;
        [DisplayName("Show Accessories")]
        public bool ShowAccessories { get; set; } = false;
        public string? Search { get; set; } = null;
        public int? MinPrice { get; init; } = null;
        public int? MaxPrice { get; init; } = null;

        public List<int>? SelectedBrandIDs { get; set; } = null;

        public List<int>? SelectedCPUIDs { get; set; } = null;
        public List<int>? SelectedGPUIDs { get; set; } = null;
    }

    public class ProductIndexViewModel
    {
        public required List<Product> Products;
        public required List<BrandEntry> Brands;
        public required List<LaptopCPUSeries> CPUs;
        public required List<LaptopGPUSeries> GPUs;
        public required int MinPossiblePrice;
        public required int MaxPossiblePrice;

        public required ProductIndexQuery CurrentQuery = new ProductIndexQuery();
    }
}
