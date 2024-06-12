namespace HoaLacLaptopShop.ViewModels
{
	public class CartItem
	{
		// productID
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string Link { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public double Total => Price * Quantity;
	}
}
