using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(CampType), typeof(String))]
	public class CampTypeStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			CampType campType = (CampType)value;

			String result;
			switch (campType)
			{
				case CampType.Normal:
					result = Resources.CAMP_TYPE_NORMAL;
					break;
				case CampType.Boss:
					result = Resources.CAMP_TYPE_BOSS;
					break;
				case CampType.Ambush:
					result = Resources.CAMP_TYPE_AMBUSH;
					break;
				default:
					result = Resources.CAMP_TYPE_UNKNOWN;
					break;
			}

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text != null)
			{
				if (text.Equals(Resources.CAMP_TYPE_NORMAL))
				{
					return CampType.Normal;
				}

				if (text.Equals(Resources.CAMP_TYPE_AMBUSH))
				{
					return CampType.Ambush;
				}

				if (text.Equals(Resources.CAMP_TYPE_BOSS))
				{
					return CampType.Boss;
				}
			}

			return DependencyProperty.UnsetValue;
		}
	}
}
