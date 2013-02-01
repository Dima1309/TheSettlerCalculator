using System;
using System.Globalization;
using System.Windows.Data;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Converters
{
	[ValueConversion(typeof(MultiWaveBattleType), typeof(string))]
	public class MultyWaveBattleTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch ((MultiWaveBattleType)value)
			{
				case MultiWaveBattleType.TakeWorstWave:
					return "Наихудщая результат";
				case MultiWaveBattleType.TakeAverageWave:
					return "Средний результат";
				case MultiWaveBattleType.TakeAllWaves:
					return "Сквозная симуляция";
			}

			return "Unknown";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
