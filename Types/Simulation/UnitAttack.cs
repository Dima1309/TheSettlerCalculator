namespace TheSettlersCalculator.Types.Simulation
{
	public class UnitAttack
	{
		#region Fields
		private readonly Unit m_attacker;
		private readonly int m_attackerId;
		private readonly Unit m_defender;
		private readonly int m_damage;
		private readonly int m_health;
		#endregion

		#region Constructor
		internal UnitAttack(Unit attacker, int attackerId, Unit defender, int damage, int health)
		{
			m_attacker = attacker;
			m_damage = damage;
			m_defender = defender;
			m_attackerId = attackerId;
			m_health = health-damage;
		}
		#endregion

		#region Properties
		public int Damage
		{
			get { return m_damage; }
		}

		public Unit Defender
		{
			get { return m_defender; }
		}

		public int AttackerId
		{
			get { return m_attackerId; }
		}

		public Unit Attacker
		{
			get { return m_attacker; }
		}

		public int Health
		{
			get { return m_health; }
		}
		#endregion
	}
}
