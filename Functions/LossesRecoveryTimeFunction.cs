using System;
using System.Collections.Generic;
using TheSettlersCalculator.Statistics;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Functions
{
	internal class LossesRecoveryTimeFunction : IFunction
	{
		public double Evaluate(MultiWaveStatistics statistics)
		{
			throw new NotImplementedException();
		}

		public double Evaluate(Statistics.Statistics statistics)
		{
			throw new NotImplementedException();
		}

		internal double CalculateTime(IList<Unit> units, short[] losses)
		{
			double result = 0;

			for(int i = 0; i < losses.Length; i++)
			{
				if (losses[i] == 0 && units[i] == null)
				{
					continue;
				}

				result += units[i].ProductionTime * losses[i];
			}

			return result / Options.Instance.BaracksLevel;
		}

		internal double CalculateTime(IList<Unit> units, double[] losses)
		{
			double result = 0;

			for (int i = 0; i < losses.Length; i++)
			{
				if (losses[i] == 0 && units[i] == null)
				{
					continue;
				}

				result += units[i].ProductionTime * losses[i];
			}

			return result / Options.Instance.BaracksLevel;
		}
	}
}
