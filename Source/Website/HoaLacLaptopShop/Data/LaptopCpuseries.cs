using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class LaptopCpuseries
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ManufacturerId { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();

    public virtual Brand? Manufacturer { get; set; }
}
