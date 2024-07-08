using NuGet.Packaging.Signing;
using System;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models
{
    public class Voucher
    {


        public int ID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Code { get; set; } = null!;
        public float MinimumOrderPrice { get; set; }
        public float DiscountValue { get; set; }
        public bool IsPercentageDiscount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? IssuerId { get; set; }
        public virtual User? Issuer { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public float CalculateDiscount(float total)
        {
            if (total < MinimumOrderPrice)
            {
                return 0;
            }

            if (IsPercentageDiscount)
            {
                return total * (DiscountValue / 100);
            }
            else
            {
                return DiscountValue;
            }
        }

    }

}