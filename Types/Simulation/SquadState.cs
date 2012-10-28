namespace TheSettlersCalculator.Types.Simulation
{
	public class SquadState
	{
		#region Fields
		private Unit m_unit;
		private int m_count;
		private int m_health;
		#endregion

		#region Constructor
		internal SquadState(Unit unit, int count, int health)
		{
			m_unit = unit;
			m_count = count;
			m_health = health;
		}
		#endregion

		#region Properties
		public int Count
		{
			get { return m_count; }
			set { m_count = value; }
		}

		public int Health
		{
			get { return m_health; }
			set { m_health = value; }
		}

		public Unit Unit
		{
			get { return m_unit; }
			set { m_unit = value; }
		}
		#endregion
	}
}
