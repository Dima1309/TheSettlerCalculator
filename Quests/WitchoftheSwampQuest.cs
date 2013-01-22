using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class WitchoftheSwampQuest : Quest
	{
		#region Constants
		private const int CULTIST = 0;
		private const int SWAMP_WITCH = 1;
		private const int SHADOWSNEAKER = 2;
		private const int FANATIC = 3;
		private const int DARK_PRIEST = 4;
		private const int DARK_HIGH_PRIEST = 5;
		#endregion

		#region Constructor
		internal WitchoftheSwampQuest()
		{
			Name = Resources.QUEST_WITCH_OF_THE_SWAMP;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Sumpfhexe.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.CULTIST]);
			units.Add(EnemyUnits.Units[EnemyUnits.SWAMP_WITCH]);
			units.Add(EnemyUnits.Units[EnemyUnits.SHADOWS_NEAKER]);
			units.Add(EnemyUnits.Units[EnemyUnits.FANATIC]);
			units.Add(EnemyUnits.Units[EnemyUnits.DARK_PRIEST]);
			units.Add(EnemyUnits.Units[EnemyUnits.DARK_HIGH_PRIEST]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(CULTIST, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(FANATIC, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 3;
			camp.Counts.Add(SHADOWSNEAKER, 60);
			camp.Counts.Add(DARK_PRIEST, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 33);
			camp.Counts.Add(SHADOWSNEAKER, 33);
			camp.Counts.Add(DARK_PRIEST, 33);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 4
			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 4;
			camp.Counts.Add(CULTIST, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 4;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(DARK_PRIEST, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 4;
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 120);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 5;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SWAMP_WITCH, 1);
			camp.Counts.Add(DARK_PRIEST, 99);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int) CampWinTime.WitchTower;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}