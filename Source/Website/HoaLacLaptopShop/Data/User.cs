using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PassHash { get; set; }

    public bool Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public byte Role { get; set; }

    public virtual ICollection<NewsPost> NewsPosts { get; set; } = new List<NewsPost>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
