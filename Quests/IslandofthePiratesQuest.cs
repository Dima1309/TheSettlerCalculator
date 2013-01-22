using System.Collections.Generic;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class IslandofthePiratesQuest : Quest
	{
		#region Constants
		private const int CALTROP = 0;
		private const int DECKSCRUBBER = 1;
		private const int SABER_RATTLER = 2;
		private const int CRAZY_COOK = 3;
		private const int GUNMAN = 4;
		private const int KNIFETHROWER = 5;
		private const int PETTY_OFFICER_2ND_CLASS = 6;
		#endregion

		#region Constructor
		internal IslandofthePiratesQuest()
		{
			Name = Resources.QUEST_ISLAND_OF_THE_PIRATES;
			Units = InitializeUnits().ToArray();
			Camps = InitializeCamps().ToArray();

			Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Icons.Insel_der_Freibeuter.png");
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
			return units;
		}


		private static List<Camp> InitializeCamps()
		{
			List<Camp> result = new List<Camp>();
			#region Sector 1
			Camp camp = new Camp();
			camp.Name = "1";
			camp.SectorId = 1;
			camp.Counts.Add(DECKSCRUBBER, 100);
			camp.Counts.Add(GUNMAN, 50);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "2";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(DECKSCRUBBER, 100);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "3";
			camp.SectorId = 1;
			camp.Counts.Add(CALTROP, 50);
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(GUNMAN, 50);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 2
			camp = new Camp();
			camp.Name = "4";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 60);
			camp.Counts.Add(DECKSCRUBBER, 60);
			camp.Counts.Add(KNIFETHROWER, 60);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "5";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 40);
			camp.Counts.Add(SABER_RATTLER, 40);
			camp.Counts.Add(GUNMAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "6";
			camp.SectorId = 2;
			camp.Counts.Add(CALTROP, 80);
			camp.Counts.Add(SABER_RATTLER, 80);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 2);
			camp.CampType = CampType.Boss;
			result.Add(camp);

			#endregion

			#region Sector 3
			camp = new Camp();
			camp.Name = "W1";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 100);
			camp.CampType = CampType.Ambush;
			result.Add(camp);

			camp = new Camp();
			camp.Name = "7";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 90);
			camp.Counts.Add(SABER_RATTLER, 90);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "8";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 30);
			camp.Counts.Add(DECKSCRUBBER, 100);
			camp.Counts.Add(GUNMAN, 40);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "9";
			camp.SectorId = 3;
			camp.Counts.Add(CALTROP, 100);
			camp.Counts.Add(SABER_RATTLER, 70);
			result.Add(camp);

			camp = new Camp();
			camp.Name = "10";
			camp.SectorId = 3;
			camp.Counts.Add(SABER_RATTLER, 100);
			camp.Counts.Add(CRAZY_COOK, 1);
			camp.Counts.Add(GUNMAN, 70);
			camp.Counts.Add(PETTY_OFFICER_2ND_CLASS, 10);
			camp.CampType = CampType.Boss;
			result.Add(camp);
			#endregion

			return result;
		}

	}
}