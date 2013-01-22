using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class OutlawsQuest : Quest
	{
		#region Constants
		private const int METAL_TOOTHED = 0;
		private const int SCAVENGER = 1;
		private const int THUG = 2;
		private const int GUARD_DOG = 3;
		private const int ROUGHNECK = 4;
		private const int STONE_THROWER = 5;
		private const int RANGER = 6;
		private const int SKUNK = 7;
		private const int ONE_EYED_BERT = 8;
		#endregion

		#region Constructor
		internal OutlawsQuest()
		{
			Name = Resources.QUEST_OUTLAWS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Rauberbande.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.METAL_TOOTHED]);
			units.Add(EnemyUnits.Units[EnemyUnits.SCAVENGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.THUG]);
			units.Add(EnemyUnits.Units[EnemyUnits.GUARD_DOG]);
			units.Add(EnemyUnits.Units[EnemyUnits.ROUGHNECK]);
			units.Add(EnemyUnits.Units[EnemyUnits.STONE_THROWER]);
			units.Add(EnemyUnits.Units[EnemyUnits.RANGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.SKUNK]);
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
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(RANGER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 60);
			camp.Counts.Add(RANGER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 40);
			camp.Counts.Add(RANGER, 80);
			camp.Counts.Add(ROUGHNECK, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(ROUGHNECK, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(ROUGHNECK, 40);
			camp.Counts.Add(GUARD_DOG, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 1;
			camp.Counts.Add(SKUNK, 2);
			camp.Counts.Add(METAL_TOOTHED, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 60);
			camp.Counts.Add(STONE_THROWER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(STONE_THROWER, 60);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "23";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "24";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "25";
			camp.SectorId = 2;
			camp.Counts.Add(STONE_THROWER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 2;
			camp.Counts.Add(THUG, 30);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 80);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 100);
			camp.Counts.Add(STONE_THROWER, 30);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 30);
			camp.Counts.Add(STONE_THROWER, 100);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 60);
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 60);
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 180);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 4;
			camp.Counts.Add(SCAVENGER, 80);
			camp.Counts.Add(STONE_THROWER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 4;
			camp.Counts.Add(SCAVENGER, 50);
			camp.Counts.Add(STONE_THROWER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 4;
			camp.Counts.Add(SCAVENGER, 60);
			camp.Counts.Add(STONE_THROWER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 4;
			camp.Counts.Add(SCAVENGER, 50);
			camp.Counts.Add(STONE_THROWER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "20";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 100);
			camp.Counts.Add(STONE_THROWER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "21";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 50);
			camp.Counts.Add(STONE_THROWER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "22";
			camp.SectorId = 5;
			camp.Counts.Add(STONE_THROWER, 80);
			camp.Counts.Add(SKUNK, 1);
			camp.Counts.Add(GUARD_DOG, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}