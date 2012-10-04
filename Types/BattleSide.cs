namespace TheSettlersCalculator.Types
{
	internal class BattleSide
	{
		#region Fields
		private readonly Unit[] m_units;
		private readonly short[] m_counts;
		private bool m_general;
		private double m_towerBonus;
		#endregion

		#region Constructor
		public BattleSide(Unit[] units, short[] counts, bool general)
		{
			m_units = units;
			m_counts = counts;
			m_general = general;
		}
		#endregion

		#region Properties
		public Unit[] Units
		{
			get { return m_units; }
		}

		public short[] Counts
		{
			get { return m_counts; }
		}

		public bool General
		{
			get { return m_general; }
			set { m_general = value; }
		}

		public double TowerBonus
		{
			get { return m_towerBonus; }
			set { m_towerBonus = value; }
		}
		#endregion
	}
}
