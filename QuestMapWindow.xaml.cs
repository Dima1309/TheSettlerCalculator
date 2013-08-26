using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Interaction logic for QuestMapWindow.xaml
	/// </summary>
	public partial class QuestMapWindow : Window, INotifyPropertyChanged
	{
		#region Fields
		private bool m_isEditorMode = false;
		private readonly Quest m_model;
		private readonly List<Unit> m_units;
		private readonly ObservableCollection<EnemyCamp> m_camps;
		private EnemyCamp m_selectedCamp;
		private Point? m_lastDragPoint;
		private Point? m_lastClickPosition;
		#endregion

		public QuestMapWindow(Quest quest, IEnumerable<EnemyCamp> camps)
		{
			m_units = new List<Unit>(quest.Units);
			m_model = quest;
			m_camps = new ObservableCollection<EnemyCamp>(camps);

			InitializeComponent();

			Left = 0;
			Top = 0;
			Height = Model.Map.Height;
			Width = Model.Map.Width;
/*
			double maxWidth = Width;
			double maxHeigth = Height;

					

			double ky = maxWidth / Height;
			
			double kx = maxHeigth / Width;
			if (kx > 1 || ky > 1)
			{				
				double k = Math.Max(kx, ky);
				Height = Height / k;
				Width = Width / k;
				imageScale.ScaleX = 1 / k;
				imageScale.ScaleY = 1 / k;
			}*/
		}

		public Quest Model
		{
			get { return m_model; }
		}

		public ObservableCollection<EnemyCamp> Camps
		{
			get { return m_camps; }
		}

		public EnemyCamp SelectedCamp
		{
			get { return m_selectedCamp; }
		}

		public List<Unit> Units
		{
			get { return m_units; }
		}

		public bool IsEditorMode
		{
			get { return m_isEditorMode; }
			set 
			{ 
				m_isEditorMode = value;
				OnPropertyChanged("IsEditorMode");
			}
		}

		private void Win_Loaded(object sender, RoutedEventArgs e)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(MapImage);

			foreach (EnemyCamp camp in m_camps)
			{
				AddAdorner(camp, adornerLayer);
			}
		}

		private void AddAdorner(EnemyCamp camp, AdornerLayer adornerLayer)
		{
			SimpleSquareAdorner adorner = new SimpleSquareAdorner(MapImage, camp);
			adorner.DataContext = Model;
			adorner.MouseUp += adorner_MouseUp;
				
			adornerLayer.Add(adorner);
		}

		void adorner_MouseUp(object sender, MouseButtonEventArgs e)
		{
			SimpleSquareAdorner simpleSquareAdorner = sender as SimpleSquareAdorner;
			if (simpleSquareAdorner != null && !IsEditorMode)
			{
				m_selectedCamp = simpleSquareAdorner.Camp;
				DialogResult = true;
				Close();
			}
		}

		private void MapImage_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			double delta = e.Delta > 0 ? 0.1 : -0.1;

			if (imageScale.ScaleX + delta <= 0 || imageScale.ScaleY + delta <= 0)
			{
				return;
			}

			imageScale.ScaleX += delta;
			imageScale.ScaleY += delta;
		}

		private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			MapImage_MouseWheel(sender, e);
			e.Handled = true;
		}

		private void ScrollViewer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			scrollViewer.Cursor = Cursors.Arrow;
			scrollViewer.ReleaseMouseCapture();
			m_lastDragPoint = null;
		}

		private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_lastDragPoint.HasValue)
			{
				Point posNow = e.GetPosition(scrollViewer);

				double dX = posNow.X - m_lastDragPoint.Value.X;
				double dY = posNow.Y - m_lastDragPoint.Value.Y;

				m_lastDragPoint = posNow;

				scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
				scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);
			}
		}

		private void ScrollViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Point mousePos = e.GetPosition(scrollViewer);
			if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y < scrollViewer.ViewportHeight) //make sure we still can use the scrollbars
			{
				scrollViewer.Cursor = Cursors.SizeAll;
				m_lastDragPoint = mousePos;
				Mouse.Capture(scrollViewer);
			}
		}

		private void Win_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.F2)
			{
				IsEditorMode = !IsEditorMode;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void MapImage_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (IsEditorMode)
			{
				m_lastClickPosition = e.GetPosition(e.Device.Target);
				
			}
		}

		private void Button_Paste_Position_Click(object sender, RoutedEventArgs e)
		{
			if (!m_lastClickPosition.HasValue)
			{
				return;
			}

			Button button = sender as Button;
			if (button ==null)
			{
				return;
			}

			EnemyCamp camp = button.DataContext as EnemyCamp;
			if (camp == null)
			{
				return;
			}

			camp.Left = Math.Round(m_lastClickPosition.Value.X);
			camp.Top = Math.Round(m_lastClickPosition.Value.Y);
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			Camp camp = new Camp();
			camp.Name = "Без названия";

			EnemyCamp enemyCamp = new EnemyCamp(Model, camp);
			m_camps.Add(enemyCamp);

			AddAdorner(enemyCamp, AdornerLayer.GetAdornerLayer(MapImage));
		}

		private void Button_Delete_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button ==null)
			{
				return;
			}

			EnemyCamp camp = button.DataContext as EnemyCamp;
			if (camp == null)
			{
				return;
			}

			if (MessageBox.Show("Удалить лагерь?", "Подтверждение", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
			{
				camp.Left = -1;//for delete adorner
				m_camps.Remove(camp);
			}
		}

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			if (IsEditorMode)
			{
				Model.Camps = new Camp[Camps.Count];
				int i = 0;
				foreach(EnemyCamp camp in Camps)
				{
					Model.Camps[i] = new Camp(camp);
					foreach(UnitSquad squad in camp.Squads)
					{
						int unitIndex = Array.IndexOf(Model.Units, squad.Unit);
						short value;
						if (Model.Camps[i].Counts.TryGetValue((short)unitIndex, out value))
						{
							Model.Camps[i].Counts[(short) unitIndex] = (short) (value + squad.Count);
						} else
						{
							Model.Camps[i].Counts[(short)unitIndex] = (short)squad.Count;
						}
					}
					i++;
				}
				DialogResult = true;
				Close();
			}
		}

		private void Button_Add_Enemy_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button == null)
			{
				return;
			}

			EnemyCamp camp = button.DataContext as EnemyCamp;
			if (camp == null)
			{
				return;
			}

			camp.Squads.Add(new UnitSquad(Model.Units[0], 0));
		}
	}
}
