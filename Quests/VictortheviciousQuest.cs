using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class VictortheviciousQuest : Quest
	{
		#region Constants
		private const int WILD_MARY = 0;
		private const int METAL_TOOTHED = 1;
		private const int SCAVENGER = 2;
		private const int THUG = 3;
		private const int GUARD_DOG = 4;
		private const int ROUGHNECK = 5;
		private const int RANGER = 6;
		private const int SKUNK = 7;
		private const int ONE_EYED_BERT = 8;
		private const int WOLF = 9;
		#endregion

		#region Constructor
		internal VictortheviciousQuest()
		{
			Name = Resources.QUEST_VICTOR_THE_VICIOUS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Viktor_der_Verschlagene.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.WILD_MARY]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.METAL_TOOTHED]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SCAVENGER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.THUG]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.GUARD_DOG]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.ROUGHNECK]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.RANGER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SKUNK]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.ONE_EYED_BERT]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.WOLF]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1a
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 50);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 50);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(ROUGHNECK, 99);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.Counts.Add(GUARD_DOG, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 1b
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 101;
			camp.Counts.Add(THUG, 50);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 101;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 101;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 101;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 50);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 101;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 101;
			camp.Counts.Add(ROUGHNECK, 99);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.Counts.Add(GUARD_DOG, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 1c
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 201;
			camp.Counts.Add(THUG, 50);
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 201;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 201;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 201;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 50);
			camp.Counts.Add(GUARD_DOG, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 201;
			camp.Counts.Add(ROUGHNECK, 99);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.Counts.Add(GUARD_DOG, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(ROUGHNECK, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(ROUGHNECK, 120);
			camp.Counts.Add(GUARD_DOG, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(RANGER, 60);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.Counts.Add(GUARD_DOG, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 3;
			camp.Counts.Add(ROUGHNECK, 90);
			camp.Counts.Add(SKUNK, 1);
			camp.Counts.Add(ONE_EYED_BERT, 1);
			camp.Counts.Add(GUARD_DOG, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "W2";
			camp.SectorId = 4;
			camp.Counts.Add(WOLF, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 4;
			camp.Counts.Add(WOLF, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W3";
			camp.SectorId = 4;
			camp.Counts.Add(WOLF, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 4;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 4;
			camp.Counts.Add(ROUGHNECK, 100);
			camp.Counts.Add(GUARD_DOG, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 4;
			camp.Counts.Add(ROUGHNECK, 155);
			camp.Counts.Add(METAL_TOOTHED, 1);
			camp.Counts.Add(GUARD_DOG, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 80);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.Counts.Add(GUARD_DOG, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 40);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.Counts.Add(GUARD_DOG, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 100);
			camp.Counts.Add(ROUGHNECK, 80);
			camp.Counts.Add(SKUNK, 1);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 5;
			camp.Counts.Add(RANGER, 50);
			camp.Counts.Add(SCAVENGER, 100);
			camp.Counts.Add(SKUNK, 2);
			camp.Counts.Add(WILD_MARY, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}