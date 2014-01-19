using System.Collections.Generic;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	public class BattleLosses
	{
		#region Fields
		private readonly IEnumerable<Losses> m_playerLosses;
		private readonly IEnumerable<Losses> m_enemyLosses;
		private int m_playerWaveIndex;
		private int m_enemyWaveIndex;

		private readonly StatisticsLossesPrice m_losesPrice;

		private readonly double m_minLossesRecoveryTime;
		private readonly double m_maxLossesRecoveryTime;
		private readonly double m_avgLossesRecoveryTime;

		private readonly double m_minBattleTime;
		private readonly double m_minBattleTimeChance;
		private readonly double m_maxBattleTime;
		private readonly double m_maxBattleTimeChance;
		private readonly double m_avgBattleTime;

		private readonly IDictionary<double, double> m_battleTimeStatistics;
		#endregion

		#region Constructor
		internal BattleLosses(IEnumerable<Losses> playerLosses, IEnumerable<Losses> enemyLosses, Statistics.Statistics statistics)
		{
			m_playerLosses = playerLosses;
			m_enemyLosses = enemyLosses;

			if (statistics != null)
			{
				m_minLossesRecoveryTime = statistics.MinLossesRecoveryTime;
				m_maxLossesRecoveryTime = statistics.MaxLossesRecoveryTime;
				m_avgLossesRecoveryTime = statistics.AvgLossesRecoveryTime;

				m_minBattleTime = statistics.MinBattleTime;
				m_minBattleTimeChance = statistics.MinBattleTimeChance;
				m_maxBattleTime = statistics.MaxBattleTime;
				m_maxBattleTimeChance = statistics.MaxBattleTimeChance;
				m_avgBattleTime = statistics.AvgBattleTime;
				m_battleTimeStatistics = statistics.BattleTimeStatistics;

				m_losesPrice = statistics.LosesPrice;
			}
		}

		public int PlayerWaveIndex
		{
			get { return m_playerWaveIndex; }
			set { m_playerWaveIndex = value; }
		}

		public int EnemyWaveIndex
		{
			get { return m_enemyWaveIndex; }
			set { m_enemyWaveIndex = value; }
		}

		public IEnumerable<Losses> PlayerLosses
		{
			get { return m_playerLosses; }
		}

		public IEnumerable<Losses> EnemyLosses
		{
			get { return m_enemyLosses; }
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

		public IDictionary<double, double> BattleTimeStatistics
		{
			get { return m_battleTimeStatistics; }
		}
		#endregion
	}
}
