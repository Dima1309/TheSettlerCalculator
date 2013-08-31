using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(double), typeof(string))]
	public class SecondsToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TimeSpan time = TimeSpan.FromSeconds((double)value);
			StringBuilder result = new StringBuilder(100);
			if (time.Days > 0)
			{
				result.Append(time.Days);
				result.Append(" ");
			}

			if (time.Hours > 0 || result.Length > 0)
			{
				result.AppendFormat("{0:00}", time.Hours);
				result.Append(":");
			}

			if (time.Minutes > 0 || result.Length > 0)
			{
				result.AppendFormat("{0:00}", time.Minutes);
				result.Append(":");
			}

			if (time.Seconds > 0 || result.Length > 0)
			{
				result.AppendFormat("{0:00}", time.Seconds);
			}

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
