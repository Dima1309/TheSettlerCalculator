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
	/// Логика взаимодействия для SkillControl.xaml
	/// </summary>
	public partial class SkillControl : UserControl
	{
		public static readonly DependencyProperty SkillProperty = DependencyProperty.Register("Skill", typeof(Skill), typeof(SkillControl));

		public SkillControl()
		{
			InitializeComponent();
		}

		public Skill Skill
		{
			get { return (Skill)GetValue(SkillProperty); }
			set { SetValue(SkillProperty, value); }
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			Skill = DataContext as Skill;
		}
	}
}
