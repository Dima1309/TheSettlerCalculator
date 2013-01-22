using System;

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
					InitializeQuests();
				}

				return s_quests;
			}
		}
		#endregion

		#region Methods
		private static void InitializeQuests()
		{
			s_quests = new Quest[]
			           	{
							new BanditNestQuest(),
							new BountyHunterQuest(),
			           		new DarkTemplareQuest(),
							new GunpowderQuest(),
							new HorsebackQuest(),
							new IslandofthePiratesQuest(),
							new MainIsland(),
							new MotherLoveQuest(),
							new OldFriendsQuest(),
							new OutlawsQuest(),
							new RoaringBullQuest(),
							new SecludedExperimentsQuest(),
							new SonsoftheveldtQuest(),
							new StealingfromtherichQuest(),
							new SurpriseAttackQuest(),
							new TheBlackKnightsQuest(),
							new TheDarkBrotherhoodQuest(),
							new TheNordsQuest(),
							new TraitorsQuest(),
							new VictortheviciousQuest(),
							new WildMaryQuest(),
							new WitchoftheSwampQuest()
			           	};
		}
		#endregion
	}
}
