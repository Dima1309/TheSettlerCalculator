using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class MainIsland : Quest
	{
		#region Constants
		private const int WILD_MARY = 0;
		private const int CHUCK = 1;
		private const int METAL_TOOTHED = 2;
		private const int SCAVENGER = 3;
		private const int THUG = 4;
		private const int GUARD_DOG =5;
		private const int ROUGHNECK =6;
		private const int STONE_THROWER =7;
		private const int RANGER = 8;
		private const int SKUNK = 9;
		private const int ONE_EYED_BERT = 10;
		#endregion

		#region Constructor
		internal MainIsland()
		{
			Name = Resources.QUEST_MAIN_ISLAND;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.WILD_MARY]);
			units.Add(EnemyUnits.Units[EnemyUnits.CHUCK]);
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

			#region Sector 2
			Camp camp = new Camp();
			camp.Name = "2-1";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 6);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2-2";
			camp.SectorId = 2;
			camp.Counts.Add(SCAVENGER, 12);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "3-1";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 40);
			camp.Counts.Add(STONE_THROWER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3-2";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 90);
			camp.Counts.Add(STONE_THROWER, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3-3";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 5);
			camp.Counts.Add(STONE_THROWER, 5);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3-4";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 80);
			camp.Counts.Add(STONE_THROWER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3-5";
			camp.SectorId = 3;
			camp.Counts.Add(SCAVENGER, 5);
			camp.Counts.Add(STONE_THROWER, 85);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3-6";
			camp.SectorId = 3;
			camp.Counts.Add(THUG, 79);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "5-1";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 3);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-2";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-3";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-4";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-5";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 15);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-6";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 18);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-7";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 20);
			camp.Counts.Add(STONE_THROWER, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-8";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 25);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-9";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 15);
			camp.Counts.Add(STONE_THROWER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-10";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 20);
			camp.Counts.Add(STONE_THROWER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5-11";
			camp.SectorId = 5;
			camp.Counts.Add(SCAVENGER, 30);
			camp.Counts.Add(STONE_THROWER, 20);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 6
			camp = new Camp();
			camp.Name = "6-1";
			camp.SectorId = 6;
			camp.Counts.Add(GUARD_DOG, 60);
			camp.Counts.Add(RANGER, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6-2";
			camp.SectorId = 6;
			camp.Counts.Add(THUG, 60);
			camp.Counts.Add(GUARD_DOG, 120);			
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6-3";
			camp.SectorId = 6;
			camp.Counts.Add(THUG, 20);
			camp.Counts.Add(GUARD_DOG, 30);
			camp.Counts.Add(RANGER, 130);			
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6-4";
			camp.SectorId = 6;
			camp.Counts.Add(THUG, 30);
			camp.Counts.Add(GUARD_DOG, 120);
			camp.Counts.Add(RANGER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6-5";
			camp.SectorId = 6;
			camp.Counts.Add(THUG, 150);
			camp.Counts.Add(GUARD_DOG, 30);
			camp.Counts.Add(RANGER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6-6";
			camp.SectorId = 6;
			camp.Counts.Add(CHUCK, 1);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.Counts.Add(RANGER, 49);
			camp.Counts.Add(ROUGHNECK, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 7
			camp = new Camp();
			camp.Name = "7-1";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 30);
			camp.Counts.Add(STONE_THROWER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-2";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-3";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-4";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 50);
			camp.Counts.Add(STONE_THROWER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-5";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 60);
			camp.Counts.Add(STONE_THROWER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-6";
			camp.SectorId = 7;
			camp.Counts.Add(SCAVENGER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7-7";
			camp.SectorId = 7;
			camp.Counts.Add(SKUNK, 1);
			camp.Counts.Add(SCAVENGER, 150);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 8
			camp = new Camp();
			camp.Name = "8-1";
			camp.SectorId = 8;
			camp.Counts.Add(GUARD_DOG, 180);
			camp.Counts.Add(RANGER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8-2";
			camp.SectorId = 8;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(GUARD_DOG, 40);
			camp.Counts.Add(RANGER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8-3";
			camp.SectorId = 8;
			camp.Counts.Add(THUG, 180);
			camp.Counts.Add(GUARD_DOG, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8-4";
			camp.SectorId = 8;
			camp.Counts.Add(THUG, 80);
			camp.Counts.Add(GUARD_DOG, 40);
			camp.Counts.Add(RANGER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8-5";
			camp.SectorId = 8;
			camp.Counts.Add(METAL_TOOTHED, 1);
			camp.Counts.Add(RANGER, 149);
			camp.Counts.Add(ROUGHNECK, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 9
			camp = new Camp();
			camp.Name = "9-1";
			camp.SectorId = 9;
			camp.Counts.Add(RANGER, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-2";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 50);
			camp.Counts.Add(RANGER, 40);
			camp.Counts.Add(ROUGHNECK, 110);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-3";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 60);
			camp.Counts.Add(RANGER, 120);
			camp.Counts.Add(ROUGHNECK, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-4";
			camp.SectorId = 9;
			camp.Counts.Add(RANGER, 140);
			camp.Counts.Add(ROUGHNECK, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-5";
			camp.SectorId = 9;
			camp.Counts.Add(RANGER, 80);
			camp.Counts.Add(ROUGHNECK, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-6";
			camp.SectorId = 9;
			camp.Counts.Add(ROUGHNECK, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-7";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 10);
			camp.Counts.Add(RANGER, 180);
			camp.Counts.Add(ROUGHNECK, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-8";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 30);
			camp.Counts.Add(RANGER, 10);
			camp.Counts.Add(ROUGHNECK, 160);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-9";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-10";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 70);
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-11";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 170);
			camp.Counts.Add(RANGER, 10);
			camp.Counts.Add(ROUGHNECK, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-12";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 80);
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-13";
			camp.SectorId = 9;
			camp.Counts.Add(GUARD_DOG, 50);
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9-14";
			camp.SectorId = 9;
			camp.Counts.Add(WILD_MARY, 1);
			camp.Counts.Add(GUARD_DOG, 199);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			return result;
		}

	}
}