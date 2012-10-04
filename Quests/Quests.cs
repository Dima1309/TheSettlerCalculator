namespace TheSettlersCalculator.Quests
{
	internal static class Quests
	{
		#region Fields
		private static Quest[] m_quests;
		#endregion

		#region Properties
		public static Quest[] QuestList
		{
			get
			{
				if (m_quests == null)
				{
					InitializeQuests();
				}

				return m_quests;
			}
		}
		#endregion

		#region Methods
		private static void InitializeQuests()
		{
			m_quests = new Quest[1];
			m_quests[0] = new DarkTemplareQuest();
		}
		#endregion
	}
}
