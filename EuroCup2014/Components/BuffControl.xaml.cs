using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheSettlersCalculator.EuroCup2014.Components
{
	/// <summary>
	/// Логика взаимодействия для BuffControl.xaml
	/// </summary>
	public partial class BuffControl : UserControl
	{
		public static readonly DependencyProperty BuffProperty = DependencyProperty.Register("Buff", typeof(Buff), typeof(BuffControl));

		public BuffControl()
		{
			InitializeComponent();
		}

		public Buff Buff
		{
			get { return (Buff)GetValue(BuffProperty); }
			set { SetValue(BuffProperty, value); }
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (Buff == null && DataContext is Buff)
			{
				Buff = DataContext as Buff;
			}
		}
	}
}
