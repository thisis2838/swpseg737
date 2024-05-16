using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class LaptopCPUSeries
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int? ManufacturerID { get; set; }
    public virtual Brand? Manufacturer { get; set; }

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
