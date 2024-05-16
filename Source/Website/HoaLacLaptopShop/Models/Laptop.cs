using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Laptop
{
    public int ProductID { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int? CPUSeriesID { get; set; }
    public virtual LaptopCPUSeries? CPUSeries { get; set; }
    public int? GPUSeriesID { get; set; }
    public virtual LaptopGPUSeries? GPUSeries { get; set; }

    public float ScreenSize { get; set; }
    public string ScreenResolution { get; set; } = null!;
    public string ScreenAspectRatio { get; set; } = null!;
    public byte StorageType { get; set; }
    [Range(0, float.MaxValue)]
    public float StorageSize { get; set; }
    [Range(0, float.MaxValue)]
    public float RefreshRate { get; set; }
    [Range(0, float.MaxValue)]
    public float RAM { get; set; }
}
