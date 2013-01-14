using System.Collections.Generic;

namespace TheSettlersCalculator.WpfTypes
{
	public class BattleLosses
	{
		#region Fields
		private readonly IEnumerable<Losses> m_playerLosses;
		private readonly IEnumerable<Losses> m_enemyLosses;
		private int m_playerWaveIndex;
		private int m_enemyWaveIndex;
		#endregion

		#region Constructor
		public BattleLosses(IEnumerable<Losses> playerLosses, IEnumerable<Losses> enemyLosses)
		{
			m_playerLosses = playerLosses;
			m_enemyLosses = enemyLosses;
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
		#endregion
	}
}
