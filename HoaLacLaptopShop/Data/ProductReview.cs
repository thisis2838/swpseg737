using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class ProductReview
{
    public int ProductId { get; set; }

    public int UserId { get; set; }

    public DateTime Time { get; set; }

    public short Rating { get; set; }

    public string Content { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
