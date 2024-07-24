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

	public abstract class StatsViewModel : GeneralStatsIndexArgs
	{
        public required SaleStatistics GeneralStats { get; set; }
        public required ICollection<DatedStatistics> HistoricalStats { get; set; }
    }

    public class GeneralStatsViewModel : StatsViewModel
    {
		public required ICollection<KeyValuePair<Brand, SaleStatistics>> TopBrands { get; set; }
		public required ICollection<KeyValuePair<Product, SaleStatistics>> TopProducts { get; set; }
	}

    public class BrandStatsViewModel : StatsViewModel
    {
        public required Brand Brand { get; set; }
        public required ICollection<KeyValuePair<Product, SaleStatistics>> TopProducts { get; set; }
    }

    public class ProductStatsViewModel : StatsViewModel
    {
        public required Product Product { get; set; }
    }

    public class SaleStatistics
	{
		public decimal? TotalRevenue { get; set; } = 0;
        public decimal GrossSales { get; set; }
        public int NumberOfOrders { get; set; }
		public int UnitsSold { get; set; }
		public int Customers { get; set; }
	}
	public class DatedStatistics
	{
		public required DateTime StartDate { get; set; }
		public required SaleStatistics Statistics { get; set; }
	}
}
