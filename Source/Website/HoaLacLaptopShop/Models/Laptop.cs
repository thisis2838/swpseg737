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
    [DisplayName("CPU Series")]
    public virtual LaptopCPUSeries CPUSeries { get; set; } = null!;
    public int GPUSeriesID { get; set; }
    [DisplayName("GPU Series")]
    public virtual LaptopGPUSeries GPUSeries { get; set; } = null!;

    [
        Required, 
        DisplayName("Screen Size"),
        Range(0, float.MaxValue)
    ]
    public float ScreenSize { get; set; }
    [
        Required,
        DisplayName("Screen Resolution"),
        RegularExpression
        (
            "^[0-9]{3,4}x[0-9]{3,4}$", 
            ErrorMessage = "Screen Resolution must be in the form of <width>x<height>, where the dimensions are in pixels."
        )
    ]
    public string ScreenResolution { get; set; } = null!;
    [
        Required,
        DisplayName("Screen Aspect Ratio"),
        RegularExpression
        (
            "^[0-9.]{1,5}:[0-9.]{1,5}$",
            ErrorMessage = "Screen Aspect Ratio must be in the form of <width>:<height>, where divisor and the dividend are decimals."
        )
    ]
    public string ScreenAspectRatio { get; set; } = null!;

    [
        Required,
        DisplayName("Storage Type")
    ]
    public LaptopStorageType StorageType { get; set; }
    [
        Required,
        DisplayName("Storage Size"),
        Range(0, int.MaxValue)
    ]
    public int StorageSize { get; set; }
    [
        Required,
        DisplayName("Refresh Rate"),
        Range(0, int.MaxValue)
    ]
    public int RefreshRate { get; set; }
    [
        Required,
        DisplayName("RAM"),
        Range(0, int.MaxValue)
    ]
    public int RAM { get; set; }
}

public enum LaptopStorageType : byte
{
    HDD,
    SSD
}

