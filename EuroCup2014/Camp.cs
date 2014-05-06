using System;
using System.Collections.Generic;
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
		private List<SkillWithCount> m_skills = new List<SkillWithCount>();
		#endregion

		#region Properties
		public List<SkillWithCount> Skills
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
