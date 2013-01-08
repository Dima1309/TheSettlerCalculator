using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(int), typeof(bool))]
	public class WaveIndexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is int) || !(parameter is string))
			{
				return DependencyProperty.UnsetValue;
			}

			return value.ToString().Equals(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value && parameter != null)
			{
				return int.Parse(parameter as string);
			}

			return DependencyProperty.UnsetValue;
		}
	}
}
