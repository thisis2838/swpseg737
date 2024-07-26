using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels.ComponentSeries
{
    public class CPUIndexArgs
    {
        [MinLength(2), MaxLength(256)]
        public string? Search { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
    }
    public class CPUIndexViewModel : CPUIndexArgs
    {
        public required ICollection<LaptopCPUSeries> CPUSeries { get; init; }
        public required int TotalPages { get; set; }
    }
}
