namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class CartItem
    {
        // productID
        public int ID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ThumbnailLink { get; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total => Price * Quantity;
    }
}
