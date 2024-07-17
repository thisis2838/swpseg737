using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models
{

    public class Voucher
    {
        public int ID { get; set; }
        public int IssuerId { get; set; }
        public virtual User Issuer { get; set; } = null!;

        [Required, MaxLength(20), RegularExpression("^[ -~]+$", ErrorMessage = "Code can only be an ASCII string.")]
        public string Code { get; set; } = null!;
        [Range(0, (double)decimal.MaxValue), DisplayName("Minimum Order Price")]
        public decimal MinimumOrderPrice { get; set; }
        [Range(0, (double)decimal.MaxValue), DisplayName("Discount Value")]
        public decimal DiscountValue { get; set; }
        [DisplayName("Is Percentage Discount?")]
        public bool IsPercentageDiscount { get; set; }
        public DateOnly ExpiryDate { get; set; }
        [DisplayName("Is Deleted?")]
        public bool IsDisabled { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public decimal CalculateDiscount(decimal total)
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