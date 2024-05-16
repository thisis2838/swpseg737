using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<LaptopCpuseries> LaptopCpuseries { get; set; } = new List<LaptopCpuseries>();

    public virtual ICollection<LaptopGpuseries> LaptopGpuseries { get; set; } = new List<LaptopGpuseries>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
