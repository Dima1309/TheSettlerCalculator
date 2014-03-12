using System;
using System.Collections.Generic;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Statistics
{
	public class MultiWaveStatistics
	{
		#region Fields
		private readonly MultiWaveBattle m_battle;
		private Statistics m_totalStatistics;
		private readonly SortedDictionary<WaveKey, Statistics> m_statistics = new SortedDictionary<WaveKey, Statistics>();
		private readonly SortedDictionary<WaveKey, Statistics> m_temp = new SortedDictionary<WaveKey, Statistics>();
		private readonly Battle m_dummyTotalBattle;
		#endregion

		#region Constructor
		internal MultiWaveStatistics(MultiWaveBattle battle)
		{
			m_battle = battle;
			m_dummyTotalBattle = new Battle(battle.Units.ToArray(), null, battle.EnemyUnits.ToArray(), null);
			m_dummyTotalBattle.StatisticsType = battle.StatisticsType;
		}
		#endregion

		#region Properties
		internal MultiWaveBattle Battle
		{
			get { return m_battle; }
		}

		internal Statistics TotalStatistics
		{
			get { return m_totalStatistics; }
		}

		internal SortedDictionary<WaveKey, Statistics> Statistics
		{
			get { return m_statistics; }
		}
		#endregion

		#region Methods
		internal void MultiWaveBattleCompleteHandler(object sender, EventArgs args)
		{
			Statistics combinedStatistics = new Statistics(m_dummyTotalBattle);
			foreach(KeyValuePair<WaveKey, Statistics> pair in m_temp)
			{
				combinedStatistics.CombineStatistics(pair.Value, Battle);
				Statistics statistics;
				if (!Statistics.TryGetValue(pair.Key, out statistics))
				{
					Statistics.Add(pair.Key, pair.Value);
				}
				else
				{
					statistics.AddStatistics(pair.Value);
				}
			}

			m_temp.Clear();

			if (m_totalStatistics == null)
			{
				m_totalStatistics = combinedStatistics;
			}
			else
			{
				m_totalStatistics.AddStatistics(combinedStatistics);
			}
		}

		internal void MultiWaveBattleWaveCompleteHandler(object sender, MultiWaveBatleWaveCompleteArgs args)
		{
			m_temp.Add(args.Key, args.Statistics);
		}

		internal void Calculate()
		{
			m_totalStatistics.Calculate();
			foreach (KeyValuePair<WaveKey, Statistics> pair in m_statistics)
			{
				pair.Value.Calculate();
			}
		}
		#endregion
	}
}
