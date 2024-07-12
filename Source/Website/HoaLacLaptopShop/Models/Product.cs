using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HoaLacLaptopShop.Models;

public partial class Product
{
    public int ID { get; set; }
    [Required()]
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; } = null!;

    [Required(AllowEmptyStrings = false), MinLength(5), MaxLength(256)]
    public string Name { get; set; } = null!;
    [Required(), Range(1000, int.MaxValue)]
    public int Price { get; set; }
    [Required(), Range(1, int.MaxValue)]
    public int Stock { get; set; }
    [MaxLength(4000)]
    public string? Description { get; set; }
    [DisplayName("Has been disabled?")]
    public bool IsDisabled { get; set; }
    [DisplayName("Is a Laptop?")]

    public bool IsLaptop { get; set; }
    public virtual Laptop? Laptop { get; set; }

    [HiddenInput]
    public int ReviewCount { get; set; }
    [HiddenInput]
    public int ReviewTotal { get; set; }
    public decimal AveargeRating => ReviewCount == 0 ? 0 : decimal.Divide(ReviewTotal, ReviewCount);

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
