﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class User
{
    public int ID { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a username"), MaxLength(256)]
    public string Name { get; set; } = null!;
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email"), MaxLength(256)]
    public string Email { get; set; } = null!;
    [Display(Name = "Password"), MaxLength(256)]
    public string? PassHash { get; set; }
    public bool Gender { get; set; }
    [
        Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a phone number"),
        RegularExpression("^0[98753][0-9]{8,9}$", ErrorMessage = "Phone number must be between 10-11 digits."),
        DisplayName("Phone Number")
    ]
    public string PhoneNumber { get; set; } = null!;


    [DisplayName("Is Administrator?")]
    public bool IsAdmin { get; set; }
    [DisplayName("Is Marketing Staff?")]
    public bool IsMarketing { get; set; }
    [DisplayName("Is Sales Staff?")]
    public bool IsSales { get; set; }
    [DisplayName("Is Disabled?")]
    public bool IsDisabled { get; set; }

    public virtual ICollection<NewsPost> NewsPosts { get; set; } = new List<NewsPost>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
