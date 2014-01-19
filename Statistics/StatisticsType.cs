using System;

namespace TheSettlersCalculator.Statistics
{
	[Flags]
	internal enum StatisticsType
	{
		Losses = 1,
		Rounds = 2,
		LossesPrice = 4,
		LossesRecoveryTime = 8,
		BattleTime = 16,
		All = Losses | Rounds | LossesPrice | LossesRecoveryTime | BattleTime
	}
}
