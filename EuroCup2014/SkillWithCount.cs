using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014
{
	public class SkillWithCount : INotifyPropertyChanged
	{
		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Fields
		private Skill m_skill;
		private int m_count;
		#endregion

		#region Constructor
		public SkillWithCount(string skillId, int count)
		{
			m_skill = Skills.SkillList[skillId];
			m_count = count;
		}

		internal SkillWithCount(Skill skill, int count)
		{
			m_skill = skill;
			m_count = count;
		}
		#endregion

		#region Properties
		public Skill Skill
		{
			get
			{
				return m_skill;
			}
		}

		public int Count
		{
			get
			{
				return m_count;
			}

			set
			{
				m_count = value;
				OnPropertyChanged("Count");
			}
		}
		#endregion

		#region Methods
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
