using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	interface ICalculator
	{
		event BattleCompleteHandler OnBattleComplete;

		void Calculate(Battle battle);
	}
}
