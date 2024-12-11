using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class VoucherIndexArgs
    {
        [MinLength(2), MaxLength(255)]
        public string? Search { get; set; }
        [Range(0, (double)decimal.MaxValue), DisplayName("Minimum Order Price")]
        public decimal? MinimumOrderPrice { get; set; }
        public bool ShowExpired { get; set; } = true;
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
    }

    public class VoucherIndexViewModel : VoucherIndexArgs
    {
        public required ICollection<Voucher> Vouchers { get; set; }
        public required int TotalPages { get; set; }
    }
}
