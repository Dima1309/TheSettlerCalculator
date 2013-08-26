using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Quests
{
	internal class QuestComparerByName : IComparer<Quest>
	{
		public int Compare(Quest x, Quest y)
		{
			return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
		}
	}
}
