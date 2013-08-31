using System;
using System.Collections.Generic;
using TheSettlersCalculator.Statistics;

namespace TheSettlersCalculator.Functions
{
	internal class BattleTimeFunction : IFunction
	{
		#region Constants
		private const int ROUND_TIME = 20;
		#endregion

		public double Evaluate(MultiWaveStatistics statistics)
		{
			throw new NotImplementedException();			
		}

		public double Evaluate(Statistics.Statistics statistics)
		{
			throw new NotImplementedException();
		}

		internal void CalculateBattleTime(
			Statistics.Statistics statistics, 
			out double minBattleTime, 
			out double maxBattleTime,
			out double avgBattleTime)
		{
			minBattleTime = double.MaxValue;
			maxBattleTime = 0;
			avgBattleTime = 0;
			double battleCount = 0;

			foreach(KeyValuePair<int, int> roundStatistic in statistics.RoundStatistics)
			{
				double time = Math.Abs(roundStatistic.Key) * ROUND_TIME + (roundStatistic.Key > 0
				              	? statistics.Battle.WinBattleTime
				              	: 0);
				minBattleTime = Math.Min(minBattleTime, time);
				maxBattleTime = Math.Max(maxBattleTime, time);
				avgBattleTime = battleCount / (battleCount + roundStatistic.Value) * avgBattleTime +
				                roundStatistic.Value / (battleCount + roundStatistic.Value) * time;
				battleCount += roundStatistic.Value;
			}
		}
	}
}
