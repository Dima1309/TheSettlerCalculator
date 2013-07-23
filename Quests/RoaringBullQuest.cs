using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class RoaringBullQuest : Quest
	{
		#region Constants
		private const int CULTIST = 0;
		private const int SHADOWSNEAKER = 1;
		private const int DARK_PRIEST = 2;
		private const int FIREDANCER = 3;
		private const int DARK_HIGH_PRIEST = 4;
		private const int NOMAD = 5;
		private const int LANCE_RIDER = 6;
		private const int RIDING_BOWMAN = 7;
		private const int RIDING_AMAZONIAN = 8;
		private const int CATAPHRACT = 9;
		private const int UPROARIOUS_BULL = 10;
		private const int COMPOSITE_BOW = 11;
		#endregion

		#region Constructor
		internal RoaringBullQuest()
		{
			Name = Resources.QUEST_ROARING_BULL;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Rasender_Bulle.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CULTIST]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SHADOWS_NEAKER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.DARK_PRIEST]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.FIRE_DANCER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.DARK_HIGH_PRIEST]);
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
			camp.Counts.Add(NOMAD, 100);
			camp.Counts.Add(COMPOSITE_BOW, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 80);
			camp.Counts.Add(LANCE_RIDER, 50);
			camp.Counts.Add(RIDING_BOWMAN, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 100);
			camp.Counts.Add(RIDING_BOWMAN, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(NOMAD, 100);
			camp.Counts.Add(COMPOSITE_BOW, 50);
			camp.Counts.Add(LANCE_RIDER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(LANCE_RIDER, 70);
			camp.Counts.Add(RIDING_BOWMAN, 80);
			camp.Counts.Add(RIDING_AMAZONIAN, 20);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(NOMAD, 120);
			camp.Counts.Add(COMPOSITE_BOW, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(NOMAD, 120);
			camp.Counts.Add(COMPOSITE_BOW, 30);
			camp.Counts.Add(LANCE_RIDER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(RIDING_BOWMAN, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(RIDING_BOWMAN, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 2;
			camp.Counts.Add(NOMAD, 50);
			camp.Counts.Add(LANCE_RIDER, 50);
			camp.Counts.Add(RIDING_AMAZONIAN, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(NOMAD, 80);
			camp.Counts.Add(LANCE_RIDER, 40);
			camp.Counts.Add(RIDING_BOWMAN, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 3;
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(RIDING_BOWMAN, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 3;
			camp.Counts.Add(NOMAD, 80);
			camp.Counts.Add(LANCE_RIDER, 70);
			camp.Counts.Add(RIDING_AMAZONIAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 3;
			camp.Counts.Add(NOMAD, 50);
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(CATAPHRACT, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 3;
			camp.Counts.Add(LANCE_RIDER, 70);
			camp.Counts.Add(RIDING_AMAZONIAN, 80);
			camp.Counts.Add(CATAPHRACT, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 50);
			camp.Counts.Add(RIDING_BOWMAN, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 100);
			camp.Counts.Add(RIDING_AMAZONIAN, 90);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 4;
			camp.Counts.Add(LANCE_RIDER, 100);
			camp.Counts.Add(RIDING_BOWMAN, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 60);
			camp.Counts.Add(LANCE_RIDER, 50);
			camp.Counts.Add(RIDING_AMAZONIAN, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "20";
			camp.SectorId = 4;
			camp.Counts.Add(NOMAD, 60);
			camp.Counts.Add(RIDING_AMAZONIAN, 70);
			camp.Counts.Add(CATAPHRACT, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "21";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 120);
			camp.Counts.Add(COMPOSITE_BOW, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "22";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 150);
			camp.Counts.Add(COMPOSITE_BOW, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "23";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 80);
			camp.Counts.Add(COMPOSITE_BOW, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "24";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 50);
			camp.Counts.Add(LANCE_RIDER, 50);
			camp.Counts.Add(RIDING_BOWMAN, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "25";
			camp.SectorId = 5;
			camp.Counts.Add(NOMAD, 100);
			camp.Counts.Add(RIDING_BOWMAN, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "26";
			camp.SectorId = 5;
			camp.Counts.Add(LANCE_RIDER, 80);
			camp.Counts.Add(RIDING_BOWMAN, 40);
			camp.Counts.Add(RIDING_AMAZONIAN, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 6
			camp = new Camp();
			camp.Name = "27";
			camp.SectorId = 6;
			camp.Counts.Add(LANCE_RIDER, 90);
			camp.Counts.Add(CATAPHRACT, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "28";
			camp.Counts.Add(NOMAD, 110);
			camp.Counts.Add(RIDING_AMAZONIAN, 40);
			camp.Counts.Add(CATAPHRACT, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "29";
			camp.SectorId = 6;
			camp.Counts.Add(NOMAD, 90);
			camp.Counts.Add(LANCE_RIDER, 60);
			camp.Counts.Add(CATAPHRACT, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "30";
			camp.SectorId = 6;
			camp.Counts.Add(UPROARIOUS_BULL, 1);
			camp.Counts.Add(NOMAD, 70);
			camp.Counts.Add(LANCE_RIDER, 100);
			camp.Counts.Add(CATAPHRACT, 30);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.WitchTower;
			result.Add(camp);

			#endregion

			#region Sector 7
			camp = new Camp();
			camp.Name = "31";
			camp.SectorId = 7;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FIREDANCER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "32";
			camp.SectorId = 7;
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(FIREDANCER, 100);
			camp.Counts.Add(DARK_PRIEST, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "33";
			camp.SectorId = 7;
			camp.Counts.Add(CULTIST, 70);
			camp.Counts.Add(FIREDANCER, 80);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "34";
			camp.SectorId = 7;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(DARK_PRIEST, 20);
			camp.Counts.Add(SHADOWSNEAKER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "35";
			camp.SectorId = 7;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FIREDANCER, 120);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.WitchTower;
			result.Add(camp);

			#endregion

			#region Sector 8
			camp = new Camp();
			camp.Name = "36";
			camp.SectorId = 8;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FIREDANCER, 60);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "37";
			camp.SectorId = 8;
			camp.Counts.Add(CULTIST, 150);
			camp.Counts.Add(FIREDANCER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "38";
			camp.SectorId = 8;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FIREDANCER, 70);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.WitchTower;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}