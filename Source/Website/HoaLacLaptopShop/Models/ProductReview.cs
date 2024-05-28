using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class ProductReview
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int ReviewerId { get; set; }
    public virtual User Reviewer { get; set; } = null!;

    public int Rating { get; set; }
    public string Content { get; set; } = null!;
    public DateTime Time { get; set; }
}
