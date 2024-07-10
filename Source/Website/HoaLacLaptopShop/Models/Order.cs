using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Order
{
    public int ID { get; set; }
    public int BuyerID { get; set; }
    public virtual User Buyer { get; set; } = null!;

    public DateTime OrderTime { get; set; }
    public OrderStatus Status { get; set; }

    [Required(AllowEmptyStrings = false), MinLength(5), MaxLength(256)]
    public string Province { get; set; } = null!;
    [Required(AllowEmptyStrings = false), MinLength(5), MaxLength(256)]
    public string District { get; set; } = null!;
    [Required(AllowEmptyStrings = false), MinLength(5), MaxLength(256)]
    public string Ward { get; set; } = null!;
    [Required(AllowEmptyStrings = false),MinLength(8), MaxLength(256)]
    public string Street { get; set; } = null!;
    [Required(AllowEmptyStrings = false), MinLength(2), MaxLength(256), DisplayName("Recipient Name")]
    public string RecipientName { get; set; } = null!;
    [
        Required(AllowEmptyStrings = false), 
        MaxLength(20), 
        RegularExpression("^[0-9]+$", ErrorMessage = "Phone number can only contain digits"),
        DisplayName("Recipient Phone Number")
    ]
    public string PhoneNumber { get; set; } = null!;
    [MaxLength(1024)]
    public string? Note { get; set; }

    [DisplayName("Total Price")]
    public decimal TotalPrice { get; set; }
    [DisplayName("Discounted Price")]
    public decimal DiscountedPrice { get; set; }
    [DisplayName("Payment Method"), Required]
    public PaymentMethod PaymentMethod { get; set; }
    public int? VoucherID { get; set; }
    public virtual Voucher? Voucher { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

public enum OrderStatus : byte
{
    Created,
    Delivering,
    Finished
}

public enum PaymentMethod : byte
{
    Online,
    CashOnDelivery
}
