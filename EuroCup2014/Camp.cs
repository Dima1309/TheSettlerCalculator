using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Camp : ObjectWithId
	{
		#region Constants
		private const string CAMP = "camp";
		private const string SKILL = "skill";
		private const string ID = "id";
		private const string COUNT = "count";
		#endregion

		#region Fields
		private ObservableCollection<SkillWithCount> m_skills = new ObservableCollection<SkillWithCount>();
		#endregion

		#region Constructors
		public Camp()
		{
		}

		public Camp(Camp other) : base(other)
		{
			foreach(SkillWithCount skill in  other.Skills)
			{
				m_skills.Add(new SkillWithCount(skill.Skill, skill.Count));
			}
		}
		#endregion

		#region Properties
		public ObservableCollection<SkillWithCount> Skills
		{
			get
			{
				return m_skills;
			}
		}
		#endregion 

		#region Methods
		internal override string GetNodeName()
		{
			return CAMP;
		}

		internal override void ProcessChilds(XmlReader reader)
		{
			if (reader.Name.Equals(SKILL, StringComparison.OrdinalIgnoreCase))
			{
				m_skills.Add(new SkillWithCount(
					reader.GetAttribute(ID),
					int.Parse(reader.GetAttribute(COUNT), CultureInfo.InvariantCulture)));
			}
		}
		#endregion
	}
}
