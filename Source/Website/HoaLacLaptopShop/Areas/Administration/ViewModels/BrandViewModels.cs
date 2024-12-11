using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class BrandIndexArgs
    {
        [MinLength(2), MaxLength(255), DisplayName("Search term")]
        public string? Search { get; set; }

        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
    }

    public class BrandIndexViewModel : BrandIndexArgs
    {
        public required ICollection<Brand> Brands { get; set; }
        public required int TotalPages { get; set; }
    }
}
