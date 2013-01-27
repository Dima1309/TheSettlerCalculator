namespace TheSettlersCalculator.Functions
{
	interface IFunction
	{
		double Evaluate(Statistics.MultiWaveStatistics statistics);
		double Evaluate(Statistics.Statistics statistics);
	}
}
