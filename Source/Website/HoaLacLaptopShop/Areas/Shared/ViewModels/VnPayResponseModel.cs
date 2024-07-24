namespace HoaLacLaptopShop.Areas.Shared.ViewModels
{
	public class VnPayResponseModel
	{
		public bool Success { get; set; }
		public string PaymentMethod { get; set; } = null!;
		public string OrderDescription { get; set; } = null!;
        public string OrderId { get; set; } = null!;
        public string PaymentId { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
		public string Token { get; set; } = null!;
		//public string TxnRef {  get; set; }
		public string VnPayResponseCode { get; set; } = null!;

	}

	public class VnPayRequestModel
	{
		public int OrderId { get; set; }
		public string Description { get; set; } = null!;
        public double Amount { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
