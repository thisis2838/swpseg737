using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class Product
{
    public int ID { get; set; }
    public int? BrandId { get; set; }
    public virtual Brand? Brand { get; set; }

    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }

    public bool IsLaptop { get; set; }
    public virtual Laptop? Laptop { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
