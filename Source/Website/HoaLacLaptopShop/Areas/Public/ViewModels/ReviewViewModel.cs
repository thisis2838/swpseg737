using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{

    public class ReviewHistoryViewArgs
    {
        [Range(0, 5)]
        public int? StarCount { get; set; } = 0;
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [MinLength(2), MaxLength(256)]
        public string? Search { get; set; }
    }

    public class ReviewHistoryViewModel : ReviewHistoryViewArgs
    {
        public List<ProductReview> ProductReviews { get; set; } = null!;
        public required int TotalPages { get; set; }
    }
}
