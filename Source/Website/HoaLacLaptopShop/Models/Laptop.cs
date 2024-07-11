using HoaLacLaptopShop.Attribute;
using HoaLacLaptopShop.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Laptop
{
    public int ProductID { get; set; }
    public virtual Product? Product { get; set; } = null!;
    public int CPUSeriesID { get; set; }
    public virtual LaptopCPUSeries CPUSeries { get; set; } = null!;
    public int GPUSeriesID { get; set; }
    public virtual LaptopGPUSeries GPUSeries { get; set; } = null!;

    [Range(0, float.MaxValue), DisplayName("Screen Size")]
    [ValidScreenSize]
    public float ScreenSize { get; set; }
    [DisplayName("Screen Resolution")]
    [ValidScreenResolution]
    public string ScreenResolution { get; set; }
    [DisplayName("Screen Aspect Ratio")]
    public string? ScreenAspectRatio { get; set; }


    public LaptopStorageType StorageType { get; set; }
    [ValidStorageSize]
    public int StorageSize { get; set; }
    [ValidRefreshRate]
    public int RefreshRate { get; set; }
    [ValidRam]
    public int RAM { get; set; }
}

public enum LaptopStorageType : byte
{
    HDD,
    SSD
}

