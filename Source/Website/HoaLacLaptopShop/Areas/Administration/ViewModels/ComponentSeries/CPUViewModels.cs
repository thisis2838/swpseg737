using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels.ComponentSeries
{
    public class CPUIndexArgs
    {
        [MinLength(2)]
        public string? Search { get; set; }
    }
    public class CPUIndexViewModel : CPUIndexArgs
    {
        public required ICollection<LaptopCPUSeries> CPUSeries { get; init; }
    }
}
