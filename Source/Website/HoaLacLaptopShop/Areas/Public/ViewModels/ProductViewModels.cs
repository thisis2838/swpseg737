using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public class ProductIndexViewArgs
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

        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
    }

    public class ProductIndexViewModel : ProductIndexViewArgs
    {
        public required List<Product> Products { get; set; }
        public required int TotalPages { get; set; }
    }
}
