using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Order
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? AssetId { get; set; }

    public short Status { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreationTime { get; set; }

    public float TotalPrice { get; set; }

    public bool PaymentMethod { get; set; }

    public int? VoucherId { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
