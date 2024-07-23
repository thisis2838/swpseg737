namespace HoaLacLaptopShop.Helpers
{
	public static class DateTimeHelpers
	{
		public static string ToTimeFromNow(this DateTime dateTime)
		{
			var diff = DateTime.Now - dateTime;
			string diffStr = diff >= TimeSpan.Zero ? "ago" : "ahead";

			int value; string unit;
			if (diff.TotalDays > 0)
			{
				value = (int)diff.TotalDays;
				unit = "day";
			}
			else if (diff.TotalHours > 0)
			{
				value = (int)diff.TotalHours;
				unit = "hour";
			}
			else if (diff.TotalMinutes > 0)
			{
				value = (int)diff.TotalMinutes;
				unit = "minute";
			}
			else
			{
				value = (int)diff.TotalSeconds;
				unit = "second";
			}

			return $"{value} {(value == 1 ? unit : (unit + 's'))} {diffStr}";
		}
	}
}
