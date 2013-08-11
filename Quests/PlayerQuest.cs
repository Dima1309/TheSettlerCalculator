using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSettlersCalculator.Properties;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	internal class PlayerQuest : Quest
	{
		#region Constructor
		internal PlayerQuest()
		{
			Name = Resources.QUEST_PLAYER;
			Units = InitializeUnits().ToArray();

			//Icon = ImageHelper.LoadFromResources("TheSettlersCalculator.Quests.Icons.Das_Banditennest.png");
		}
		#endregion

		private static List<Unit> InitializeUnits()
		{
			List<Unit> units = new List<Unit>();
			units.Add(PlayerUnits.Units[PlayerUnits.RECRUIT]);
			units.Add(PlayerUnits.Units[PlayerUnits.MILITIAMAN]);
			units.Add(PlayerUnits.Units[PlayerUnits.SOLDIER]);
			units.Add(PlayerUnits.Units[PlayerUnits.ELITE_SOLDIER]);
			units.Add(PlayerUnits.Units[PlayerUnits.CAVALRY]);
			units.Add(PlayerUnits.Units[PlayerUnits.ARCHER]);
			units.Add(PlayerUnits.Units[PlayerUnits.LONG_BOW_ARCHER]);
			units.Add(PlayerUnits.Units[PlayerUnits.ARBALESTER]);
			units.Add(PlayerUnits.Units[PlayerUnits.CANNONEER]);
			return units;
		}
	}
}
