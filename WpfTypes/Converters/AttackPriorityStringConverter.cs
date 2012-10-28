using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(AttackPriority), typeof(Visibility))]
	public class AttackPriorityStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is AttackPriority))
			{
				return DependencyProperty.UnsetValue;
			}

			switch ((AttackPriority)value)
			{
				case AttackPriority.AvantGarde:
					return "Быстрые отряды";
				case AttackPriority.Normal:
					return "Обычные отряды";
				case AttackPriority.RearGuard:
					return "Медленные отряды";
				default:
					break;
			}

			return DependencyProperty.UnsetValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
