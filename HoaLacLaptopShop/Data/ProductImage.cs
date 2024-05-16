using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class ProductImage
{
    public int ProductId { get; set; }

    public int ImageIndex { get; set; }

    public string Link { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
