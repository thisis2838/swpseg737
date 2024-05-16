using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Brand
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Country { get; set; } = null!;

    public virtual ICollection<LaptopCPUSeries> LaptopCPUSeries { get; set; } = new List<LaptopCPUSeries>();
    public virtual ICollection<LaptopGPUSeries> LaptopGPUSeries { get; set; } = new List<LaptopGPUSeries>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
