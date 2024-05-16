using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class ProductReview
{
    public int ProductId { get; set; }

    public int ReviewerId { get; set; }

    public int Rating { get; set; }

    public string Content { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User Reviewer { get; set; } = null!;
}
