using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Interaction logic for QuestMapWindow.xaml
	/// </summary>
	public partial class QuestMapWindow : Window
	{
		#region Fields
		private readonly Quest m_model;
		private readonly Collection<EnemyCamp> m_camps;
		private EnemyCamp m_selectedCamp;
		#endregion

		public QuestMapWindow(Quest quest, Collection<EnemyCamp> camps)
		{
			m_model = quest;
			m_camps = camps;

			InitializeComponent();				
		}

		public Quest Model
		{
			get { return m_model; }
		}

		public EnemyCamp SelectedCamp
		{
			get { return m_selectedCamp; }
		}

		private void Win_Loaded(object sender, RoutedEventArgs e)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(MapImage);

			foreach (EnemyCamp camp in m_camps)
			{
				SimpleSquareAdorner adorner = new SimpleSquareAdorner(MapImage, camp);
				adorner.DataContext = Model;
				adorner.MouseUp += adorner_MouseUp;
				
				adornerLayer.Add(adorner);
			}
		}

		void adorner_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			SimpleSquareAdorner simpleSquareAdorner = sender as SimpleSquareAdorner;
			if (simpleSquareAdorner != null)
			{
				m_selectedCamp = simpleSquareAdorner.Camp;
				DialogResult = true;
				Close();
			}
		}
	}
}
