using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
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
		private Point? m_lastDragPoint;
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

		private void MapImage_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
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
	}
}
