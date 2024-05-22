namespace HoaLacLaptopShop.ViewModels
{
    public class CheckoutVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
