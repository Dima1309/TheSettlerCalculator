using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Interaction logic for ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
		#region Internal class 
		public class BarData
		{
			#region Fields
			private double m_height;
			private string m_value;
			private string m_caption;
			private Brush m_color;
			#endregion

			#region Properties
			public double Height
			{
				get { return m_height; }
				set { m_height = value; }
			}

			public string Caption
			{
				get { return m_caption; }
				set { m_caption = value; }
			}

			public string Value
			{
				get { return m_value; }
				set { m_value = value; }
			}

			public Brush Color
			{
				get { return m_color; }
				set { m_color = value; }
			}
			#endregion
		}
		#endregion

		#region Fields
		private static Random s_random = new Random();
		private readonly ObservableCollection<BarData> m_data = new ObservableCollection<BarData>();
		#endregion

		public ChartWindow(BattleLosses losses)
		{
			InitializeComponent();
			foreach(KeyValuePair<double, double> battleTimeStatistic in losses.BattleTimeStatistics)
			{
				m_data.Add(new BarData()
				           	{
								Height = battleTimeStatistic.Value * 200 < 1 ? 1 : battleTimeStatistic.Value * 200,
				           		Value = string.Format(CultureInfo.InvariantCulture, "{0:f2}%", battleTimeStatistic.Value * 100),
				           		Caption = string.Format(CultureInfo.InvariantCulture, "{0:f0} сек.", battleTimeStatistic.Key),
				           		Color = new SolidColorBrush(getRandomColor())
				           	});
			}

			Title = "Время боя";
		}

		public ObservableCollection<BarData> Data
		{
			get { return m_data; }
		}

		private static Color getRandomColor()
		{
			int[] arr = new int[3];
			arr[0] = 0x80;
			arr[1] = 0xFF;
			arr[2] = s_random.Next(0x10) * 8 + 0x80;
			
			for(int i = arr.Length - 1; i >= 0; i--)
			{
				int index0 = s_random.Next(i + 1);
				int tmp = arr[index0];
				arr[index0] = arr[i];
				arr[i] = tmp;
			}

			return Color.FromRgb((byte)arr[0], (byte)arr[1], (byte)arr[2]);
		}
	}
}
