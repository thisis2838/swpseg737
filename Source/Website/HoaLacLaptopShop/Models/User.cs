using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class User
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    [Display(Name = "Password")]
    public string? PassHash { get; set; }
    public bool Gender { get; set; }
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    public UserRole Role { get; set; }

    public virtual ICollection<NewsPost> NewsPosts { get; set; } = new List<NewsPost>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}

[Flags]
public enum UserRole
{
    Sales = 1 << 0,
    Marketing = 1 << 1,
    Administrator = 1 << 2
}