using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(double), typeof(bool))]
	public class TowerBonusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is double) || !(parameter is string))
			{
				return DependencyProperty.UnsetValue;
			}

			double doubleValue = (double) value;
			return (doubleValue * 100).ToString(CultureInfo.InvariantCulture).Equals(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if((bool) value && parameter != null)
			{
				return double.Parse(parameter as string) / 100;
			}

			return DependencyProperty.UnsetValue;
		}
	}
}
