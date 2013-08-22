using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(CampType), typeof(Brush))]
	public class CampTypeBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			CampType campType = (CampType)value;

			Color color;
			switch(campType)
			{
				case CampType.Normal:
					color = Colors.White;
					break;
				case CampType.Boss:
					color = Colors.Red;
					break;
				case CampType.Ambush:
					color = Colors.Yellow;
					break;
				default:
					color = Colors.Transparent;
					break;
			}

			SolidColorBrush brush = new SolidColorBrush(color);
			brush.Opacity = 0.3;

			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			SolidColorBrush brush = value as SolidColorBrush;
			if (brush != null)
			{
				if(brush.Color == Colors.White)
				{
					return CampType.Normal;
				} 

				if(brush.Color == Colors.Yellow)
				{
					return CampType.Ambush;
				}

				if (brush.Color == Colors.Red)
				{
					return CampType.Boss;
				}
			}

			return DependencyProperty.UnsetValue;
		}
	}
}

