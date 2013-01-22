using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class GunpowderQuest : Quest
	{
		#region Constants
		private const int MILITIA_DESERTER = 0;
		private const int CAVALRY_DESERTER = 1;
		private const int SOLDIER_DESERTER = 2;
		private const int ELITE_SOLDIER_DESERTER = 3;
		private const int BOWMAN_DESERTER = 4;
		private const int LONGBOW_DESERTER = 5;
		private const int CROSSBOW_DESERTER = 6;
		private const int CANNONEER_DESERTER = 7;
		private const int BIG_BERTHA = 8;
		#endregion

		#region Constructor
		internal GunpowderQuest()
		{
			Name = Resources.QUEST_GUNPOWDER;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Schiespulver.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.MILITIA_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.CAVALRY_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.SOLDIER_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.ELITE_SOLDIER_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.BOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.LONGBOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.CROSSBOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.CANNONEER_DESERTER]);
			units.Add(EnemyUnits.Units[EnemyUnits.BIG_BERTHA]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(BOWMAN_DESERTER, 50);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 60);
			camp.Counts.Add(BOWMAN_DESERTER, 120);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 80);
			camp.Counts.Add(BOWMAN_DESERTER, 40);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 50);
			camp.Counts.Add(BOWMAN_DESERTER, 70);
			camp.Counts.Add(CAVALRY_DESERTER, 80);
			result.Add(camp);

			#endregion

			#region Sector 2
			camp.Name = "1";
			camp.SectorId = 2;
			camp.Counts.Add(MILITIA_DESERTER, 120);
			camp.Counts.Add(BOWMAN_DESERTER, 30);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 2;
			camp.Counts.Add(MILITIA_DESERTER, 90);
			camp.Counts.Add(BOWMAN_DESERTER, 90);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(BOWMAN_DESERTER, 40);
			camp.Counts.Add(CAVALRY_DESERTER, 30);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp.Name = "1";
			camp.SectorId = 3;
			camp.Counts.Add(MILITIA_DESERTER, 90);
			camp.Counts.Add(BOWMAN_DESERTER, 60);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 3;
			camp.Counts.Add(MILITIA_DESERTER, 90);
			camp.Counts.Add(BOWMAN_DESERTER, 90);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 3;
			camp.Counts.Add(MILITIA_DESERTER, 90);
			camp.Counts.Add(BOWMAN_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 30);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "4";
			camp.SectorId = 3;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(BOWMAN_DESERTER, 100);
			result.Add(camp);

			#endregion

			#region Sector 4
			camp.Name = "5";
			camp.SectorId = 4;
			camp.Counts.Add(MILITIA_DESERTER, 60);
			camp.Counts.Add(BOWMAN_DESERTER, 80);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			result.Add(camp);

			camp.Name = "6";
			camp.SectorId = 4;
			camp.Counts.Add(MILITIA_DESERTER, 80);
			camp.Counts.Add(LONGBOW_DESERTER, 80);
			camp.Counts.Add(CAVALRY_DESERTER, 20);
			result.Add(camp);

			camp.Name = "7";
			camp.SectorId = 4;
			camp.Counts.Add(MILITIA_DESERTER, 50);
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(CAVALRY_DESERTER, 70);
			result.Add(camp);

			camp.Name = "8";
			camp.SectorId = 4;
			camp.Counts.Add(LONGBOW_DESERTER, 70);
			camp.Counts.Add(SOLDIER_DESERTER, 50);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp.Name = "9";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 75);
			camp.Counts.Add(SOLDIER_DESERTER, 75);
			result.Add(camp);

			camp.Name = "10";
			camp.SectorId = 5;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			result.Add(camp);

			camp.Name = "11";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 70);
			camp.Counts.Add(SOLDIER_DESERTER, 70);
			camp.Counts.Add(CAVALRY_DESERTER, 40);
			result.Add(camp);

			camp.Name = "12";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 6
			camp.Name = "13";
			camp.SectorId = 6;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 100);
			result.Add(camp);

			camp.Name = "14";
			camp.SectorId = 6;
			camp.Counts.Add(LONGBOW_DESERTER, 70);
			camp.Counts.Add(SOLDIER_DESERTER, 80);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			result.Add(camp);

			camp.Name = "15";
			camp.SectorId = 6;
			camp.Counts.Add(LONGBOW_DESERTER, 80);
			camp.Counts.Add(SOLDIER_DESERTER, 120);
			result.Add(camp);

			camp.Name = "16";
			camp.SectorId = 6;
			camp.Counts.Add(SOLDIER_DESERTER, 200);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 7
			camp.Name = "17";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 70);
			camp.Counts.Add(SOLDIER_DESERTER, 130);
			result.Add(camp);

			camp.Name = "18";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			result.Add(camp);

			camp.Name = "19";
			camp.SectorId = 7;
			camp.Counts.Add(SOLDIER_DESERTER, 150);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			result.Add(camp);

			camp.Name = "20";
			camp.SectorId = 7;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CROSSBOW_DESERTER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 8
			camp.Name = "21";
			camp.SectorId = 8;
			camp.Counts.Add(SOLDIER_DESERTER, 80);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			result.Add(camp);

			camp.Name = "22";
			camp.SectorId = 8;
			camp.Counts.Add(SOLDIER_DESERTER, 90);
			camp.Counts.Add(CROSSBOW_DESERTER, 90);
			result.Add(camp);

			camp.Name = "23";
			camp.SectorId = 8;
			camp.Counts.Add(SOLDIER_DESERTER, 80);
			camp.Counts.Add(CAVALRY_DESERTER, 40);
			camp.Counts.Add(CROSSBOW_DESERTER, 80);
			result.Add(camp);

			camp.Name = "24";
			camp.SectorId = 8;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 40);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 9
			camp.Name = "25";
			camp.SectorId = 9;
			camp.Counts.Add(SOLDIER_DESERTER, 120);
			camp.Counts.Add(CROSSBOW_DESERTER, 80);
			result.Add(camp);

			camp.Name = "26";
			camp.SectorId = 9;
			camp.Counts.Add(SOLDIER_DESERTER, 130);
			camp.Counts.Add(CAVALRY_DESERTER, 70);
			result.Add(camp);

			camp.Name = "27";
			camp.SectorId = 9;
			camp.Counts.Add(SOLDIER_DESERTER, 200);
			result.Add(camp);

			camp.Name = "28";
			camp.SectorId = 9;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CROSSBOW_DESERTER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 10
			camp.Name = "29";
			camp.SectorId = 10;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 40);
			result.Add(camp);

			camp.Name = "30";
			camp.SectorId = 10;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 50);
			camp.Counts.Add(CANNONEER_DESERTER, 50);
			result.Add(camp);

			camp.Name = "31";
			camp.SectorId = 10;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 50);
			camp.Counts.Add(CROSSBOW_DESERTER, 70);
			result.Add(camp);

			camp.Name = "32";
			camp.SectorId = 10;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			result.Add(camp);

			camp.Name = "33";
			camp.SectorId = 10;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 50);
			camp.Counts.Add(CANNONEER_DESERTER, 20);
			camp.Counts.Add(CROSSBOW_DESERTER, 50);
			camp.Counts.Add(BIG_BERTHA, 2);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.BlackCastle;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}