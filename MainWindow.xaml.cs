using System.IO;
using System.Windows;
using System.Windows.Controls;
using TheSettlersCalculator.Specialists.Generals;
using TheSettlersCalculator.Types;
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

		private void Button_MapClick(object sender, RoutedEventArgs e)
		{
			if (Model.ActiveQuest.Map == null)
			{
				if (!File.Exists(Model.ActiveQuest.MapPath))
				{
					DownloadWindow downloadWindow = new DownloadWindow(Model.ActiveQuest.MapPath);
					downloadWindow.ShowDialog();
				}
			}

			if (Model.ActiveQuest.Map == null)
			{
				return;
			}

			QuestMapWindow questMapWindow = new QuestMapWindow(Model.ActiveQuest, Model.ActiveQuestCamps);
			bool? result = questMapWindow.ShowDialog();
			if (result.HasValue && result.Value)
			{
				if (questMapWindow.IsEditorMode)
				{
					Model.UpdateActiveQuestCamps();	
				}
				else
				{
					Model.ActiveEnemyCamp = questMapWindow.SelectedCamp;
				}
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
			Options.Instance.Save();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			if (control == null)
			{
				return;
			}

			BattleLosses battleLosses = control.DataContext as BattleLosses;
			if (battleLosses == null)
			{
				return;
			}

			ChartWindow chartWindow = new ChartWindow(battleLosses);
			chartWindow.ShowDialog();
		}
    }
}
