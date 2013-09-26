using TheSettlersCalculator.Price;
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
		internal const int CANNONEER = 8;
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
					s_general.Name = Resources.UNIT_GENERAL;
					s_general.Health = 1;
					s_general.MinDamage = 120;
					s_general.MaxDamage = 120;
					s_general.Accuracy = 100;
					s_general.AttackPriority = AttackPriority.Normal;
					s_general.IconPath = "Quests\\Images\\general.png";
				}
				
				return s_general;
			}
		}

		private static void InitializeUnits()
		{				
			s_units = new Unit[9];
			s_units[RECRUIT] = EnemyUnits.Units["RECRUIT"];
			s_units[MILITIAMAN] = EnemyUnits.Units["MILITIA"];
			s_units[SOLDIER] = EnemyUnits.Units["SOLDIER"];
			s_units[ELITE_SOLDIER] = EnemyUnits.Units["ELITE_SOLDIER"];
			s_units[CAVALRY] = EnemyUnits.Units["CAVALRY"];
			s_units[ARCHER] = EnemyUnits.Units["BOWMAN"];
			s_units[LONG_BOW_ARCHER] = EnemyUnits.Units["LONGBOWMAN"];
			s_units[ARBALESTER] = EnemyUnits.Units["CROSSBOWMAN"];
			s_units[CANNONEER] = EnemyUnits.Units["CANNONEER"];
		}
	}
}
