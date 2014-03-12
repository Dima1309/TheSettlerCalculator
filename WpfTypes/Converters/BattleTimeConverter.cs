using System;
using System.Globalization;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(double), typeof(string))]
	public class BattleTimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double time = (double)value;
			return string.Format(CultureInfo.InvariantCulture, "{0:f0} {1}", time, "с.");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
