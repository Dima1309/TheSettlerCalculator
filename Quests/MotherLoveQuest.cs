using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class MotherLoveQuest : Quest
	{
		#region Constants
		private const int WILD_MARY = 0;
		private const int CALTROP = 1;
		private const int CRAZY_COOK = 2;
		private const int GUNMAN = 3;
		private const int PETTY_OFFICER_2ND_CLASS = 4;
		private const int WOLF = 5;
		#endregion

		#region Constructor
		internal MotherLoveQuest()
		{
			Name = Resources.QUEST_MOTHER_LOVE;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Mutterliebe.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.WILD_MARY]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CALTROP]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CRAZY_COOK]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.GUNMAN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.PETTY_OFFICER_2ND_CLASS]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.WOLF]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 200);
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W2";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 200);
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W3";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 100);
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(GUNMAN, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(WILD_MARY, 1);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}