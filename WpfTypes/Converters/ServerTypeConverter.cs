using System;
using System.Globalization;
using System.Windows.Data;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(ServerType), typeof(string))]
	public class ServerTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((ServerType)value)
			{
				case ServerType.RU1:
					return "Тандрия";
				case ServerType.RU2:
					return "Эвеланс";
			}

			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
