using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Asset
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product? Product { get; set; }
}
