using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Product
{
    public int Id { get; set; }

    public int? BrandId { get; set; }

    public float Price { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsLaptop { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual Brand? Brand { get; set; }

    public virtual Laptop? Laptop { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
