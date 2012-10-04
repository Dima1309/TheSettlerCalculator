using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal class BattleWaves
	{
		#region Fields
		private readonly List<int> m_avantgard = new List<int>();
		private readonly List<int> m_normal = new List<int>();
		private readonly List<int> m_rearGuard = new List<int>();
		private readonly List<int> m_enemyAvantgard = new List<int>();
		private readonly List<int> m_enemyNormal = new List<int>();
		private readonly List<int> m_enemyRearGuard = new List<int>();
		#endregion

		#region Properties
		#endregion

		public List<int> Avantgard
		{
			get { return m_avantgard; }
		}

		public List<int> Normal
		{
			get { return m_normal; }
		}

		public List<int> RearGuard
		{
			get { return m_rearGuard; }
		}

		public List<int> EnemyAvantgard
		{
			get { return m_enemyAvantgard; }
		}

		public List<int> EnemyNormal
		{
			get { return m_enemyNormal; }
		}

		public List<int> EnemyRearGuard
		{
			get { return m_enemyRearGuard; }
		}
	}
}
