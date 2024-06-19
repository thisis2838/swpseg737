using NuGet.Packaging.Signing;
using System;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models
{
    public class Voucher
    {
<<<<<<< Updated upstream
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Range(0, double.MaxValue)]
        public decimal MinimumOrderPrice { get; set; }
        [Range(0, double.MaxValue)]
        public decimal DiscountValue { get; set; }
        public bool IsPercentageDiscount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int IssuerId { get; set; }
        public virtual User? Issuer { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public decimal CalculateDiscount(decimal total)
=======
       

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Range(0, double.MaxValue)]
        public float MinimumOrderPrice { get; set; }
        [Range(0, double.MaxValue)]
        public float DiscountValue { get; set; }
        public bool IsPercentageDiscount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int IssuerId { get; set; }
        
        public virtual User? Issuer { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public float CalculateDiscount(float total)
>>>>>>> Stashed changes
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