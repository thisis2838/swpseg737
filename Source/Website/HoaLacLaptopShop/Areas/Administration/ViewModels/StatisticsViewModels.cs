using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
	public class GeneralStatsIndexArgs
	{
		public TimeRange TimeRange { get; set; } = TimeRange.LastMonth;
		public TimeSegment TimeSegment { get; set; } = TimeSegment.ByDay;
	}

	public enum TimeRange
	{
		[Display(Name = "Last Week")]
		LastWeek,
		[Display(Name = "Last Month")]
		LastMonth,
		[Display(Name = "Last Quarter")]
		LastQuarter,
		[Display(Name = "Last Year")]
		LastYear
	}
	public enum TimeSegment
	{
		[Display(Name = "By Day")]
		ByDay,
		[Display(Name = "By Week")]
		ByWeek,
		[Display(Name = "By Month")]
		ByMonth,
		[Display(Name = "By Quarter")]
		ByQuarter,
		[Display(Name = "By Year")]
		ByYear
	}

	public class GeneralStatsViewModel : GeneralStatsIndexArgs
	{
		public required Revenue GeneralRevenue { get; set; }
		public required ICollection<DatedRevenue> HistoricalStats { get; set; }
		public required ICollection<KeyValuePair<Brand, Revenue>> TopBrands { get; set; }
		public required ICollection<KeyValuePair<Product, Revenue>> TopProducts { get; set; }
	}

    public class BrandStatsViewModel : GeneralStatsIndexArgs
    {
        public required Brand Brand { get; set; }
        public required Revenue GeneralRevenue { get; set; }
        public required ICollection<DatedRevenue> HistoricalStats { get; set; }
        public required ICollection<KeyValuePair<Product, Revenue>> TopProducts { get; set; }
    }

    public class ProductStatsViewModel : GeneralStatsIndexArgs
    {
        public required Product Product { get; set; }
        public required Revenue GeneralRevenue { get; set; }
        public required ICollection<DatedRevenue> HistoricalStats { get; set; }
    }

    public class Revenue
	{
		public int NumberOfOrders { get; set; }
		public int UnitsSold { get; set; }
		public decimal TotalRevenue { get; set; }
		public int Customers { get; set; }
	}

	public class DatedRevenue
	{
		public required DateTime StartDate { get; set; }
		public required Revenue Revenue { get; set; }
	}
}
