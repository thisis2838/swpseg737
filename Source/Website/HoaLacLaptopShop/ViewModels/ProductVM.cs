

using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public Brand Brand { get; set; }
        public List<ProductReview> ProductReview { get; set; }
        public List<ProductVM> RelatedProducts {  get; set; }
        public List<string> Link { get; set; }
    }
}
