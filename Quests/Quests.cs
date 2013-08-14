using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal static class Quests
	{
		#region Fields
		private static Quest[] s_quests;
		#endregion

		#region Properties
		public static Quest[] QuestList
		{
			get
			{				
				if (s_quests == null)
				{
					//InitializeQuests();
					Load();
				}				

				return s_quests;
			}
		}
		#endregion

		#region Methods
		internal static void Load()
		{
			List<Quest> result = new List<Quest>();
			if (Directory.Exists(Options.QUESTS_FOLDER))
			{
				foreach (String file in Directory.GetFiles(Options.QUESTS_FOLDER, "*.xml"))
				{
					//String fileName = QUESTS_FOLDER + "\\" + file;
					XmlReader reader = XmlReader.Create(file);
					Quest quest = new Quest();
					quest.FileName = file;
					quest.Load(reader);
					reader.Close();

					result.Add(quest);
				}
			}

			s_quests = result.ToArray();
		}

		internal static void Save()
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			foreach(Quest quest in QuestList)
			{
				string filename = quest.FileName;
				if (string.IsNullOrEmpty(filename))
				{
					filename = Helper.Helper.getResourceName(quest.Name);
					if(filename.StartsWith("QUEST_"))
					{
						filename = "Quests\\" + filename.Substring(6).ToLower() + ".xml";
					}
				}
				XmlWriter writer = XmlWriter.Create(filename, settings);
				quest.Save(writer);
				writer.Close();
			}
		}
		#endregion
	}
}
