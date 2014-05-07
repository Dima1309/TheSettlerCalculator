using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(String), typeof(String))]
	public class ResourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string str = value as string;
			return Helper.Helper.getResourceText(str);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
