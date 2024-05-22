using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Helpers
{
    public static class ResourceHelper
    {
        public static string GetProductImageURL(this ProductImage image)
        {
            return $"/images/product/{image.Token}.jpeg";
        }
    }
}
