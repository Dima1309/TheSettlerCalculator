using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class TheNordsQuest : Quest
	{
		#region Constants
		private const int JOMVIKING = 0;
		private const int HOUSECARL = 1;
		private const int KARL = 2;
		private const int THRALL = 3;
		private const int VALKYRIE = 4;
		private const int BERSERK = 5;
		private const int WOLF = 6;
		#endregion

		#region Constructor
		internal TheNordsQuest()
		{
			Name = Resources.QUEST_THE_NORDS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Die_Nordmanner.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.JOMVIKING]);
			units.Add(EnemyUnits.Units[EnemyUnits.HOUSECARL]);
			units.Add(EnemyUnits.Units[EnemyUnits.KARL]);
			units.Add(EnemyUnits.Units[EnemyUnits.THRALL]);
			units.Add(EnemyUnits.Units[EnemyUnits.VALKYRIE]);
			units.Add(EnemyUnits.Units[EnemyUnits.BERSERK]);
			units.Add(EnemyUnits.Units[EnemyUnits.WOLF]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 150);
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(VALKYRIE, 50);
			camp.Counts.Add(KARL, 100);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(VALKYRIE, 75);
			camp.Counts.Add(KARL, 50);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(THRALL, 100);
			result.Add(camp);

			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(THRALL, 50);
			camp.Counts.Add(VALKYRIE, 25);
			result.Add(camp);

			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(HOUSECARL, 75);
			camp.Counts.Add(VALKYRIE, 50);
			camp.Counts.Add(BERSERK, 5);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(THRALL, 50);
			camp.Counts.Add(VALKYRIE, 25);
			result.Add(camp);

			camp.Name = "7";
			camp.SectorId = 1;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(THRALL, 100);
			result.Add(camp);

			camp.Name = "8";
			camp.SectorId = 1;
			camp.Counts.Add(VALKYRIE, 75);
			camp.Counts.Add(KARL, 50);
			result.Add(camp);

			camp.Name = "9";
			camp.SectorId = 1;
			camp.Counts.Add(VALKYRIE, 50);
			camp.Counts.Add(KARL, 100);
			result.Add(camp);

			#endregion

			#region Sector 2
			camp.Name = "10";
			camp.SectorId = 2;
			camp.Counts.Add(KARL, 150);
			result.Add(camp);

			camp.Name = "11";
			camp.SectorId = 2;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(KARL, 75);
			result.Add(camp);

			camp.Name = "12";
			camp.SectorId = 2;
			camp.Counts.Add(HOUSECARL, 75);
			camp.Counts.Add(KARL, 30);
			result.Add(camp);

			camp.Name = "13";
			camp.SectorId = 2;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(KARL, 50);
			camp.Counts.Add(VALKYRIE, 50);
			result.Add(camp);

			camp.Name = "14";
			camp.SectorId = 2;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(VALKYRIE, 50);
			result.Add(camp);

			camp.Name = "15";
			camp.SectorId = 2;
			camp.Counts.Add(JOMVIKING, 10);
			camp.Counts.Add(HOUSECARL, 100);
			camp.Counts.Add(VALKYRIE, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp.Name = "16";
			camp.SectorId = 3;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(KARL, 75);
			result.Add(camp);

			camp.Name = "17";
			camp.SectorId = 3;
			camp.Counts.Add(HOUSECARL, 75);
			camp.Counts.Add(VALKYRIE, 50);
			result.Add(camp);

			camp.Name = "18";
			camp.SectorId = 3;
			camp.Counts.Add(HOUSECARL, 100);
			result.Add(camp);

			camp.Name = "19";
			camp.SectorId = 3;
			camp.Counts.Add(VALKYRIE, 75);
			result.Add(camp);

			camp.Name = "20";
			camp.SectorId = 3;
			camp.Counts.Add(HOUSECARL, 75);
			result.Add(camp);

			camp.Name = "21";
			camp.SectorId = 3;
			camp.Counts.Add(JOMVIKING, 20);
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(VALKYRIE, 50);
			camp.Counts.Add(BERSERK, 15);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp.Name = "22";
			camp.SectorId = 4;
			camp.Counts.Add(HOUSECARL, 50);
			camp.Counts.Add(VALKYRIE, 25);
			result.Add(camp);

			camp.Name = "23";
			camp.SectorId = 4;
			camp.Counts.Add(HOUSECARL, 75);
			camp.Counts.Add(KARL, 50);
			result.Add(camp);

			camp.Name = "24";
			camp.SectorId = 4;
			camp.Counts.Add(HOUSECARL, 120);
			result.Add(camp);

			camp.Name = "25";
			camp.SectorId = 4;
			camp.Counts.Add(JOMVIKING, 20);
			camp.Counts.Add(HOUSECARL, 100);
			camp.Counts.Add(KARL, 50);
			camp.Counts.Add(BERSERK, 15);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp.Name = "26";
			camp.SectorId = 5;
			camp.Counts.Add(HOUSECARL, 150);
			result.Add(camp);

			camp.Name = "27";
			camp.SectorId = 5;
			camp.Counts.Add(VALKYRIE, 150);
			result.Add(camp);

			camp.Name = "28";
			camp.SectorId = 5;
			camp.Counts.Add(KARL, 150);
			result.Add(camp);

			camp.Name = "29";
			camp.SectorId = 5;
			camp.Counts.Add(JOMVIKING, 50);
			camp.Counts.Add(HOUSECARL, 120);
			camp.Counts.Add(BERSERK, 30);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}