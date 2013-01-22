namespace TheSettlersCalculator.Functions
{
	interface IFunction
	{
		double Evaluate(Statistics.MultiWaveStatistics battle);
		double Evaluate(Statistics.Statistics battle);
	}
}
