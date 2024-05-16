using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class Laptop
{
    public int ProductId { get; set; }

    public int? CpuSeries { get; set; }

    public int? GpuSeries { get; set; }

    public float ScreenSize { get; set; }

    public string ScreenResolution { get; set; } = null!;

    public string ScreenAspectRatio { get; set; } = null!;

    public byte StorageType { get; set; }

    public float StorageSize { get; set; }

    public float RefreshRate { get; set; }

    public float Ram { get; set; }

    public virtual LaptopCpuseries? CpuSeriesNavigation { get; set; }

    public virtual LaptopGpuseries? GpuSeriesNavigation { get; set; }

    public virtual Product Product { get; set; } = null!;
}
