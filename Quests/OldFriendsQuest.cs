using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class OldFriendsQuest : Quest
	{
		#region Constants
		private const int CULTIST = 0;
		private const int SWAMP_WITCH = 1;
		private const int SHADOWSNEAKER = 2;
		private const int DARK_PRIEST = 3;
		private const int FIREDANCER = 4;
		private const int DANCING_DERVISH = 5;
		private const int DARK_HIGH_PRIEST = 6;
		#endregion

		#region Constructor
		internal OldFriendsQuest()
		{
			Name = Resources.QUEST_OLD_FRIENDS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			//Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons..png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.CULTIST]);
			units.Add(EnemyUnits.Units[EnemyUnits.SWAMP_WITCH]);
			units.Add(EnemyUnits.Units[EnemyUnits.SHADOWS_NEAKER]);
			units.Add(EnemyUnits.Units[EnemyUnits.DARK_PRIEST]);
			units.Add(EnemyUnits.Units[EnemyUnits.FIRE_DANCER]);
			units.Add(EnemyUnits.Units[EnemyUnits.DANCING_DERVISH]);
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
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(DARK_PRIEST, 50);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.Counts.Add(DARK_PRIEST, 40);
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.Counts.Add(FIREDANCER, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp.Name = "4";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			result.Add(camp);

			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 70);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			camp.Counts.Add(FIREDANCER, 10);
			result.Add(camp);

			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(DARK_PRIEST, 50);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.ChurchOfBones;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			camp.Counts.Add(DANCING_DERVISH, 20);
			result.Add(camp);

			camp.Name = "8";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(SWAMP_WITCH, 1);
			camp.Counts.Add(DARK_PRIEST, 50);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.CampType = CampType.Boss;
			camp.WinTime = (int)CampWinTime.WitchTower;
			result.Add(camp);

			#endregion
			return result;
		}

	}
}