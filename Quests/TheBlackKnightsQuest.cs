using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class TheBlackKnightsQuest : Quest
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
		private const int SIR_ROBIN = 8;
		private const int BIG_BERTHA = 9;
		#endregion

		#region Constructor
		internal TheBlackKnightsQuest()
		{
			Name = Resources.QUEST_THE_BLACK_KNIGHTS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Die_schwarzen_Ritter.png");
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
			units.Add(EnemyUnits.Units[EnemyUnits.SIR_ROBIN]);
			units.Add(EnemyUnits.Units[EnemyUnits.BIG_BERTHA]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector 1a
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(LONGBOW_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(BOWMAN_DESERTER, 100);
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 1b
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 101;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(LONGBOW_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 101;
			camp.Counts.Add(BOWMAN_DESERTER, 100);
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 101;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 101;
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 1c
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 201;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(LONGBOW_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 201;
			camp.Counts.Add(BOWMAN_DESERTER, 100);
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 201;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 201;
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 50);
			camp.Counts.Add(CROSSBOW_DESERTER, 50);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.BlackCastle;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 10);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 3;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(CROSSBOW_DESERTER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 3;
			camp.Counts.Add(LONGBOW_DESERTER, 140);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 60);
			camp.Counts.Add(CANNONEER_DESERTER, 20);
			camp.Counts.Add(CROSSBOW_DESERTER, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 4;
			camp.Counts.Add(CAVALRY_DESERTER, 90);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 90);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 4;
			camp.Counts.Add(SOLDIER_DESERTER, 80);
			camp.Counts.Add(CROSSBOW_DESERTER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 4;
			camp.Counts.Add(SOLDIER_DESERTER, 110);
			camp.Counts.Add(CANNONEER_DESERTER, 25);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 4;
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 4;
			camp.Counts.Add(CAVALRY_DESERTER, 100);
			camp.Counts.Add(CROSSBOW_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 4;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(CROSSBOW_DESERTER, 75);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 4;
			camp.Counts.Add(MILITIA_DESERTER, 100);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 90);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 4;
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 50);
			camp.Counts.Add(CANNONEER_DESERTER, 25);
			camp.Counts.Add(CROSSBOW_DESERTER, 50);
			camp.Counts.Add(BIG_BERTHA, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int) CampWinTime.BlackCastle;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}