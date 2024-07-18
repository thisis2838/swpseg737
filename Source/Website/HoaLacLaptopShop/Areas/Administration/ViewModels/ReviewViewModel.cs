using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class ReviewViewModel
    {
        public List<ProductReview> ProductReviews { get; set; }
        public int TotalCount { get; set; }

        public int TargetPage { get; set; }
    }

    public class ReviewDetailViewModel
    {
        public Product Product { get; set;}
        public User User { get; set;}

        public ProductReview ProductReview { get; set;}
    }
}
