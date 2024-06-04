using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public class RoledActor
{
    [DisplayName("Is Administrator?")]
    public bool IsAdmin { get; set; }
    [DisplayName("Is Marketing Staff?")]
    public bool IsMarketing { get; set; }
    [DisplayName("Is Sales Staff?")]
    public bool IsSales { get; set; }
}

public partial class User : RoledActor
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    [Display(Name = "Password")]
    public string? PassHash { get; set; }
    public bool Gender { get; set; }
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    public CustomerTier CustomerTier { get; set; } = CustomerTier.Regular;
    public virtual ICollection<NewsPost> NewsPosts { get; set; } = new List<NewsPost>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}

public enum CustomerTier
{
    Regular,
    Frequenter,
    Bronze,
    Silver,
    Gold
}