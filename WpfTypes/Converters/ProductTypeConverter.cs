using System;
using System.Globalization;
using System.Windows.Data;
using TheSettlersCalculator.Price;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(ProductType), typeof(string))]
	public class ProductTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch((ProductType)value)
			{
				case ProductType.BASIC:
				case ProductType.IMPROVED:
				case ProductType.ADVANCED:
				case ProductType.SKILLFUL:
					return "за 1000";
				case ProductType.QUEST:
				case ProductType.BUILDING:
				case ProductType.FILL:
					return "за 1";
			}

			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
