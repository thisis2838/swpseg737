using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels.ComponentSeries
{
    public class GPUIndexArgs
    {
        [MinLength(2)]
        public string? Search;
    }
    public class GPUIndexViewModel : GPUIndexArgs
    {
        public required ICollection<LaptopGPUSeries> GPUSeries { get; init; }
    }
}
