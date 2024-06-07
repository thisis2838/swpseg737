using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Helpers
{
    public static class ResourceHelper
    {
        public static string GetProductImageURL(this ProductImage image)
        {
            return $"/images/products/{image.Token}.jpeg";
        }
    }
    public class VoucherRequest
    {
        public string VoucherCode { get; set; }
        public decimal Subtotal { get; set; }
    }
}
