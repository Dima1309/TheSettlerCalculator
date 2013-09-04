using System.Windows;
using System.Windows.Controls;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes.Components
{
	/// <summary>
	/// Interaction logic for UnitViewControl.xaml
	/// </summary>
	public partial class UnitViewControl : UserControl
	{
		public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(Unit), typeof(UnitViewControl));

		public UnitViewControl()
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
