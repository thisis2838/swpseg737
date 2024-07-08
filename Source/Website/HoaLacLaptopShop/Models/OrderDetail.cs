using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    [DisplayName("Product Price")]
    public int ProductPrice { get; set; }
    public int SubTotal => Quantity * ProductPrice;
}
