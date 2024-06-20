using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Helpers
{
    public static class ResourceHelper
    {
        public static string GenerateResourceToken(int? seed = null)
        {
            var rand = seed.HasValue ? new Random(seed.Value) : new Random();
            return $"{DateTime.Now.Ticks:X}+{rand.Next(1000, 10000):X}";
        }
        public static string GetProductImageURL(this ProductImage image)
        {
            return $"/images/products/{image.Token}.jpeg";
        }
    }
    public class VoucherRequest
    {
        public string voucherCode { get; set; }
        public decimal subTotal { get; set; }
    }
}
