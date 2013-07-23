using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class StealingfromtherichQuest : Quest
	{
		#region Constants
		private const int RECRUIT_DESERTER = 0;
		private const int MILITIA_DESERTER = 1;
		private const int CAVALRY_DESERTER = 2;
		private const int SOLDIER_DESERTER = 3;
		private const int ELITE_SOLDIER_DESERTER = 4;
		private const int BOWMAN_DESERTER = 5;
		private const int LONGBOW_DESERTER = 6;
		private const int CROSSBOW_DESERTER = 7;
		private const int CANNONEER_DESERTER = 8;
		private const int SIR_ROBIN = 9;
		private const int BIG_BERTHA = 10;
		private const int WOLF = 11;
		#endregion

		#region Constructor
		internal StealingfromtherichQuest()
		{
			Name = Resources.QUEST_STEALING_FROM_THE_RICH;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Beutelschneider.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.RECRUIT_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.MILITIA_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CAVALRY_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SOLDIER_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.ELITE_SOLDIER_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.BOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.LONGBOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CROSSBOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CANNONEER_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SIR_ROBIN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.BIG_BERTHA]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.WOLF]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W2";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W3";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(RECRUIT_DESERTER, 30);
			camp.Counts.Add(BOWMAN_DESERTER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(RECRUIT_DESERTER, 40);
			camp.Counts.Add(BOWMAN_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(RECRUIT_DESERTER, 85);
			camp.Counts.Add(BOWMAN_DESERTER, 65);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 2;
			camp.Counts.Add(WOLF, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W2";
			camp.SectorId = 2;
			camp.Counts.Add(WOLF, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W3";
			camp.SectorId = 2;
			camp.Counts.Add(WOLF, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W4";
			camp.SectorId = 2;
			camp.Counts.Add(WOLF, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 2;
			camp.Counts.Add(RECRUIT_DESERTER, 30);
			camp.Counts.Add(BOWMAN_DESERTER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 2;
			camp.Counts.Add(RECRUIT_DESERTER, 40);
			camp.Counts.Add(BOWMAN_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(RECRUIT_DESERTER, 65);
			camp.Counts.Add(BOWMAN_DESERTER, 85);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "W5";
			camp.SectorId = 3;
			camp.Counts.Add(WOLF, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 3;
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(MILITIA_DESERTER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(LONGBOW_DESERTER, 40);
			camp.Counts.Add(MILITIA_DESERTER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 3;
			camp.Counts.Add(LONGBOW_DESERTER, 40);
			camp.Counts.Add(MILITIA_DESERTER, 40);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "W4";
			camp.SectorId = 4;
			camp.Counts.Add(WOLF, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 4;
			camp.Counts.Add(LONGBOW_DESERTER, 40);
			camp.Counts.Add(MILITIA_DESERTER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 4;
			camp.Counts.Add(LONGBOW_DESERTER, 20);
			camp.Counts.Add(MILITIA_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 4;
			camp.Counts.Add(MILITIA_DESERTER, 40);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.Counts.Add(CAVALRY_DESERTER, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "W7";
			camp.SectorId = 5;
			camp.Counts.Add(WOLF, 140);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W6";
			camp.SectorId = 5;
			camp.Counts.Add(WOLF, 160);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 30);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(SOLDIER_DESERTER, 50);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 5;
			camp.Counts.Add(LONGBOW_DESERTER, 40);
			camp.Counts.Add(SOLDIER_DESERTER, 30);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.Counts.Add(CAVALRY_DESERTER, 30);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 6
			camp = new Camp();
			camp.Name = "W8";
			camp.SectorId = 6;
			camp.Counts.Add(WOLF, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W5";
			camp.SectorId = 6;
			camp.Counts.Add(WOLF, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 6;
			camp.Counts.Add(LONGBOW_DESERTER, 40);
			camp.Counts.Add(MILITIA_DESERTER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 6;
			camp.Counts.Add(LONGBOW_DESERTER, 80);
			camp.Counts.Add(SOLDIER_DESERTER, 20);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 6;
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.Counts.Add(ELITE_SOLDIER_DESERTER, 20);
			camp.Counts.Add(CROSSBOW_DESERTER, 20);
			camp.Counts.Add(CANNONEER_DESERTER, 20);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 7
			camp = new Camp();
			camp.Name = "W7";
			camp.SectorId = 7;
			camp.Counts.Add(WOLF, 140);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 15);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 15);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 15);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 15);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 7;
			camp.Counts.Add(LONGBOW_DESERTER, 50);
			camp.Counts.Add(SOLDIER_DESERTER, 50);
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.Counts.Add(BIG_BERTHA, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int) CampWinTime.WhiteCastle;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}