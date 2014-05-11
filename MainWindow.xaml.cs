using System.IO;
using System.Windows;
using System.Windows.Controls;
using TheSettlersCalculator.Specialists.Generals;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.WpfTypes;
using TheSettlersCalculator.EuroCup2014;
using TheSettlersCalculator.EuroCup2014.Components;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        #region Fields
        private readonly MainWindowModel m_model = new MainWindowModel();
		private readonly Model m_euroCupModel = new Model();
        #endregion

        public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindowModel Model
		{
			get { return m_model; }
		}

		public Model EuroCupModel
		{
			get { return m_euroCupModel; }
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

		private void ButtonAddEuroCupCamp_Click(object sender, RoutedEventArgs e)
		{
			EuroCup2014.Camp newCamp = new EuroCup2014.Camp();
			newCamp.Id = Properties.Resources.EUROCUP2014_FORWARD;
			CampEditor editor = new CampEditor(newCamp);
			if (editor.ShowDialog().Value)
			{
				m_euroCupModel.Camps.Add(newCamp);
			}
		}

		private void ButtonEuroCup2014EditCamp_Click(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			if (control != null && control.DataContext is EuroCup2014.Camp)
			{
				CampEditor editor = new CampEditor(control.DataContext as EuroCup2014.Camp);
				if (editor.ShowDialog().Value)
				{
				}
			}
		}

		private void ButtonDeleteEuroCamp_Click(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			if (control != null && control.DataContext is EuroCup2014.Camp)
			{
				if (MessageBox.Show(
					Properties.Resources.MESSAGE_DELETE_CAMP, 
					Properties.Resources.TITLE_CONFIRM, 
					MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					m_euroCupModel.Camps.Remove(control.DataContext as EuroCup2014.Camp);					
				}
			}
		}
    }
}
