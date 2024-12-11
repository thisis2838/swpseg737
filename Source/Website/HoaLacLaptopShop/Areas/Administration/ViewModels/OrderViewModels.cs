using HoaLacLaptopShop.Areas.Public.ViewModels;
using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{

    public class OrderIndexViewArgs
    {
        [MinLength(2), MaxLength(256), DisplayName("Product Search")]
        public string? ProductSearch { get; set; }
        [MinLength(2), MaxLength(256), DisplayName("Destination Search")]
        public string? DestinationSearch { get; set; }
        [MinLength(2), MaxLength(256), DisplayName("Recipient Search")]
        public string? RecipientSearch { get; set; }

        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        public SelectableOrderStatus Status { get; set; } = SelectableOrderStatus.Delivering;
    }

    public class OrderIndexViewModel : OrderIndexViewArgs
    {
        public required List<Order> Orders { get; set; }
        public required int TotalPages { get; set; }
    }
}
