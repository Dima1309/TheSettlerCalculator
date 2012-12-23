using System;

namespace TheSettlersCalculator.Statistics
{
	public class WaveKey : IComparable<WaveKey>
	{
		#region Fields
		private int m_attackerWave;
		private int m_defenderWave;
		#endregion

		#region Constructor
		internal WaveKey(int attackerWave, int defenderWave)
		{
			m_attackerWave = attackerWave;
			m_defenderWave = defenderWave;
		}
		#endregion

		#region Properties
		public int AttackerWave
		{
			get { return m_attackerWave; }
			set { m_attackerWave = value; }
		}

		public int DefenderWave
		{
			get { return m_defenderWave; }
			set { m_defenderWave = value; }
		}
		#endregion

		#region Methods
		public int CompareTo(WaveKey other)
		{
			int result = m_attackerWave.CompareTo(other.AttackerWave);
			if (result != 0)
			{
				return result;
			}

			return m_defenderWave.CompareTo(other.DefenderWave);
		}
		#endregion
	}
}
