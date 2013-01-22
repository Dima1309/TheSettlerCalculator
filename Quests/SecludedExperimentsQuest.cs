using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class SecludedExperimentsQuest : Quest
	{
		#region Constants
		private const int CALTROP = 0;
		private const int DECKSCRUBBER = 1;
		private const int SABER_RATTLER = 2;
		private const int CRAZY_COOK = 3;
		private const int GUNMAN = 4;
		private const int KNIFETHROWER = 5;
		private const int PETTY_OFFICER_2ND_CLASS = 6;
		private const int UPROARIOUS_BULL = 7;
		#endregion

		#region Constructor
		internal SecludedExperimentsQuest()
		{
			Name = Resources.QUEST_SECLUDED_EXPERIMENTS;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Einsame_Experimente.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(EnemyUnits.Units[EnemyUnits.CALTROP]);
			units.Add(EnemyUnits.Units[EnemyUnits.DECKSCRUBBER]);
			units.Add(EnemyUnits.Units[EnemyUnits.SABER_RATTLER]);
			units.Add(EnemyUnits.Units[EnemyUnits.CRAZY_COOK]);
			units.Add(EnemyUnits.Units[EnemyUnits.GUNMAN]);
			units.Add(EnemyUnits.Units[EnemyUnits.KNIFETHROWER]);
			units.Add(EnemyUnits.Units[EnemyUnits.PETTY_OFFICER_2ND_CLASS]);
			units.Add(EnemyUnits.Units[EnemyUnits.UPROARIOUS_BULL]);
			return units;
		}

		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();

			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(GUNMAN, 100);
			result.Add(camp);

			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 150);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "4";
			camp.SectorId = 1;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(GUNMAN, 100);
			result.Add(camp);

			camp.Name = "5";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 150);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "6";
			camp.SectorId = 1;
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);
			#endregion

			#region Sector 2
			camp.Name = "7";
			camp.SectorId = 2;
			camp.Counts.Add(GUNMAN, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);
		
			camp.Name = "8";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(GUNMAN, 150);
			result.Add(camp);

			camp.Name = "9";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "10";
			camp.SectorId = 2;
			camp.Counts.Add(GUNMAN, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "11";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 150);
			result.Add(camp);

			camp.Name = "12";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "13";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);
			#endregion

			#region Sector 3
			camp.Name = "14";
			camp.SectorId = 3;
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 110);
			result.Add(camp);

			camp.Name = "15";
			camp.SectorId = 3;
			camp.Counts.Add(CRAZY_COOK, 2);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "16";
			camp.SectorId = 3;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			result.Add(camp);

			camp.Name = "17";
			camp.SectorId = 3;
			camp.Counts.Add(GUNMAN, 200);
			result.Add(camp);

			camp.Name = "18";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 150);
			result.Add(camp);

			camp.Name = "19";
			camp.SectorId = 3;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(GUNMAN, 100);
			result.Add(camp);

			camp.Name = "20";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			result.Add(camp);

			camp.Name = "21";
			camp.SectorId = 3;
			camp.Counts.Add(SABER_RATTLER, 200);
			result.Add(camp);

			camp.Name = "22";
			camp.SectorId = 3;
			camp.Counts.Add(CRAZY_COOK, 2);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "23";
			camp.SectorId = 3;
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			camp.Counts.Add(GUNMAN, 100);
			result.Add(camp);

			camp.Name = "24";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 150);
			result.Add(camp);

			camp.Name = "25";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "26";
			camp.SectorId = 3;
			camp.Counts.Add(CRAZY_COOK, 3);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			#region Sector 4
			camp.Name = "28";
			camp.SectorId = 4;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "29";
			camp.SectorId = 4;
			camp.Counts.Add(SABER_RATTLER, 200);
			result.Add(camp);

			camp.Name = "30";
			camp.SectorId = 4;
			camp.Counts.Add(CRAZY_COOK, 3);
			camp.Counts.Add(GUNMAN, 150);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "31";
			camp.SectorId = 4;
			camp.Counts.Add(DECKSCRUBBER, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);			
			result.Add(camp);

			camp.Name = "32";
			camp.SectorId = 4;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);
			#endregion

			#region Sector 5
			camp.Name = "33";
			camp.SectorId = 5;
			camp.Counts.Add(GUNMAN, 100);
			camp.Counts.Add(SABER_RATTLER, 100);
			result.Add(camp);

			camp.Name = "34";
			camp.SectorId = 5;
			camp.Counts.Add(DECKSCRUBBER, 50);
			camp.Counts.Add(SABER_RATTLER, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "35";
			camp.SectorId = 5;
			camp.Counts.Add(DECKSCRUBBER, 50);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "36";
			camp.SectorId = 5;
			camp.Counts.Add(CALTROP, 75);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			//camp.Name = "";
			//camp.SectorId = 1;
			//camp.Counts.Add(KNIFETHROWER, 50);
			//camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			//result.Add(camp);
			#endregion

			#region Sector 6
			camp.Name = "37";
			camp.SectorId = 6;
			camp.Counts.Add(SABER_RATTLER, 75);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "38";
			camp.SectorId = 6;
			camp.Counts.Add(DECKSCRUBBER, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "39";
			camp.SectorId = 6;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "40";
			camp.SectorId = 6;
			camp.Counts.Add(SABER_RATTLER, 50);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "41";
			camp.SectorId = 6;
			camp.Counts.Add(SABER_RATTLER, 75);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "42";
			camp.SectorId = 6;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			camp.Counts.Add(UPROARIOUS_BULL, 2);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "43";
			camp.SectorId = 6;
			camp.Counts.Add(GUNMAN, 200);
			result.Add(camp);

			camp.Name = "44";
			camp.SectorId = 6;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(CRAZY_COOK, 2);
			camp.Counts.Add(GUNMAN, 100);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "45";
			camp.SectorId = 6;
			camp.Counts.Add(SABER_RATTLER, 200);
			result.Add(camp);

			camp.Name = "46";
			camp.SectorId = 6;
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 125);
			result.Add(camp);
			#endregion

			#region Secrtor 7
			camp.Name = "27";
			camp.SectorId = 7;
			camp.Counts.Add(SABER_RATTLER, 150);
			camp.Counts.Add(CRAZY_COOK, 3);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "47";
			camp.SectorId = 7;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 150);
			result.Add(camp);

			camp.Name = "48";
			camp.SectorId = 7;
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 125);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "49";
			camp.SectorId = 7;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "50";
			camp.SectorId = 7;
			camp.Counts.Add(SABER_RATTLER, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "51";
			camp.SectorId = 7;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 125);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "52";
			camp.SectorId = 7;
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "53";
			camp.SectorId = 7;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "54";
			camp.SectorId = 7;
			camp.Counts.Add(DECKSCRUBBER, 100);
			camp.Counts.Add(SABER_RATTLER, 100);
			result.Add(camp);

			camp.Name = "55";
			camp.SectorId = 7;
			camp.Counts.Add(SABER_RATTLER, 75);
			camp.Counts.Add(GUNMAN, 75);
			camp.Counts.Add(UPROARIOUS_BULL, 2);
			result.Add(camp);

			camp.Name = "56";
			camp.SectorId = 7;
			camp.Counts.Add(SABER_RATTLER, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);
			#endregion

			#region Sector 8
			camp.Name = "57";
			camp.SectorId = 8;
			camp.Counts.Add(GUNMAN, 75);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "58";
			camp.SectorId = 8;
			camp.Counts.Add(GUNMAN, 75);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 75);
			result.Add(camp);

			camp.Name = "59";
			camp.SectorId = 8;
			camp.Counts.Add(SABER_RATTLER, 200);
			result.Add(camp);

			camp.Name = "60";
			camp.SectorId = 8;
			camp.Counts.Add(SABER_RATTLER, 125);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(UPROARIOUS_BULL, 2);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			camp.Name = "61";
			camp.SectorId = 8;
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 100);
			result.Add(camp);

			camp.Name = "62";
			camp.SectorId = 8;
			camp.Counts.Add(GUNMAN, 100);
			result.Add(camp);

			camp.Name = "63";
			camp.SectorId = 8;
			camp.Counts.Add(CRAZY_COOK, 3);
			camp.Counts.Add(GUNMAN, 50);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 125);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			return result;
		}

	}
}