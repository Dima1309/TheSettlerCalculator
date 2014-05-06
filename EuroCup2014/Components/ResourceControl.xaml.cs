using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheSettlersCalculator.EuroCup2014.Components
{
	/// <summary>
	/// Логика взаимодействия для ResourceControl.xaml
	/// </summary>
	public partial class ResourceControl : UserControl
	{
		public static readonly DependencyProperty ResourceProperty = DependencyProperty.Register("Resource", typeof(Resource), typeof(ResourceControl));

		public ResourceControl()
		{
			InitializeComponent();
		}

		public Resource Resource
		{
			get { return (Resource)GetValue(ResourceProperty); }
			set { SetValue(ResourceProperty, value); }
		}
	}
}
