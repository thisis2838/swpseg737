using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{

    public class ReviewIndexViewArgs
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [MinLength(2), MaxLength(256)]
        public string? Search { get; set; }
        [Range(0, 5)]
        public int? StarCount { get; set; }
    }

    public class ReviewIndexViewModel : ReviewIndexViewArgs
    {
        public required List<ProductReview> ProductReviews { get; set; }
        public int TotalPages { get; set; }
    }
}
