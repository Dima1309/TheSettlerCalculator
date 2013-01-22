using System;
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
		public double Evaluate(Statistics.Statistics statistics)
		{
			//стоимость максимальных потерь + вероятность поражения (сумма(ср урон * общее здоровье))
			double calculatePrice = CalculatePrice(statistics, statistics);
			//Console.Write(calculatePrice);
			//Console.Write(" {0}/{1} = ", statistics.WinCount, statistics.Count);
			return calculatePrice +
				   (1 - statistics.WinCount / statistics.Count) * 1000000;
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

		private static double CalculatePrice( Statistics.Statistics statistics)
		{
			double result = 0;
			
			for(int i = 0; i < statistics.AvgAttackerLosses.Length; i++)
			{
				if (statistics.AvgAttackerLosses[i] > 0)
				{
					result += statistics.AvgAttackerLosses[i] * CalculatePlayerLossesPrice(statistics.Battle.Units[i]);
				}
			}

			return result;
		}

		private static double CalculatePlayerLossesPrice(Unit unit)
		{
			for(int i = 0; i < PlayerUnits.Units.Length; i++)
			{
				if (string.Equals(PlayerUnits.Units[i].Name, unit.Name, StringComparison.Ordinal))
				{
					//switch(i)
					//{
					//    case PlayerUnits.RECRUIT:
					//        return Prices.Settler + 5 * Prices.Beer + 10 * Prices.BronzeSwords;							
					//    case PlayerUnits.MILITIAMAN:
					//        return Prices.Settler + 10 * Prices.Beer + 10 * Prices.IronSwords;
					//    case PlayerUnits.SOLDIER:
					//        return Prices.Settler + 15 * Prices.Beer + 10 * Prices.SteelSwords;
					//    case PlayerUnits.ELITE_SOLDIER:
					//        return Prices.Settler + 50 * Prices.Beer + 10 * Prices.DamascusSwords;
					//    case PlayerUnits.CAVALRY:
					//        return Prices.Settler + 30 * Prices.Beer + 40 * Prices.Horses;
					//    case PlayerUnits.ARCHER:
					//        return Prices.Settler + 10 * Prices.Beer + 10 * Prices.Bow;
					//    case PlayerUnits.LONG_BOW_ARCHER:
					//        return Prices.Settler + 20 * Prices.Beer + 10 * Prices.LongBow;
					//    case PlayerUnits.ARBALESTER:
					//        return Prices.Settler + 50 * Prices.Beer + 10 * Prices.Crossbow;
					//    case PlayerUnits.CANNONEER:
					//        return Prices.Settler + 50 * Prices.Beer + 10 * Prices.Cannons;
					//}
				}
			}

			return 0;
		}
		#endregion
	}
}
