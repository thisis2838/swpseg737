using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Brand
{
    public int ID { get; set; }

    [Required, MaxLength(256)]
    public string Name { get; set; } = null!;
    [MaxLength(1024)]
    public string Description { get; set; } = null!;
    [MaxLength(256)]
    public string Country { get; set; } = null!;

    public virtual ICollection<LaptopCPUSeries> LaptopCPUSeries { get; set; } = new List<LaptopCPUSeries>();
    public virtual ICollection<LaptopGPUSeries> LaptopGPUSeries { get; set; } = new List<LaptopGPUSeries>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
