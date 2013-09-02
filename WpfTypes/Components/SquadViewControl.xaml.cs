using System.Windows;
using System.Windows.Controls;

namespace TheSettlersCalculator.WpfTypes.Components
{
	/// <summary>
	/// Interaction logic for SquadViewControl.xaml
	/// </summary>
	public partial class SquadViewControl : UserControl
	{
		public static readonly DependencyProperty SquadProperty = DependencyProperty.Register("Squad", typeof(UnitSquad), typeof(SquadViewControl));

		public SquadViewControl()
		{
			InitializeComponent();
		}

		public UnitSquad Squad
		{
			get { return (UnitSquad)GetValue(SquadProperty); }
			set
			{
				object oldValue = SquadProperty;
				SetValue(SquadProperty, value); 
				OnPropertyChanged(new DependencyPropertyChangedEventArgs(SquadProperty, oldValue, value));
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			Squad = DataContext as UnitSquad;
		}
	}
}
