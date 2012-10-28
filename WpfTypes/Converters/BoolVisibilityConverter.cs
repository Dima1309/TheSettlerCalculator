﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class BoolVisibilityConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool))
			{
				return DependencyProperty.UnsetValue;
			}

			return (bool) value ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
