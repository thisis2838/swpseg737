using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class ProductIndexViewModel : ProductIndexArgs
    {
        public required List<Product> Products { get; set; } = null!;
        public required int TotalPages { get; set; }
    }
    public class ProductIndexArgs
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [MinLength(2), MaxLength(256)]
        public string? Search { get; set; }
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
