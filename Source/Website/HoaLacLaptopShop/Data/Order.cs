using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Order
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public byte Status { get; set; }

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime CreationTime { get; set; }

    public float TotalPrice { get; set; }

    public byte PaymentMethod { get; set; }

    public int? VoucherId { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Voucher? Voucher { get; set; }
}
