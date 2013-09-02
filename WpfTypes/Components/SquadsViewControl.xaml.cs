using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TheSettlersCalculator.WpfTypes.Components
{
	/// <summary>
	/// Interaction logic for SquadsControl.xaml
	/// </summary>
	public partial class SquadsViewControl : UserControl
	{
		public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("Squads", typeof(ObservableCollection<UnitSquad>), typeof(SquadsViewControl));

		public SquadsViewControl()
		{
			InitializeComponent();
		}

		public ObservableCollection<UnitSquad> Squads
		{
			get { return (ObservableCollection<UnitSquad>) GetValue(MaxValueProperty); }
			set { SetValue(MaxValueProperty, value); }
		}
	}
}
