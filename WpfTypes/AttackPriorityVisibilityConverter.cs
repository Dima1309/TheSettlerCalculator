using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	[ValueConversion(typeof(AttackPriority), typeof(Visibility))]
	public class AttackPriorityVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is AttackPriority) || !(parameter is string))
			{
				return DependencyProperty.UnsetValue;
			}

			if (string.Equals((string)parameter, "last", StringComparison.OrdinalIgnoreCase))
			{
				return ((AttackPriority) value) == AttackPriority.RearGuard ? Visibility.Visible : Visibility.Collapsed;
			}

			if (string.Equals((string)parameter, "first", StringComparison.OrdinalIgnoreCase))
			{
				return ((AttackPriority)value) == AttackPriority.AvantGarde ? Visibility.Visible : Visibility.Collapsed;
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
