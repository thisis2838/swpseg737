using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class Order
{
    public int ID { get; set; }
    public int? BuyerID { get; set; }
    public virtual User? Buyer { get; set; }
    public byte Status { get; set; }
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Note { get; set; }
    public DateTime CreationTime { get; set; }
    public float TotalPrice { get; set; }
    public byte PaymentMethod { get; set; }
    public int? VoucherID { get; set; }
    public virtual Voucher? Voucher { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
