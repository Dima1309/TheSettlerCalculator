using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public static class Skills
	{
		#region Constants
		private const string FILENAME = "EuroCup2014\\skills.xml";
		private const string SKILL = "skill";
		#endregion

		#region Fields
		private static Dictionary<string, Skill> m_skills;
		#endregion

		#region Properties
		internal static Dictionary<string, Skill> SkillList
		{
			get
			{
				if (m_skills == null)
				{
					Load();
				}

				return m_skills;
			}
		}
		#endregion

		#region Methods
		private static void Load()
		{
			m_skills = new Dictionary<string, Skill>();
			XmlReader reader = XmlReader.Create(FILENAME);
			while (reader.Read())
			{
				if (!reader.IsStartElement())
				{
					continue;
				}

				try
				{
					if (string.Equals(reader.Name, SKILL, StringComparison.OrdinalIgnoreCase))
					{
						Skill skill = new Skill();
						skill.Load(reader);
						if (!string.IsNullOrEmpty(skill.Id))
							m_skills[skill.Id] = skill;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}
		#endregion
	}
}
