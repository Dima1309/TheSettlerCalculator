using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(int), typeof(CampWinTime))]
	[ValueConversion(typeof(int), typeof(string))]
	public class CampWinTimeStringConverter : IValueConverter
	{		
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int campType = (int)value;

			if  (targetType.Equals(typeof(string)))
			{
				string result;
				switch(campType)
				{
					case (int) CampWinTime.Normal:
						result = Resources.CAMP_WIN_TIME_NORMAL;
						break;
					case (int) CampWinTime.BlackCastle:
						result = Resources.CAMP_WIN_TIME_BLACK_CASTLE;
						break;
					case (int) CampWinTime.WhiteCastle:
						result = Resources.CAMP_WIN_TIME_WHITE_CASTLE;
						break;
					case (int) CampWinTime.WitchTower:
						result = Resources.CAMP_WIN_TIME_WITCH_TOWER;
						break;
					default:
						result = Resources.CAMP_WIN_TIME_UNKNOWN;
						break;
				}

				return result;
			}
			else
			{
				return (CampWinTime) value;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string text = value as string;
			if (text != null)
			{
				if (text.Equals(Resources.CAMP_WIN_TIME_NORMAL))
				{
					return (int)CampWinTime.Normal;
				}

				if (text.Equals(Resources.CAMP_WIN_TIME_BLACK_CASTLE))
				{
					return (int)CampWinTime.BlackCastle;
				}

				if (text.Equals(Resources.CAMP_WIN_TIME_WHITE_CASTLE))
				{
					return (int)CampWinTime.WhiteCastle;
				}

				if (text.Equals(Resources.CAMP_WIN_TIME_WITCH_TOWER))
				{
					return (int)CampWinTime.WitchTower;
				}
			} else if (value is CampWinTime)
			{
				return (int) (CampWinTime) value;
			}

			return DependencyProperty.UnsetValue;
		}
	}
}
