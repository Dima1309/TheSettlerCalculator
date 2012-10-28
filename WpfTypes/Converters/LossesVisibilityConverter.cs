using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	public class LossesVisibilityConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			Visibility result = Visibility.Collapsed;
			foreach(object obj in values)
			{
				ICollection list = obj as ICollection;
				if (list == null)
				{
					continue;
				}

				if (list.Count > 0)
				{
					result = Visibility.Visible;
					break;
				}
			}

			return result;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
