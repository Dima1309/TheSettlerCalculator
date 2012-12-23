using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Types
{
	internal static class PlayerUnits 
	{
		#region Constants
		internal const int GENERAL = -1;
		internal const int RECRUIT = 0;
		internal const int MILITIAMAN = 1;
		internal const int SOLDIER = 2;
		internal const int ELITE_SOLDIER = 3;
		internal const int CAVALRY = 4;
		internal const int ARCHER = 5;
		internal const int LONG_BOW_ARCHER = 6;
		internal const int ARBALESTER = 7;
		internal const int CANNONEER = 9;
		#endregion

		#region Fields
		private static Unit[] s_units;
		private static Unit s_general;
		#endregion

		public static Unit[] Units
		{
			get
			{
				if (s_units == null)
				{
					InitializeUnits();
				}

				return s_units;
			}
		}

		public static Unit General
		{
			get
			{
				if (s_general == null)
				{
					s_general = new Unit();
					s_general.Name = "Генерал";
					s_general.Health = 1;
					s_general.MinDamage = 120;
					s_general.MaxDamage = 120;
					s_general.Accuracy = 100;
					s_general.AttackPriority = AttackPriority.Normal;
					s_general.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.general.png");
				}
				
				return s_general;
			}
		}

		private static void InitializeUnits()
		{				
			s_units = new Unit[9];
			Unit unit = new Unit();
			unit.Name = Resources.UNIT_RECRUIT;
			unit.Health = 40;
			unit.MinDamage = 15;
			unit.MaxDamage = 30;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 2;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.recruit.png");
			s_units[0] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_MILITIA;
			unit.Health = 60;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 9;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.militia.png");
			s_units[1] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_SOLDIER;
			unit.Health = 90;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 85;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 10;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.soldier.png");
			s_units[2] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_ELITE_SOLDIER;
			unit.Health = 120;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 20;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.elitesoldier.png");
			s_units[3] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CAVALRY;
			unit.Health = 5;
			unit.MinDamage = 5;
			unit.MaxDamage = 10;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.AvantGarde;
			unit.Experience = 8;
			unit.AttackWeaknessTarget = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.cavalry.png");
			s_units[4] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_BOWMAN;
			unit.Health = 10;
			unit.MinDamage = 20;
			unit.MaxDamage = 40;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 3;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.bowman.png");
			s_units[5] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_LONGBOWMAN;
			unit.Health = 10;
			unit.MinDamage = 30;
			unit.MaxDamage = 60;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 8;
			unit.TowerBonus = true;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.longbowman.png");
			s_units[6] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CROSSBOWMAN;
			unit.Health = 10;
			unit.MinDamage = 45;
			unit.MaxDamage = 90;
			unit.Accuracy = 80;
			unit.AttackPriority = AttackPriority.Normal;
			unit.Experience = 20;
			unit.TowerBonus = true;			
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.crossbowman.png");
			s_units[7] = unit;

			unit = new Unit();
			unit.Name = Resources.UNIT_CANNONNEER;
			unit.Health = 60;
			unit.MinDamage = 60;
			unit.MaxDamage = 120;
			unit.Accuracy = 90;
			unit.AttackPriority = AttackPriority.RearGuard;
			unit.Experience = 30;
			unit.TowerBonus = true;
			unit.IgnoreTowerBonus = 100;
			unit.Icon = ImageHelper.LoadPng("TheSettlersCalculator.Quests.Images.cannoneer.png");
			s_units[8] = unit;
		}
	}
}
