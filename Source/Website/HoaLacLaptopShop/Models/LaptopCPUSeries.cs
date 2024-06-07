using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class LaptopCPUSeries
{
    public int ID { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(256)]
    public string Name { get; set; } = null!;
    public int ManufacturerID { get; set; }
    public virtual Brand Manufacturer { get; set; } = null!;

    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
