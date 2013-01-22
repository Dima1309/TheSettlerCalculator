using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class BanditNestQuest : Quest
	{
		#region Constants
		private const int CHUCK = 0;
		private const int METAL_TOOTHED = 1;
		private const int SCAVENGER = 2;
		private const int THUG = 3;
		private const int GUARD_DOG = 4;
		private const int ROUGHNECK = 5;
		private const int RANGER = 6;
		private const int ONE_EYED_BERT = 7;
		#endregion

		#region Constructor
		internal BanditNestQuest()
		{
			Name = Resources.QUEST_BANDIT_NEST;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Das_Banditennest.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.CHUCK]);
			units.Add(EnemyUnits.Units[EnemyUnits.METAL_TOOTHED]);
			units.Add(EnemyUnits.Units[EnemyUnits.SCAVENGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.THUG]);
			units.Add(EnemyUnits.Units[EnemyUnits.GUARD_DOG]);
			units.Add(EnemyUnits.Units[EnemyUnits.ROUGHNECK]);
			units.Add(EnemyUnits.Units[EnemyUnits.RANGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.ONE_EYED_BERT]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(SCAVENGER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 120);
			camp.Counts.Add(RANGER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(SCAVENGER, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 70);
			camp.Counts.Add(GUARD_DOG, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(ROUGHNECK, 90);
			camp.Counts.Add(GUARD_DOG, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.Counts.Add(CHUCK, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 80);
			camp.Counts.Add(RANGER, 20);
			camp.Counts.Add(GUARD_DOG, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 150);
			camp.Counts.Add(RANGER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 3;
			camp.Counts.Add(RANGER, 80);
			camp.Counts.Add(ROUGHNECK, 60);
			camp.Counts.Add(METAL_TOOTHED, 1);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}