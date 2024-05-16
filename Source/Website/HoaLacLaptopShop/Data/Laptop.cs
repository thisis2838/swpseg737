using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Laptop
{
    public int ProductId { get; set; }

    public int? CpuSeries { get; set; }

    public int? GpuSeries { get; set; }

    public int ScreenSize { get; set; }

    public string ScreenResolution { get; set; } = null!;

    public string ScreenAspectRatio { get; set; } = null!;

    public string StorageType { get; set; } = null!;

    public int StorageSize { get; set; }

    public int RefreshRate { get; set; }

    public int Ram { get; set; }

    public virtual LaptopCpuseries? CpuSeriesNavigation { get; set; }

    public virtual LaptopGpuseries? GpuSeriesNavigation { get; set; }

    public virtual Product Product { get; set; } = null!;
}
