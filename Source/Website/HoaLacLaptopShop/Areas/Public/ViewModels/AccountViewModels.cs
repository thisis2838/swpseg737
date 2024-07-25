using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{

    public class AccountDetailsViewModel
    {
        public required User Account { get; set; }
        public required PurchaseSummary PurchaseSummary { get; set; }
        public required ReviewSummary ReviewSummary { get; set; }
    }

    public class PurchaseSummary
    {
        public required int ProductsBought { get; set; }
        public required int OrdersPlaced { get; set; }
        public required int VouchersUsed { get; set; }
        public required decimal MoneySpent { get; set; }
    }

    public class ReviewSummary
    {
        public required int ProductsReviewed { get; set; }
        public required decimal AverageRating { get; set; }
    }
}
