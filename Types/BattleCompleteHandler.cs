using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal class BattleCompleteArgs : EventArgs
	{
		private readonly Battle m_battle;
		private readonly IList<BattleStep> m_steps;

		public BattleCompleteArgs(Battle battle, IList<BattleStep> steps)
		{
			m_battle = battle;
			m_steps = steps;
		}

		public Battle Battle
		{
			get { return m_battle; }
		}

		public IList<BattleStep> Steps
		{
			get { return m_steps; }
		}
	}

	internal delegate void BattleCompleteHandler(object sender, BattleCompleteArgs args);
}
