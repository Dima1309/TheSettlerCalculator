namespace TheSettlersCalculator.Types
{
	interface ICalculator
	{
		event BattleCompleteHandler OnBattleComplete;

		int IterationCount { get; set; }

		void Calculate(Battle battle);
	}
}
