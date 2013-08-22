using System.Windows;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        #region Fields
        private readonly MainWindowModel m_model = new MainWindowModel();
        #endregion

        public MainWindow()
		{
			InitializeComponent();        	
		}

		public MainWindowModel Model
		{
			get { return m_model; }
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			QuestMapWindow questMapWindow = new QuestMapWindow(Model.ActiveQuest, Model.ActiveQuestCamps);
			bool? result = questMapWindow.ShowDialog();
			if (result.HasValue && result.Value)
			{
				Model.ActiveEnemyCamp = questMapWindow.SelectedCamp;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			m_model.Calculate();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Price.Price.Save();
		}

		private void Win_Closed(object sender, System.EventArgs e)
		{
			Quests.Quests.Save();
		}
    }
}
