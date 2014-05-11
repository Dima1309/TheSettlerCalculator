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
using System.Windows.Shapes;

namespace TheSettlersCalculator.EuroCup2014.Components
{
	/// <summary>
	/// Логика взаимодействия для CampEditor.xaml
	/// </summary>
	public partial class CampEditor : Window
	{
		public static readonly DependencyProperty CampProperty = DependencyProperty.Register("Camp", typeof(Camp), typeof(CampEditor));		

		#region Fields
		private List<SkillWithCount> m_row1;
		private List<SkillWithCount> m_row2;
		private string m_campName;
		#endregion 

		#region Constructor
		public CampEditor(Camp camp)
		{						
			SetValue(CampProperty, camp);
			List<SkillWithCount> temp = new List<SkillWithCount>(8);
			foreach(Skill skill in Skills.SkillList.Values)
			{
				int count = 0;
				foreach(SkillWithCount campSkill in camp.Skills)
				{
					if (campSkill.Skill.Equals(skill))
					{
						count = campSkill.Count;
					}
				}
				temp.Add(new SkillWithCount(skill, count));
			}
			m_row1 = temp.GetRange(0,4);
			m_row2 = temp.GetRange(4, 4);
			m_campName = Camp.Name;

			InitializeComponent();
		}
		#endregion

		#region Proeprties
		public Camp Camp
		{
			get { return (Camp)GetValue(CampProperty); }
		}

		public string CampName
		{
			get { return m_campName; }
			set { m_campName = value; }
		}		

		public List<SkillWithCount> Row1
		{
			get
			{
				return m_row1;
			}
		}

		public List<SkillWithCount> Row2
		{
			get
			{
				return m_row2;
			}
		}
		#endregion

		#region Methods
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			Camp.Skills.Clear();
			foreach(SkillWithCount skill in m_row1)
			{
				if (skill.Count > 0)
				{
					Camp.Skills.Add(skill);
				}
			}

			foreach (SkillWithCount skill in m_row2)
			{
				if (skill.Count > 0)
				{
					Camp.Skills.Add(skill);
				}
			}

			Camp.Name = CampName;

			DialogResult = true;
			Close();
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
		#endregion
	}
}
