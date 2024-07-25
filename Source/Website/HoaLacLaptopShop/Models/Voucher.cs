using Humanizer.Localisation;
using System;
using System.Collections;
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

        [
            Required, 
            MinLength(5), MaxLength(20), 
            RegularExpression
            (
                "^[A-Za-z]+[ -~]*$",
                ErrorMessage = "Code can only be an ASCII string which starts with a letter."
            )
        ]
        public string Code { get; set; } = null!;
        [Range(0, (double)decimal.MaxValue), DisplayName("Minimum Order Price")]
        public decimal MinimumOrderPrice { get; set; }
        [Range(0, (double)decimal.MaxValue), DisplayName("Discount Value")]
        [ValidDiscountValue]
        public decimal DiscountValue { get; set; }
        [DisplayName("Is Percentage Discount?")]
        public bool IsPercentageDiscount { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
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

    public class ValidDiscountValueAttribute : ValidationAttribute
    {

        public ValidDiscountValueAttribute()
        {
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var voucher = (Voucher)validationContext.ObjectInstance;

            if (value is null)
            {
                return new ValidationResult("Discount value cannot be null.");
            }
            if (voucher.IsPercentageDiscount && (decimal)value > 100)
            {
                return new ValidationResult("Discount value must be from 0 to 100 when it is set as a percentage.");
            }
            return ValidationResult.Success!;
        }
    }
}