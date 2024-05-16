using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int Amount { get; set; }
}
