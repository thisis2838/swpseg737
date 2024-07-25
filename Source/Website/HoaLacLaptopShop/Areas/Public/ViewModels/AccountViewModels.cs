using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
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
    public class AccountDetailsViewModel
    {
        public required User Account { get; set; }
        public required PurchaseSummary PurchaseSummary { get; set; }
        public required ReviewSummary ReviewSummary { get; set; }
    }

    // HACKHACK: we don't allow users to select Created orders since those are for internal use.
    public enum SelectableOrderStatus : byte
    {
        Delivering = OrderStatus.Delivering,
        Finished
    }
    public class OrderHistoryViewArgs
    {
        public SelectableOrderStatus Status { get; set; } = SelectableOrderStatus.Delivering;
        [MinLength(2), MaxLength(256)]
        public string? Search { get; set; }
    }
    public class OrderHistoryViewModel : OrderHistoryViewArgs
    {
        public required ICollection<Order> Orders { get; set; }
    }
}
