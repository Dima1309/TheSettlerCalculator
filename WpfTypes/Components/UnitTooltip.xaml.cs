using System.Windows;
using System.Windows.Controls;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Components
{
	/// <summary>
	/// Interaction logic for UnitTooltip.xaml
	/// </summary>
	public partial class UnitTooltip : UserControl
	{
		public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(Unit), typeof(UnitTooltip));

		public UnitTooltip()
		{
			InitializeComponent();
		}

		public Unit Unit
		{
			get { return (Unit) GetValue(UnitProperty); }
			set { SetValue(UnitProperty, value); }
		}
	}
}
