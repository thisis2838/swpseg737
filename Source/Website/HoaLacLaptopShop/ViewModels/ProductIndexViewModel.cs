using HoaLacLaptopShop.Models;
using System.ComponentModel;

namespace HoaLacLaptopShop.ViewModels
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
        public bool ShowAccessories { get; set; } = true;
        public string? Search { get; set; } = null;
        public float? MinPrice { get; init; } = null;
        public float? MaxPrice { get; init; } = null;
        public List<int>? SelectedBrandIDs { get; set; } = null;
    }

    public class ProductIndexViewModel : ProductIndexQuery
    {
        public required List<Product> Products;
        public required List<BrandEntry> Brands;

        public required float MinPossiblePrice;
        public required float MaxPossiblePrice;

        public ProductIndexViewModel(ProductIndexQuery query)
        {
            this.ShowLaptops = query.ShowLaptops;
            this.ShowAccessories = query.ShowAccessories;
            this.Search = query.Search;
            this.MinPrice = query.MinPrice;
            this.MaxPrice = query.MaxPrice;
            this.SelectedBrandIDs = query.SelectedBrandIDs;
        }
    }
}
