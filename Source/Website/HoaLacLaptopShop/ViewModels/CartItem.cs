namespace HoaLacLaptopShop.ViewModels
{
	public class CartItem
	{
		// productID
		public int id { get; set; }
		public string productName { get; set; }
		public string link { get; set; }
		public double price { get; set; }
		public int quantity { get; set; }
		public double total => price * quantity;
	}
}
