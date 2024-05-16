using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class Voucher
{
    public int ID { get; set; }
    public string Code { get; set; } = null!;
    public float MinimumOrderPrice { get; set; }
    public float DiscountValue { get; set; }
    public bool IsPercentageDiscount { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public int? IssuerId { get; set; }
    public virtual User? Issuer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
