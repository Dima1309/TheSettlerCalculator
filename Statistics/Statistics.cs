﻿using System;
using System.Collections.Generic;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Statistics
{
	internal class Statistics
	{
		#region Fields
		private readonly Battle m_battle;
		private BattleStep m_minAttackerResult;
		private BattleStep m_maxAttackerResult;
		private BattleStep m_minDefenderResult;
		private BattleStep m_maxDefenderResult;
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

		internal BattleStep MinAttackerResult
		{
			get { return m_minAttackerResult; }
		}

		internal BattleStep MaxAttackerResult
		{
			get { return m_maxAttackerResult; }
		}

		internal BattleStep MinDefenderResult
		{
			get { return m_minDefenderResult; }
		}

		internal BattleStep MaxDefenderResult
		{
			get { return m_maxDefenderResult; }
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
		#endregion

		#region Methods
		internal void BattleComplete(object sender, BattleCompleteArgs args)
		{
			int rem;
			int rounds = Math.DivRem(args.Steps.Count, 3, out rem);
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

			foreach (short attackerLoss in lastStep.Counts)
			{
				if (attackerLoss > 0)
				{
					m_winCount++;
					break;
				}
			}

			if (m_minAttackerLosses == null)
			{
				m_minAttackerResult = lastStep;
				m_maxAttackerResult = lastStep;
				m_minDefenderResult = lastStep;
				m_maxDefenderResult = lastStep;

				m_minAttackerLosses = new short[args.Battle.Units.Length];
				m_avgAttackerLosses = new double[args.Battle.Units.Length];
				m_maxAttackerLosses = new short[args.Battle.Units.Length];

				m_minDefenderLosses = new short[args.Battle.EnemyUnits.Length];
				m_avgDefenderLosses = new double[args.Battle.EnemyUnits.Length];
				m_maxDefenderLosses = new short[args.Battle.EnemyUnits.Length];
				m_count = 0;

				Array.Copy(attackerLosses, m_minAttackerLosses, attackerLosses.Length);
				Array.Copy(attackerLosses, m_maxAttackerLosses, attackerLosses.Length);

				Array.Copy(defenderLosses, m_minDefenderLosses, defenderLosses.Length);
				Array.Copy(defenderLosses, m_maxDefenderLosses, defenderLosses.Length);

				for(int i=0; i< attackerLosses.Length; i++)
				{
					m_avgAttackerLosses[i] = attackerLosses[i];
				}

				for (int i = 0; i < defenderLosses.Length; i++)
				{
					m_avgDefenderLosses[i] = defenderLosses[i];
				}

				m_minRounds = m_maxRounds = rounds;
				m_avgRounds = rounds;
			}
			else
			{
				if (rounds < m_minRounds)
				{
					m_minRounds = rounds;
				}

				if (rounds > m_maxRounds)
				{
					m_maxRounds = rounds;
				}

				m_avgRounds = (double)Count / (Count + 1) * m_avgRounds + (double)rounds / (Count + 1);

				if (CompareLosses(attackerLosses, m_minAttackerLosses) < 0)
				{
					Array.Copy(attackerLosses, m_minAttackerLosses, attackerLosses.Length);
					m_minAttackerResult = lastStep;
				}

				if (CompareLosses(attackerLosses, m_maxAttackerLosses) > 0)
				{
					Array.Copy(attackerLosses, m_maxAttackerLosses, attackerLosses.Length);
					m_maxAttackerResult = lastStep;
				}

				if (CompareLosses(defenderLosses, m_minDefenderLosses) < 0)
				{
					Array.Copy(defenderLosses, m_minDefenderLosses, defenderLosses.Length);
					m_maxDefenderResult = lastStep;
				}

				if (CompareLosses(defenderLosses, m_maxDefenderLosses) > 0)
				{
					Array.Copy(defenderLosses, m_maxDefenderLosses, defenderLosses.Length);
					m_maxDefenderResult = lastStep;
				}

				for(int i = 0; i < attackerLosses.Length; i++)
				{
					m_avgAttackerLosses[i] = (double) Count / (Count + 1) * m_avgAttackerLosses[i] +
											 (double) attackerLosses[i] / (Count + 1);
				}

				for (int i = 0; i < defenderLosses.Length; i++)
				{
					m_avgDefenderLosses[i] = (double)Count / (Count + 1) * m_avgDefenderLosses[i] +
											 (double)defenderLosses[i] / (Count + 1);
				}
			}

			m_count = Count + 1;
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
		 
			if (m_minAttackerLosses==null || CompareLosses(m_minAttackerLosses, statistics.m_minAttackerLosses) > 0)
			{
				m_minAttackerLosses = statistics.m_minAttackerLosses;
				m_minAttackerResult = statistics.m_minAttackerResult;
			}

			if (m_maxAttackerLosses==null || CompareLosses(m_maxAttackerLosses, statistics.m_maxAttackerLosses) < 0)
			{
				m_maxAttackerLosses = statistics.m_maxAttackerLosses;
				m_maxAttackerResult = statistics.m_maxAttackerResult;
			}

			if (m_minDefenderLosses == null || CompareLosses(m_minDefenderLosses, statistics.m_minDefenderLosses) > 0)
			{
				m_minDefenderLosses = statistics.m_minDefenderLosses;
				m_minDefenderResult = statistics.m_minDefenderResult;
			}

			if (m_maxDefenderLosses == null || CompareLosses(m_maxDefenderLosses, statistics.m_maxDefenderLosses) < 0)
			{
				m_maxDefenderLosses = statistics.m_maxDefenderLosses;
				m_maxDefenderResult = statistics.m_maxDefenderResult;
			}

			if (m_minRounds == 0 || m_minRounds > statistics.m_minRounds)
			{
				m_minRounds = statistics.m_minRounds;
			}

			if (m_maxRounds == 0 || m_maxRounds < statistics.m_maxRounds)
			{
				m_maxRounds = statistics.m_maxRounds;
			}

			if (m_count == 0)
			{
				m_avgRounds = statistics.m_avgRounds;
				m_avgAttackerLosses = statistics.m_avgAttackerLosses;
				m_avgDefenderLosses = statistics.m_avgDefenderLosses;
			}
			else
			{
				m_avgRounds = m_avgRounds / statistics.m_count + statistics.m_avgRounds / m_count;
				for(int i = 0; i < m_avgAttackerLosses.Length; i++)
				{
					m_avgAttackerLosses[i] = m_avgAttackerLosses[i] / statistics.m_count + statistics.m_avgAttackerLosses[i] / m_count;
				}

				for (int i = 0; i < m_avgDefenderLosses.Length; i++)
				{
					m_avgDefenderLosses[i] = m_avgDefenderLosses[i] / statistics.m_count + statistics.m_avgDefenderLosses[i] / m_count;
				}
			}

			m_winCount += statistics.m_winCount;
			m_count += statistics.m_count;
		}

		/// <summary>
		/// Combine statistics from two battle.
		/// </summary>
		/// <param name="statistics">Other battle statistics.</param>
		/// <param name="battle">Multiwave battle.</param>
		internal void CombineStatistics(Statistics statistics, MultiWaveBattle battle)
		{
			m_minAttackerLosses = CombineLosses(m_minAttackerLosses, ConvertLosses(statistics.m_minAttackerLosses, statistics.Battle.Units, battle.Units));
			m_avgAttackerLosses = CombineLosses(m_avgAttackerLosses, ConvertLosses(statistics.m_avgAttackerLosses, statistics.Battle.Units, battle.Units));
			m_maxAttackerLosses = CombineLosses(m_maxAttackerLosses, ConvertLosses(statistics.m_maxAttackerLosses, statistics.Battle.Units, battle.Units));
			m_minDefenderLosses = CombineLosses(m_minDefenderLosses, ConvertLosses(statistics.m_minDefenderLosses, statistics.Battle.EnemyUnits, battle.EnemyUnits));
			m_avgDefenderLosses = CombineLosses(m_avgDefenderLosses, ConvertLosses(statistics.m_avgDefenderLosses, statistics.Battle.EnemyUnits, battle.EnemyUnits));
			m_maxDefenderLosses = CombineLosses(m_maxDefenderLosses, ConvertLosses(statistics.m_maxDefenderLosses, statistics.Battle.EnemyUnits, battle.EnemyUnits));
			
			m_minAttackerResult = statistics.m_minAttackerResult;
			m_maxAttackerResult = statistics.m_maxAttackerResult;
			m_minDefenderResult = statistics.m_minDefenderResult;
			m_maxDefenderResult = statistics.m_maxDefenderResult;

			m_minRounds += statistics.m_minRounds;
			m_maxRounds += statistics.m_maxRounds;
			m_avgRounds += statistics.m_avgRounds;

			m_count = statistics.m_count;
			m_winCount = statistics.m_winCount;
		}

		private static short[] CombineLosses(short[] losses1, short[] losses2)
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

		private static double[] CombineLosses(double[] losses1, double[] losses2)
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
