using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class WildMaryQuest : Quest
	{
		#region Constants
		private const int WILD_MARY = 0;
		private const int THUG = 1;
		private const int GUARD_DOG = 2;
		private const int ROUGHNECK = 3;
		private const int STONE_THROWER = 4;
		private const int RANGER = 5;
		#endregion

		#region Constructor
		internal WildMaryQuest()
		{
			Name = Resources.QUEST_WILD_MARY;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Die_Wilde_Waltraut.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.WILD_MARY]);
			units.Add(EnemyUnits.Units[EnemyUnits.THUG]);
			units.Add(EnemyUnits.Units[EnemyUnits.GUARD_DOG]);
			units.Add(EnemyUnits.Units[EnemyUnits.ROUGHNECK]);
			units.Add(EnemyUnits.Units[EnemyUnits.STONE_THROWER]);
			units.Add(EnemyUnits.Units[EnemyUnits.RANGER]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 80);
			camp.Counts.Add(STONE_THROWER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(STONE_THROWER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 80);
			camp.Counts.Add(STONE_THROWER, 70);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 80);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(RANGER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(THUG, 90);
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(THUG, 100);
			camp.Counts.Add(RANGER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 3;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(RANGER, 80);
			camp.Counts.Add(ROUGHNECK, 70);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 4;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 4;
			camp.Counts.Add(ROUGHNECK, 180);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 4;
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 4;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 4;
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 130);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 130);
			camp.Counts.Add(GUARD_DOG, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 120);
			camp.Counts.Add(ROUGHNECK, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 5;
			camp.Counts.Add(ROUGHNECK, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "20";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 70);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.Counts.Add(GUARD_DOG, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "21";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(ROUGHNECK, 140);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "22";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 40);
			camp.Counts.Add(WILD_MARY, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}