using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class HorsebackQuest : Quest
	{
		#region Constants
		private const int NOMAD = 0;
		private const int LANCE_RIDER = 1;
		private const int RIDING_BOWMAN = 2;
		private const int RIDING_AMAZONIAN = 3;
		private const int CATAPHRACT = 4;
		private const int UPROARIOUS_BULL = 5;
		private const int COMPOSITE_BOW = 6;
		#endregion

		#region Constructor
		internal HorsebackQuest()
		{
			Name = Resources.QUEST_HORSEBACK;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Sattelfest.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.NOMAD]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.LANCE_RIDER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.RIDING_BOWMAN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.RIDING_AMAZONIAN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CATAPHRACT]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.UPROARIOUS_BULL]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.COMPOSITE_BOW]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 40);
			camp.Counts.Add(COMPOSITE_BOW, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 90);
			camp.Counts.Add(COMPOSITE_BOW, 90);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(LANCE_RIDER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(COMPOSITE_BOW, 120);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 3;
			camp.Counts.Add(NOMAD, 30);
			camp.Counts.Add(LANCE_RIDER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(RIDING_AMAZONIAN, 30);
			camp.Counts.Add(RIDING_BOWMAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 3;
			camp.Counts.Add(NOMAD, 60);
			camp.Counts.Add(RIDING_BOWMAN, 75);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 50);
			camp.Counts.Add(RIDING_AMAZONIAN, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 70);
			camp.Counts.Add(CATAPHRACT, 20);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 40);
			camp.Counts.Add(COMPOSITE_BOW, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 40);
			camp.Counts.Add(LANCE_RIDER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 5;
			camp.Counts.Add(RIDING_AMAZONIAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 5;
			camp.Counts.Add(RIDING_BOWMAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 30);
			camp.Counts.Add(LANCE_RIDER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 60);
			camp.Counts.Add(LANCE_RIDER, 40);
			camp.Counts.Add(COMPOSITE_BOW, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 6
			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 6;
			camp.Counts.Add(NOMAD, 70);
			camp.Counts.Add(RIDING_AMAZONIAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 6;
			camp.Counts.Add(NOMAD, 70);
			camp.Counts.Add(LANCE_RIDER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 6;
			camp.Counts.Add(NOMAD, 70);
			camp.Counts.Add(LANCE_RIDER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "20";
			camp.SectorId = 6;
			camp.Counts.Add(RIDING_AMAZONIAN, 90);
			camp.Counts.Add(UPROARIOUS_BULL, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}