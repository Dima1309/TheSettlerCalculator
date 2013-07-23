using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class TheDarkBrotherhoodQuest : Quest
	{
		#region Constants
		private const int NIGHT_SPAWN = 0;
		private const int CULTIST = 1;
		private const int SWAMP_WITCH = 2;
		private const int SHADOWSNEAKER = 3;
		private const int FANATIC = 4;
		private const int DARK_PRIEST = 5;
		private const int FIREDANCER = 6;
		private const int DANCING_DERVISH = 7;
		private const int DARK_HIGH_PRIEST = 8;
		#endregion

		#region Constructor
		internal TheDarkBrotherhoodQuest()
		{
			Name = Resources.QUEST_THE_DARK_BROTHERHOOD;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			IconPath = "TheSettlersCalculator.Quests.Icons.Die_dunkle_Bruderschaft.png";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.NIGHT_SPAWN]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.CULTIST]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SWAMP_WITCH]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.SHADOWS_NEAKER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.FANATIC]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.DARK_PRIEST]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.FIRE_DANCER]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.DANCING_DERVISH]);
			units.Add(EnemyUnits.Units[(int)EnemyUnitsEnum.DARK_HIGH_PRIEST]);
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1a
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FANATIC, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 1b
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 101;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FANATIC, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 101;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 1c
			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 201;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FANATIC, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 201;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 2a
			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 80);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 40);
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 2b
			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 102;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 80);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 102;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 40);
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 2c
			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 202;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 80);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 202;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(FANATIC, 40);
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 3a
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 120);
			camp.Counts.Add(DARK_PRIEST, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 70);
			camp.Counts.Add(DARK_PRIEST, 60);
			camp.Counts.Add(SHADOWSNEAKER, 70);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 3b
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 103;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 103;
			camp.Counts.Add(CULTIST, 120);
			camp.Counts.Add(DARK_PRIEST, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 103;
			camp.Counts.Add(CULTIST, 70);
			camp.Counts.Add(DARK_PRIEST, 60);
			camp.Counts.Add(SHADOWSNEAKER, 70);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 3c
			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 203;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 203;
			camp.Counts.Add(CULTIST, 120);
			camp.Counts.Add(DARK_PRIEST, 80);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 203;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(DARK_PRIEST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 4a
			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 4;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(DARK_PRIEST, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 4;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(DARK_PRIEST, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 4;
			camp.Counts.Add(DARK_PRIEST, 100);
			camp.Counts.Add(SHADOWSNEAKER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 4b
			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 104;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(DARK_PRIEST, 120);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 104;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(DARK_PRIEST, 150);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 104;
			camp.Counts.Add(CULTIST, 80);
			camp.Counts.Add(SHADOWSNEAKER, 120);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 5
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 5;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 5;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 5;
			camp.Counts.Add(CULTIST, 100);
			camp.Counts.Add(FANATIC, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 6
			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 6;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "16";
			camp.SectorId = 6;
			camp.Counts.Add(CULTIST, 200);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 6;
			camp.Counts.Add(CULTIST, 120);
			camp.Counts.Add(FANATIC, 80);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 16
			camp = new Camp();
			camp.Name = "17";
			camp.SectorId = 16;
			camp.Counts.Add(DARK_PRIEST, 75);
			camp.Counts.Add(SHADOWSNEAKER, 125);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "18";
			camp.SectorId = 16;
			camp.Counts.Add(CULTIST, 60);
			camp.Counts.Add(DARK_PRIEST, 70);
			camp.Counts.Add(SHADOWSNEAKER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "19";
			camp.SectorId = 16;
			camp.Counts.Add(DARK_PRIEST, 150);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "20";
			camp.SectorId = 16;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(FANATIC, 50);
			camp.Counts.Add(DARK_PRIEST, 50);
			camp.Counts.Add(SHADOWSNEAKER, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "21";
			camp.SectorId = 16;
			camp.Counts.Add(CULTIST, 60);
			camp.Counts.Add(DARK_PRIEST, 140);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "22";
			camp.SectorId = 16;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(FIREDANCER, 50);
			camp.Counts.Add(SHADOWSNEAKER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "23";
			camp.SectorId = 16;
			camp.Counts.Add(CULTIST, 50);
			camp.Counts.Add(DARK_PRIEST, 100);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.Counts.Add(SHADOWSNEAKER, 49);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 17
			camp = new Camp();
			camp.Name = "24";
			camp.SectorId = 17;
			camp.Counts.Add(CULTIST, 66);
			camp.Counts.Add(SWAMP_WITCH, 1);
			camp.Counts.Add(DARK_PRIEST, 66);
			camp.Counts.Add(FIREDANCER, 66);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 18
			camp = new Camp();
			camp.Name = "25";
			camp.SectorId = 18;
			camp.Counts.Add(CULTIST, 66);
			camp.Counts.Add(DARK_PRIEST, 66);
			camp.Counts.Add(SHADOWSNEAKER, 66);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "26";
			camp.SectorId = 18;
			camp.Counts.Add(CULTIST, 66);
			camp.Counts.Add(DARK_PRIEST, 66);
			camp.Counts.Add(FIREDANCER, 66);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 19
			camp = new Camp();
			camp.Name = "27";
			camp.SectorId = 19;
			camp.Counts.Add(CULTIST, 66);
			camp.Counts.Add(DARK_HIGH_PRIEST, 2);
			camp.Counts.Add(FIREDANCER, 66);
			camp.Counts.Add(DANCING_DERVISH, 66);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 20
			camp = new Camp();
			camp.Name = "28";
			camp.SectorId = 20;
			camp.Counts.Add(NIGHT_SPAWN, 2);
			camp.Counts.Add(FIREDANCER, 66);
			camp.Counts.Add(DANCING_DERVISH, 66);
			camp.Counts.Add(SHADOWSNEAKER, 66);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			return result;
		}

	}
}