using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(bool), typeof(Brush))]
	public class UserUnitsWarningCountBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool))
			{
				return DependencyProperty.UnsetValue;
			}

			if ((bool)value)
			{
				return new SolidColorBrush(Colors.Red);
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
