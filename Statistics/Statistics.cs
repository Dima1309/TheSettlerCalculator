using System;
using System.Collections.Generic;
using TheSettlersCalculator.Functions;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Statistics
{
	internal class Statistics
	{
		#region Fields
		private readonly Battle m_battle;
		//Key - round count, Value - count of battles
		private readonly Dictionary<int, int> m_roundStatistics = new Dictionary<int, int>();
		//Key - losses, Value - count or chance
		private readonly Dictionary<short[], double> m_attackerLossesStatistics = new Dictionary<short[], double>(new ShortArrayComparer());
		private readonly Dictionary<short[], double> m_defenderLossesStatistics = new Dictionary<short[], double>(new ShortArrayComparer());
		private bool m_isCountInAttackerLossesStatistics = true;
		private bool m_isCountInDefenderLossesStatistics = true;
		//Key - battle time, Value - chance
		private SortedDictionary<double, double> m_battleTimeStatistics = new SortedDictionary<double, double>();

		private short[] m_minAttackerLosses;
		private double[] m_avgAttackerLosses;
		private short[] m_maxAttackerLosses;
		private short[] m_minDefenderLosses;
		private double[] m_avgDefenderLosses;
		private short[] m_maxDefenderLosses;
		private int m_minRounds;
		private int m_maxRounds;
		private double m_avgRounds;
		private int m_winCount;
		private int m_count;

		private StatisticsLossesPrice m_losesPrice;

		private double m_minLossesRecoveryTime;
		private double m_maxLossesRecoveryTime;
		private double m_avgLossesRecoveryTime;

		private double m_minBattleTime;
		private double m_minBattleTimeChance;
		private double m_maxBattleTime;
		private double m_maxBattleTimeChance;
		private double m_avgBattleTime;
		#endregion

		#region Constructor
		internal Statistics(Battle battle)
		{
			m_battle = battle;
		}
		#endregion

		#region Properties
		internal Battle Battle
		{
			get { return m_battle; }
		}

		internal short[] MinAttackerLosses
		{
			get { return m_minAttackerLosses; }
		}

		internal double [] AvgAttackerLosses
		{
			get { return m_avgAttackerLosses; }
		}

		internal short[] MaxAttackerLosses
		{
			get { return m_maxAttackerLosses; }
		}

		internal short[] MinDefenderLosses
		{
			get { return m_minDefenderLosses; }
		}

		internal double[] AvgDefenderLosses
		{
			get { return m_avgDefenderLosses; }
		}

		internal short[] MaxDefenderLosses
		{
			get { return m_maxDefenderLosses; }
		}

		internal int Count
		{
			get { return m_count; }
		}

		internal int MinRounds
		{
			get { return m_minRounds; }
		}

		internal int MaxRounds
		{
			get { return m_maxRounds; }
		}

		internal double AvgRounds
		{
			get { return m_avgRounds; }
		}

		internal int WinCount
		{
			get { return m_winCount; }
		}

		public StatisticsLossesPrice LosesPrice
		{
			get { return m_losesPrice; }
		}

		public double MinLossesRecoveryTime
		{
			get { return m_minLossesRecoveryTime; }
		}

		public double MaxLossesRecoveryTime
		{
			get { return m_maxLossesRecoveryTime; }
		}

		public double AvgLossesRecoveryTime
		{
			get { return m_avgLossesRecoveryTime; }
		}

		public Dictionary<int, int> RoundStatistics
		{
			get { return m_roundStatistics; }
		}

		public double MinBattleTime
		{
			get { return m_minBattleTime; }
		}

		public double MaxBattleTime
		{
			get { return m_maxBattleTime; }
		}

		public double AvgBattleTime
		{
			get { return m_avgBattleTime; }
		}

		public double MinBattleTimeChance
		{
			get { return m_minBattleTimeChance; }
		}

		public double MaxBattleTimeChance
		{
			get { return m_maxBattleTimeChance; }
		}

		public SortedDictionary<double, double> BattleTimeStatistics
		{
			get { return m_battleTimeStatistics; }
		}
		#endregion

		#region Methods
		internal void BattleComplete(object sender, BattleCompleteArgs args)
		{
			m_count++;

			int rem;
			int rounds = Math.DivRem(args.Steps.Count - 1, 3, out rem);
			if (rem > 0)
			{
				rounds++;
			}

			BattleStep lastStep = args.Steps[args.Steps.Count - 1];
			short[] attackerLosses = new short[args.Battle.Units.Length];
			for (int i = 0; i < attackerLosses.Length; i++)
			{
				attackerLosses[i] = (short)(args.Battle.Sides[(int)BattleSideType.Player].Counts[i] -
									lastStep.Sides[(int)BattleSideType.Player].Counts[i]);
			}

			short[] defenderLosses = new short[args.Battle.EnemyUnits.Length];
			for (int i = 0; i < defenderLosses.Length; i++)
			{
				defenderLosses[i] = (short)(args.Battle.Sides[(int)BattleSideType.Enemy].Counts[i] -
									lastStep.Sides[(int)BattleSideType.Enemy].Counts[i]);
			}

			bool winBattle = false;
			foreach (short attackerLoss in lastStep.Counts)
			{
				if (attackerLoss > 0)
				{
					winBattle = true;
					break;
				}
			}

			if (m_attackerLossesStatistics.ContainsKey(attackerLosses))
			{
				m_attackerLossesStatistics[attackerLosses] += 1;
			}
			else
			{
				m_attackerLossesStatistics[attackerLosses] = 1;
			}

			if (m_defenderLossesStatistics.ContainsKey(defenderLosses))
			{
				m_defenderLossesStatistics[defenderLosses] += 1;
			}
			else
			{
				m_defenderLossesStatistics[defenderLosses] = 1;
			}

			if (!winBattle)
			{
				rounds = -rounds;
			}

			if (RoundStatistics.ContainsKey(rounds))
			{
				RoundStatistics[rounds] += 1;
			}
			else
			{
				RoundStatistics[rounds] = 1;
			}
		}

		/// <summary>
		/// Added statistic information for this battle.
		/// </summary>
		/// <param name="statistics">New statistis.</param>
		internal void AddStatistics(Statistics statistics)
		{
			if (statistics.m_count == 0)
			{
				return;
			}

			m_count += statistics.m_count;

			if (m_isCountInAttackerLossesStatistics)
			{
				foreach(KeyValuePair<short[], double> attackerLosses in statistics.m_attackerLossesStatistics)
				{
					if(m_attackerLossesStatistics.ContainsKey(attackerLosses.Key))
					{
						m_attackerLossesStatistics[attackerLosses.Key] += attackerLosses.Value;
					}
					else
					{
						m_attackerLossesStatistics[attackerLosses.Key] = attackerLosses.Value;
					}
				}
			}
			else
			{
				throw new NotImplementedException("AddStatistics method for m_isCountInAttackerLossesStatistics==false is not implemented.");
			}

			if (m_isCountInDefenderLossesStatistics)
			{
				foreach(KeyValuePair<short[], double> defenderLosses in statistics.m_defenderLossesStatistics)
				{
					if(m_defenderLossesStatistics.ContainsKey(defenderLosses.Key))
					{
						m_defenderLossesStatistics[defenderLosses.Key] += defenderLosses.Value;
					}
					else
					{
						m_defenderLossesStatistics[defenderLosses.Key] = defenderLosses.Value;
					}
				}
			} else
			{
				throw new NotImplementedException("AddStatistics method for m_isCountInDefenderLossesStatistics==false is not implemented.");
			}

			foreach (KeyValuePair<int, int> roundStatistic in statistics.RoundStatistics)
			{
				if (RoundStatistics.ContainsKey(roundStatistic.Key))
				{
					RoundStatistics[roundStatistic.Key] += roundStatistic.Value;
				}
				else
				{
					RoundStatistics[roundStatistic.Key] = roundStatistic.Value;
				}
			}
		}

		/// <summary>
		/// Combine statistics from two battle.
		/// </summary>
		/// <param name="statistics">Other battle statistics.</param>
		/// <param name="battle">Multiwave battle.</param>
		internal void CombineStatistics(Statistics statistics, MultiWaveBattle battle)
		{
			ConvertLossesToChanse();
			statistics.ConvertLossesToChanse();
			if (m_attackerLossesStatistics.Count == 0)
			{
				foreach(KeyValuePair<short[], double> lossesStatistic in statistics.m_attackerLossesStatistics)
				{
					m_attackerLossesStatistics[ConvertLosses(lossesStatistic.Key, statistics.Battle.Units, battle.Units)] = lossesStatistic.Value;
				}
				m_isCountInAttackerLossesStatistics = statistics.m_isCountInAttackerLossesStatistics;
			}
			else
			{
				CombineLossesStatistics(
					m_attackerLossesStatistics, m_count, battle.Units, 
					statistics.m_attackerLossesStatistics, statistics.m_count, statistics.Battle.Units);
			}

			if (m_defenderLossesStatistics.Count == 0)
			{
				foreach (KeyValuePair<short[], double> lossesStatistic in statistics.m_defenderLossesStatistics)
				{
					m_defenderLossesStatistics[ConvertLosses(lossesStatistic.Key, statistics.Battle.EnemyUnits, battle.EnemyUnits)] = lossesStatistic.Value;
				}
				m_isCountInDefenderLossesStatistics = statistics.m_isCountInDefenderLossesStatistics;
			}
			else
			{
				CombineLossesStatistics(
					m_defenderLossesStatistics, m_count, battle.EnemyUnits,
					statistics.m_defenderLossesStatistics, statistics.m_count, statistics.Battle.EnemyUnits);
			}

			m_count = statistics.m_count;
			
			statistics.CalculateBattleTime();
			m_minBattleTime += statistics.m_minBattleTime;
			m_maxBattleTime += statistics.m_maxBattleTime;
			m_avgBattleTime += statistics.m_avgBattleTime;

			if (statistics.BattleTimeStatistics.Count > 0)
			{
				if (BattleTimeStatistics.Count == 0)
				{
					foreach(KeyValuePair<double, double> newTimeStatistic in statistics.BattleTimeStatistics)
					{
						BattleTimeStatistics[newTimeStatistic.Key] = newTimeStatistic.Value;
					}
				}
				else
				{
					SortedDictionary<double, double> timeStatistics = new SortedDictionary<double, double>();
					foreach(KeyValuePair<double, double> timeStatistic in BattleTimeStatistics)
					{
						foreach(KeyValuePair<double, double> newTimeStatistic in statistics.BattleTimeStatistics)
						{
							double time = timeStatistic.Key + newTimeStatistic.Key;
							double chance = timeStatistic.Value * newTimeStatistic.Value;
							if(!timeStatistics.ContainsKey(time))
							{
								timeStatistics[time] = chance;
							}
							else
							{
								timeStatistics[time] += chance;
							}
						}
					}
					m_battleTimeStatistics = timeStatistics;
				}
			}
		}

		private static void CombineLossesStatistics(
			Dictionary<short[], double> lossesStatistics, int count, IList<Unit> units,
			Dictionary<short[], double> newLossesStatistics, int newCount, IList<Unit> newUnits)
		{
			Dictionary<short[], double> result = new Dictionary<short[], double>(new ShortArrayComparer());
			foreach (KeyValuePair<short[], double> lossesStatistic in lossesStatistics)
			{
				foreach (KeyValuePair<short[], double> newLossesStatistic in newLossesStatistics)
				{
					short[] losses = CombineLosses((short[]) lossesStatistic.Key.Clone(), ConvertLosses(newLossesStatistic.Key, newUnits, units));
					double chance = lossesStatistic.Value * newLossesStatistic.Value;
					if (!result.ContainsKey(losses))
					{
						result[losses] = chance;
					}
					else
					{
						result[losses] += chance;
					}
				}
			}

			lossesStatistics.Clear();
			foreach(KeyValuePair<short[], double> pair in result)
			{
				lossesStatistics[pair.Key] = pair.Value;
			}
		}

		internal void Calculate()
		{
			if ((m_battle.StatisticsType & StatisticsType.Losses) > 0)
			{
				CalculateLosses(
					m_attackerLossesStatistics, 
					out m_minAttackerLosses, 
					out m_avgAttackerLosses, 
					out m_maxAttackerLosses, 
					m_count, 
					ref m_isCountInAttackerLossesStatistics);
				CalculateLosses(
					m_defenderLossesStatistics, 
					out m_minDefenderLosses, 
					out m_avgDefenderLosses, 
					out m_maxDefenderLosses, 
					m_count,
					ref m_isCountInDefenderLossesStatistics);
			}

			if ((m_battle.StatisticsType & StatisticsType.Rounds) > 0)
			{
				CalculateRounds();
			}

			if ((m_battle.StatisticsType & StatisticsType.LossesPrice) > 0)
			{
				CalculatePrices();
			}

			if ((m_battle.StatisticsType & StatisticsType.LossesRecoveryTime) > 0)
			{
				CalculateLossesTime();
			}

			if ((m_battle.StatisticsType & StatisticsType.BattleTime) > 0)
			{
				CalculateBattleTime();
			}
		}

		private void ConvertLossesToChanse()
		{
			ConvertLossesToChanse(m_attackerLossesStatistics, m_isCountInAttackerLossesStatistics, m_count);
			m_isCountInAttackerLossesStatistics = false;
			ConvertLossesToChanse(m_defenderLossesStatistics, m_isCountInDefenderLossesStatistics, m_count);
			m_isCountInDefenderLossesStatistics = false;
		}

		private static void ConvertLossesToChanse(Dictionary<short[], double> lossesStatistics, bool isLossesStatisticsInCount, int count)
		{
			if (isLossesStatisticsInCount)
			{
				Dictionary<short[], double> temp = new Dictionary<short[], double>(lossesStatistics, new ShortArrayComparer());
				foreach (KeyValuePair<short[], double> pair in temp)
				{
					lossesStatistics[pair.Key] = pair.Value / count;
				}
			}
		}

		private static void CalculateLosses(
			Dictionary<short[], double> lossesStatistics, 
			out short[] minAttackerLosses, 
			out double[] avgAttackerLosses, 
			out short[] maxAttackerLosses,
			int count,
			ref bool isLossesStatisticsInCount)
		{
			minAttackerLosses = null;
			avgAttackerLosses = null;
			maxAttackerLosses = null;

			// convert to chance
			if (isLossesStatisticsInCount)
			{
				ConvertLossesToChanse(lossesStatistics, isLossesStatisticsInCount, count);
				isLossesStatisticsInCount = false;
			}

			foreach (KeyValuePair<short[], double> attackerLossesStatistic in lossesStatistics)
			{
				if (minAttackerLosses == null)
				{
					minAttackerLosses = new short[attackerLossesStatistic.Key.Length];
					Array.Copy(attackerLossesStatistic.Key, minAttackerLosses, attackerLossesStatistic.Key.Length);
				}

				if (avgAttackerLosses == null)
				{
					avgAttackerLosses = new double[attackerLossesStatistic.Key.Length];
				}

				if (maxAttackerLosses == null)
				{
					maxAttackerLosses = new short[attackerLossesStatistic.Key.Length];
					Array.Copy(attackerLossesStatistic.Key, maxAttackerLosses, attackerLossesStatistic.Key.Length);
				}

				if (CompareLosses(attackerLossesStatistic.Key, minAttackerLosses) < 0)
				{
					Array.Copy(attackerLossesStatistic.Key, minAttackerLosses, attackerLossesStatistic.Key.Length);
				}

				if (CompareLosses(attackerLossesStatistic.Key, maxAttackerLosses) > 0)
				{
					Array.Copy(attackerLossesStatistic.Key, maxAttackerLosses, attackerLossesStatistic.Key.Length);
				}

				for(int i = 0; i < attackerLossesStatistic.Key.Length; i++)
				{
					avgAttackerLosses[i] += (double)attackerLossesStatistic.Value * attackerLossesStatistic.Key[i];
				}
			}
		}

		private void CalculateRounds()
		{
			m_minRounds = int.MaxValue;
			m_avgRounds = 0;
			m_maxRounds = 0;
			foreach (KeyValuePair<int, int> roundStatistic in m_roundStatistics)
			{
				int rounds = Math.Abs(roundStatistic.Key);
				if (m_minRounds > rounds)
				{
					m_minRounds = rounds;
				}

				if (m_maxRounds < rounds)
				{
					m_maxRounds = rounds;
				}

				m_avgRounds += (double)roundStatistic.Value * rounds / m_count;
			}
		}

		private void CalculatePrices()
		{
			PriceFunction function = new PriceFunction(null);
			if (m_losesPrice == null)
			{
				LossesPrice minLosesPrice = new LossesPrice(function.CalculateLosses(m_battle.Units, m_minAttackerLosses));
				LossesPrice maxLosesPrice = new LossesPrice(function.CalculateLosses(m_battle.Units, m_maxAttackerLosses));
				LossesPrice avgLosesPrice = new LossesPrice(function.CalculateLosses(m_battle.Units, m_avgAttackerLosses));
				m_losesPrice = new StatisticsLossesPrice(minLosesPrice, avgLosesPrice, maxLosesPrice);
			}
		}

		private void CalculateLossesTime()
		{
			LossesRecoveryTimeFunction function = new LossesRecoveryTimeFunction();
			m_minLossesRecoveryTime = function.CalculateTime(m_battle.Units, m_minAttackerLosses);
			m_maxLossesRecoveryTime = function.CalculateTime(m_battle.Units, m_maxAttackerLosses);
			m_avgLossesRecoveryTime = function.CalculateTime(m_battle.Units, m_avgAttackerLosses);
		}

		private void CalculateBattleTime()
		{
			m_minBattleTime = double.MaxValue;
			m_avgBattleTime = 0;
			m_maxBattleTime = 0;

			if (RoundStatistics.Count > 0)
			{
				BattleTimeStatistics.Clear();
				BattleTimeFunction func = new BattleTimeFunction();
				foreach(KeyValuePair<int, int> roundStatistic in RoundStatistics)
				{
					double time = func.CalculateBattleTime(m_battle, roundStatistic.Key);

					if(m_minBattleTime > time)
					{
						m_minBattleTime = time;
						m_minBattleTimeChance = (double)roundStatistic.Value / m_count * 100;
					} else if(m_minBattleTime == time)
					{
						m_minBattleTimeChance += (double)roundStatistic.Value / m_count * 100;
					}

					if(m_maxBattleTime < time)
					{
						m_maxBattleTime = time;
						m_maxBattleTimeChance = (double)roundStatistic.Value / m_count * 100;
					}
					else if (m_minBattleTime == time)
					{
						m_maxBattleTimeChance += (double)roundStatistic.Value / m_count * 100;
					}

					m_avgBattleTime += roundStatistic.Value * time / m_count;

					if(!BattleTimeStatistics.ContainsKey(time))
					{
						BattleTimeStatistics[time] = (double) roundStatistic.Value / m_count;
					}
					else
					{
						BattleTimeStatistics[time] += (double) roundStatistic.Value / m_count;
					}
				}
			}

			if (m_maxBattleTime == 0 && BattleTimeStatistics.Count > 0)
			{
				foreach(KeyValuePair<double, double> battleTimeStatistic in BattleTimeStatistics)
				{
					double time = battleTimeStatistic.Key;
					if (m_minBattleTime > time)
					{
						m_minBattleTime = time;
						m_minBattleTimeChance = battleTimeStatistic.Value * 100;
					}
					else if (m_minBattleTime == time)
					{
						m_minBattleTimeChance += battleTimeStatistic.Value * 100;
					}

					if (m_maxBattleTime < time)
					{
						m_maxBattleTime = time;
						m_maxBattleTimeChance = battleTimeStatistic.Value * 100;
					}
					else if (m_maxBattleTime == time)
					{
						m_maxBattleTimeChance += battleTimeStatistic.Value * 100;
					}

					m_avgBattleTime += battleTimeStatistic.Value * time;
				}
			}
		}

		internal static short[] CombineLosses(short[] losses1, short[] losses2)
		{
			if (losses1==null)
			{
				return losses2;
			}

			for(int i = 0; i < losses1.Length; i++)
			{
				losses1[i] += losses2[i];
			}

			return losses1;
		}

		internal static double[] CombineLosses(double[] losses1, double[] losses2)
		{
			if (losses1 == null)
			{
				return losses2;
			}

			for (int i = 0; i < losses1.Length; i++)
			{
				losses1[i] += losses2[i];
			}

			return losses1;
		}

		private static short[] ConvertLosses(short[] losses, IList<Unit> units, IList<Unit> newUnits)
		{
			short[] result = new short[newUnits.Count];

			for(int i=0; i < losses.Length; i++)
			{
				result[newUnits.IndexOf(units[i])] = losses[i];
			}

			return result;
		}

		private static double[] ConvertLosses(double[] losses, IList<Unit> units, IList<Unit> newUnits)
		{
			double[] result = new double[newUnits.Count];

			for (int i = 0; i < losses.Length; i++)
			{
				result[newUnits.IndexOf(units[i])] = losses[i];
			}

			return result;
		}

		private static int CompareLosses(short[] x, short[] y)
		{
			int result = 0;
			for(int i = 0; i < x.Length; i++)
			{
				result = x[i].CompareTo(y[i]);
				if (result != 0)
				{
					return result;
				}
			}

			return result;
		}
		#endregion
	}
}
