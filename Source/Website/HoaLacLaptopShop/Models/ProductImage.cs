using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class ProductImage
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int DisplayIndex { get; set; }
    public string Token { get; set; } = null!;
}
