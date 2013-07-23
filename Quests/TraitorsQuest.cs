using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class TraitorsQuest : Quest
	{
		#region Constants
		private const int MILITIA_DESERTER = 0;
		private const int CAVALRY_DESERTER = 1;
		private const int SOLDIER_DESERTER = 2;
		private const int LONGBOW_DESERTER = 3;
		private const int SIR_ROBIN = 4;
		private const int BIG_BERTHA = 5;
		#endregion

		#region Constructor
		internal TraitorsQuest()
		{
			Name = Resources.QUEST_TRAITORS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Verrater.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.MILITIA_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CAVALRY_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SOLDIER_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.LONGBOWMAN_DESERTER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SIR_ROBIN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.BIG_BERTHA]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 40);
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(MILITIA_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(SOLDIER_DESERTER, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(SOLDIER_DESERTER, 40);
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(SOLDIER_DESERTER, 60);
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(MILITIA_DESERTER, 40);
			camp.Counts.Add(CAVALRY_DESERTER, 40);
			camp.Counts.Add(SOLDIER_DESERTER, 20);
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(MILITIA_DESERTER, 60);
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(SOLDIER_DESERTER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(SOLDIER_DESERTER, 60);
			camp.Counts.Add(LONGBOW_DESERTER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 3;
			camp.Counts.Add(CAVALRY_DESERTER, 50);
			camp.Counts.Add(SOLDIER_DESERTER, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(SOLDIER_DESERTER, 100);
			camp.Counts.Add(LONGBOW_DESERTER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(CAVALRY_DESERTER, 60);
			camp.Counts.Add(SOLDIER_DESERTER, 60);
			camp.Counts.Add(LONGBOW_DESERTER, 60);
			camp.Counts.Add(SIR_ROBIN, 1);
			camp.Counts.Add(BIG_BERTHA, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.WhiteCastle;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}