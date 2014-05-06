using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public static class Quests
	{
		#region Constants
		private const string FILENAME = "EuroCup2014\\quests.xml";
		private const string QUEST = "quest";
		#endregion

		#region Fields
		private static List<Quest> m_quests;
		#endregion

		#region Properties
		internal static List<Quest> QuestList
		{
			get
			{
				if (m_quests == null)
				{
					Load();
				}

				return m_quests;
			}
		}
		#endregion

		#region Methods
		private static void Load()
		{
			m_quests = new List<Quest>();
			XmlReader reader = XmlReader.Create(FILENAME);
			while (reader.Read())
			{
				if (!reader.IsStartElement())
				{
					continue;
				}

				try
				{
					if (string.Equals(reader.Name, QUEST, StringComparison.OrdinalIgnoreCase))
					{
						Quest quest = new Quest();
						quest.Load(reader);
						if (!string.IsNullOrEmpty(quest.Id))
							m_quests.Add(quest);
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
