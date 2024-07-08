using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class Laptop
{
    public int ProductID { get; set; }
    public virtual Product Product { get; set; } = null!;
    public int CPUSeriesID { get; set; }
    public virtual LaptopCPUSeries CPUSeries { get; set; } = null!;
    public int GPUSeriesID { get; set; }
    public virtual LaptopGPUSeries GPUSeries { get; set; } = null!;

    [Range(0, float.MaxValue), DisplayName("Screen Size")]
    public float ScreenSize { get; set; }
    [
        Required, 
        MaxLength(20),
        RegularExpression("^[ -~]+$", ErrorMessage = "Screen resolution can only be an ASCII string."),
        DisplayName("Screen Resolution")
    ]
    public string ScreenResolution { get; set; } = null!;
    [
        Required, 
        MaxLength(20), 
        RegularExpression("^[ -~]+$", ErrorMessage = "Screen aspect ratio can only be an ASCII string."),
        DisplayName("Screen Aspect Ratio")
    ]
    public string ScreenAspectRatio { get; set; } = null!;

    public LaptopStorageType StorageType { get; set; }
    [Range(0, int.MaxValue)]
    public int StorageSize { get; set; }
    [Range(0, int.MaxValue)]
    public int RefreshRate { get; set; }
    [Range(0, int.MaxValue)]
    public int RAM { get; set; }
}

public enum LaptopStorageType : byte
{
    HDD,
    SSD
}
