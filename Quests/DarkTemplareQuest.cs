using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class DarkTemplareQuest : Quest
	{
		#region Constants
		private const int THUG = 0;
		private const int GUARD_DOG = 1;
		private const int STONE_THROWER = 2;
		private const int RANGER = 3;
		private const int SKUNK = 4;
		private const int CULTIST = 5;
		private const int SWAMP_WITCH = 6;
		private const int SHADOWSNEAKER = 7;
		private const int FANATIC = 8;
		private const int DARK_PRIEST = 9;
		private const int FIRE_DANCER = 10;
		private const int DARK_HIGH_PRIEST = 11;
		private const int WOLF = 12;
		#endregion

		#region Constructor
		internal DarkTemplareQuest()
		{
			Name = Resources.QUEST_DIE_SCHWARZEN_PRIESTER;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Die_schwarzen_Priester.png");
			MapPath = "TheSettlersCalculator.Quests.Maps.die-schwarzen-priester.jpg";
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();

			units.Add(EnemyUnits.Units[EnemyUnits.THUG]);
			units.Add(EnemyUnits.Units[EnemyUnits.GUARD_DOG]);
			units.Add(EnemyUnits.Units[EnemyUnits.STONE_THROWER]);
			units.Add(EnemyUnits.Units[EnemyUnits.RANGER]);
			units.Add(EnemyUnits.Units[EnemyUnits.SKUNK]);
			units.Add(EnemyUnits.Units[EnemyUnits.CULTIST]);
			units.Add(EnemyUnits.Units[EnemyUnits.SWAMP_WITCH]);
			units.Add(EnemyUnits.Units[EnemyUnits.SHADOWS_NEAKER]);
			units.Add(EnemyUnits.Units[EnemyUnits.FANATIC]);
			units.Add(EnemyUnits.Units[EnemyUnits.DARK_PRIEST]);
			units.Add(EnemyUnits.Units[EnemyUnits.FIRE_DANCER]);
			units.Add(EnemyUnits.Units[EnemyUnits.DARK_HIGH_PRIEST]);
			units.Add(EnemyUnits.Units[EnemyUnits.WOLF]);

			return units;
		}

		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector1
			Camp camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 1;			
			camp.Counts.Add(WOLF, 50);
			camp.Left = 400;
			camp.Top = 345;
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W2";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 50);
			camp.Left = 530;
			camp.Top = 350;
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W3";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 40);
			camp.Left = 590;
			camp.Top = 320;
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "W4";
			camp.SectorId = 1;
			camp.Counts.Add(WOLF, 30);
			camp.Left = 380;
			camp.Top = 190;
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 10);
			camp.Counts.Add(GUARD_DOG, 15);
			camp.Left = 314;
			camp.Top = 311;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 10);
			camp.Counts.Add(STONE_THROWER, 15);
			camp.Left = 238;
			camp.Top = 231;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 10);
			camp.Counts.Add(STONE_THROWER, 15);
			camp.Left = 531;
			camp.Top = 315;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 20);
			camp.Counts.Add(RANGER, 10);
			camp.Left = 411;
			camp.Top = 222;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 20);
			camp.Counts.Add(GUARD_DOG, 10);
			camp.Left = 464;
			camp.Top = 241;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(THUG, 20);
			camp.Counts.Add(RANGER, 20);
			camp.Counts.Add(GUARD_DOG, 20);
			camp.Counts.Add(SKUNK, 1);
			camp.CampType = CampType.Boss;
			camp.Left = 464;
			camp.Top = 200;
			result.Add(camp);
			#endregion

			#region Sector2
			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(CULTIST, 30);
			camp.Left = 308;
			camp.Top = 94;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(DARK_PRIEST, 30);
			camp.Counts.Add(SHADOWSNEAKER, 30);
			camp.Left = 246;
			camp.Top = 99;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(CULTIST, 30);
			camp.Counts.Add(SHADOWSNEAKER, 20);
			camp.Counts.Add(FIRE_DANCER, 10);
			camp.Left = 212;
			camp.Top = 131;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 2;
			camp.Counts.Add(DARK_PRIEST, 30);
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 20);
			camp.Counts.Add(SWAMP_WITCH, 1);
			camp.CampType = CampType.Boss;
			camp.Left = 143;
			camp.Top = 143;
			result.Add(camp);
			#endregion

			#region Sector3
			camp = new Camp();
			camp.Name = "11";
			camp.SectorId = 3;
			camp.Counts.Add(DARK_PRIEST, 20);
			camp.Counts.Add(CULTIST, 60);
			camp.Left = 748;
			camp.Top = 172;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "12";
			camp.SectorId = 3;
			camp.Counts.Add(CULTIST, 25);
			camp.Counts.Add(SHADOWSNEAKER, 25);
			camp.Counts.Add(FANATIC, 30);
			camp.Counts.Add(FIRE_DANCER, 10);
			camp.CampType = CampType.Boss;
			camp.Left = 755;
			camp.Top = 117;
			result.Add(camp);
			#endregion

			#region Sector4
			camp = new Camp();
			camp.Name = "13";
			camp.SectorId = 4;
			camp.Counts.Add(SHADOWSNEAKER, 30);
			camp.Counts.Add(FANATIC, 50);
			camp.Counts.Add(FIRE_DANCER, 10);
			camp.CampType = CampType.Boss;
			camp.Left = 589;
			camp.Top = 92;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "14";
			camp.SectorId = 4;
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 30);
			camp.Left = 567;
			camp.Top = 137;
			result.Add(camp);
			#endregion

			#region Sector5
			camp = new Camp();
			camp.Name = "15";
			camp.SectorId = 5;
			camp.Counts.Add(DARK_PRIEST, 40);
			camp.Counts.Add(CULTIST, 40);
			camp.Counts.Add(SHADOWSNEAKER, 40);
			camp.Counts.Add(DARK_HIGH_PRIEST, 1);
			camp.CampType = CampType.Boss;
			camp.Left = 683;
			camp.Top = 65;
			result.Add(camp);
			#endregion

			return result;
		}
	}
}
