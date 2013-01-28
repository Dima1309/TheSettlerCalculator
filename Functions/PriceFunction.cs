using System;
using System.Collections.Generic;
using TheSettlersCalculator.Price;
using TheSettlersCalculator.Statistics;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Functions
{
	internal class PriceFunction : IFunction
	{
		#region Fields
		private readonly ICalculator m_calculator;
		#endregion

		#region Constructor
		internal PriceFunction(ICalculator calculator)
		{
			m_calculator = calculator;
		}
		#endregion

		#region Methods
		public double Evaluate(MultiWaveStatistics statistics)
		{
			throw new NotImplementedException();
		}

		public double Evaluate(Statistics.Statistics statistics)
		{
			//стоимость максимальных потерь + вероятность поражения (сумма(ср урон * общее здоровье))
			double calculatePrice = CalculatePrice(statistics);
			//Console.Write(calculatePrice);
			//Console.Write(" {0}/{1} = ", statistics.WinCount, statistics.Count);
			return calculatePrice +
				   (1 - statistics.WinCount / statistics.Count) * 1000000;
		}

		internal List<LossesProduct> CalculateLosses(IList<Unit> units, short[] losses)
		{
			SortedDictionary<ProductEnum, double> lossesPrice = new SortedDictionary<ProductEnum, double>();
			for(int i = 0; i < losses.Length; i++)
			{
				if (losses[i] == 0 || units[i].LossesProduct == null)
				{
					continue;
				}

				foreach(LossesProduct product in units[i].LossesProduct)
				{
					if (!lossesPrice.ContainsKey(product.Product.Index))
					{
						lossesPrice[product.Product.Index] = 0;
					}

					lossesPrice[product.Product.Index] += product.Count * losses[i];
				}
			}

			List<LossesProduct> result = new List<LossesProduct>(lossesPrice.Count);
			foreach(KeyValuePair<ProductEnum, double> pair in lossesPrice)
			{
				result.Add(new LossesProduct(pair.Key, pair.Value));
			}

			return result;
		}

		internal List<LossesProduct> CalculateLosses(IList<Unit> units, double[] losses)
		{
			SortedDictionary<ProductEnum, double> lossesPrice = new SortedDictionary<ProductEnum, double>();
			for(int i = 0; i < losses.Length; i++)
			{
				if (losses[i] == 0 || units[i].LossesProduct == null)
				{
					continue;
				}

				foreach(LossesProduct product in units[i].LossesProduct)
				{
					if (!lossesPrice.ContainsKey(product.Product.Index))
					{
						lossesPrice[product.Product.Index] = 0;
					}

					lossesPrice[product.Product.Index] += product.Count * losses[i];
				}
			}

			List<LossesProduct> result = new List<LossesProduct>(lossesPrice.Count);
			foreach(KeyValuePair<ProductEnum, double> pair in lossesPrice)
			{
				result.Add(new LossesProduct(pair.Key, pair.Value));
			}

			return result;
		}

		//private static double CalculateSurviveEnemyPrice(Statistics.Statistics statistics)
		//{
		//    double surviveEnemyPrice = 0;
		//    for(int i=0; i <statistics.MinDefenderResult.EnemyCounts.Length; i++)
		//    {
		//        double health = statistics.MinDefenderResult.EnemyCounts[i] * battle.EnemyUnits[i].Health;
		//        surviveEnemyPrice += health *
		//                  (battle.EnemyUnits[i].MinDamage * (1 - (double)battle.EnemyUnits[i].Accuracy / 100) +
		//                   battle.EnemyUnits[i].MaxDamage * (double) battle.EnemyUnits[i].Accuracy / 100);
		//    }

		//    double allEnemyPrice = 0;
		//    for(int i = 0; i < battle.EnemyCounts.Length; i++)
		//    {
		//        double health = battle.EnemyCounts[i] * battle.EnemyUnits[i].Health;

		//        allEnemyPrice += health *
		//                  (battle.EnemyUnits[i].MinDamage * (1 - (double)battle.EnemyUnits[i].Accuracy / 100) +
		//                   battle.EnemyUnits[i].MaxDamage * (double)battle.EnemyUnits[i].Accuracy / 100);
		//    }

		//    return surviveEnemyPrice;
		//}

		private static double CalculatePrice(Statistics.Statistics statistics)
		{
			double result = 0;
			
			for(int i = 0; i < statistics.AvgAttackerLosses.Length; i++)
			{
				if (statistics.AvgAttackerLosses[i] > 0)
				{
					//result += statistics.AvgAttackerLosses[i] * CalculatePlayerLossesPrice(statistics.Battle.Units[i]);
				}
			}

			return result;
		}
		#endregion
	}
}
