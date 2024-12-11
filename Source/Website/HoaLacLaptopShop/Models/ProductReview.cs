using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class ProductReview
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int ReviewerId { get; set; }
    public virtual User Reviewer { get; set; } = null!;

    [Range(0, 5)]
    public int Rating { get; set; }
    [Required, MaxLength(1024)]
    public string Content { get; set; } = null!;
    public DateTime ReviewTime { get; set; }
}
