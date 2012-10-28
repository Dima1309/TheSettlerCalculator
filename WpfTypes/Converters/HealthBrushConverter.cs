using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(int), typeof(Brush))]
	public class HealthBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((int)value <= 0)
			{
				SolidColorBrush brush = new SolidColorBrush(Colors.Red);
				brush.Opacity = 0.3;
				return brush;
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
