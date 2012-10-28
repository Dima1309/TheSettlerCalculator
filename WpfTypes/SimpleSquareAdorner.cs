﻿using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TheSettlersCalculator.WpfTypes.Converters;

namespace TheSettlersCalculator.WpfTypes
{
	public class SimpleSquareAdorner : Adorner
	{
		#region Fields
		private readonly EnemyCamp m_camp;
		private readonly Brush m_brush;
		#endregion

		// Be sure to call the base class constructor.
		public SimpleSquareAdorner(UIElement adornedElement, EnemyCamp camp)
			: base(adornedElement)
		{
			m_camp = camp;
			ToolTip toolTip = new ToolTip();
			StackPanel panel = new StackPanel();
			panel.Orientation = Orientation.Horizontal;
			panel.Children.Add(new Label { Content = camp.Name, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold });
			foreach(UnitSquad squad in camp.Squads)
			{
				panel.Children.Add(new Image { Source = squad.Icon, VerticalAlignment = VerticalAlignment.Center, Height = 30});
				panel.Children.Add(new Label { Content = squad.Count, VerticalAlignment = VerticalAlignment.Center });
			}
			
			toolTip.Content = panel;
			ToolTip = toolTip;

			CampTypeConverter converter = new CampTypeConverter();
			m_brush = converter.Convert(camp.CampType, typeof(Brush), null, CultureInfo.InvariantCulture) as Brush;
		}

		public EnemyCamp Camp
		{
			get { return m_camp; }
		}

		// A common way to implement an adorner's rendering behavior is to override the OnRender
		// method, which is called by the layout system as part of a rendering pass.
		protected override void OnRender(DrawingContext drawingContext)
		{
			Rect adornedElementRect = new Rect(Camp.Left, Camp.Top, 46, 46);

			Pen renderPen = new Pen(new SolidColorBrush(Colors.Transparent), 0);

			// Draw a circle at each corner.
			drawingContext.DrawRoundedRectangle(m_brush, renderPen, adornedElementRect, 5, 5);
		}
	}

}
