using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.ViewModels
{
    public class AddProductViewModel
    {
        public Product Product { get; set; }
        public required List<Brand> Brands { get; set; }
        public List<LaptopCPUSeries> Cpus { get; set; } = null;
        public List<LaptopGPUSeries> Gpus { get; set; } = null;


    }
}
