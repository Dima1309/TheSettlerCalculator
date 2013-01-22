using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class BountyHUunterQuest : Quest
	{
		#region Constants
		private const int SCAVENGER = 0;
		private const int STONE_THROWER = 1;
		#endregion

		#region Constructor
		internal BountyHUunterQuest()
		{
			Name = Resources.QUEST_BOUNTY_HUNTER;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Kopfgeldjager.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.SCAVENGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.STONE_THROWER]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(SCAVENGER, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 2
			camp.Name = "2";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 5);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 10);
			result.Add(camp);

			camp.Name = "4";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 6);
			camp.Counts.Add(STONE_THROWER, 6);
			result.Add(camp);

			camp.Name = "5";
			camp.Counts.Add(SCAVENGER, 15);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion
			
			return result;
		}

	}
}