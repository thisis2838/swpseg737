﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Product
{
    public int ID { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; } = null!;

    [Required, MaxLength(256)]
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }
    [MaxLength(2048)]
    public string? Description { get; set; }
    [DisplayName("Is Disabled?")]
    public bool IsDisabled { get; set; }
    [DisplayName("Is a Laptop?")]
    public bool IsLaptop { get; set; }
    public virtual Laptop? Laptop { get; set; }

    [HiddenInput]
    public int ReviewCount { get; set; }
    [HiddenInput]
    public int ReviewTotal { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
