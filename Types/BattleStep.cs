namespace TheSettlersCalculator.Types
{
	internal struct BattleStep
	{
		#region Fields
		private readonly BattleSideStep[] m_sides;
		#endregion

		#region Constructor
		internal BattleStep(Battle battle)
		{
			m_sides = new BattleSideStep[2];
			Sides[(int)BattleSideType.Player] = new BattleSideStep(battle, BattleSideType.Player);
			Sides[(int)BattleSideType.Enemy] = new BattleSideStep(battle, BattleSideType.Enemy);
		}

		internal BattleStep(BattleStep battleStep)
		{
			m_sides = new BattleSideStep[2];
			Sides[(int)BattleSideType.Player] = new BattleSideStep(battleStep.Sides[(int)BattleSideType.Player]);
			Sides[(int)BattleSideType.Enemy] = new BattleSideStep(battleStep.Sides[(int)BattleSideType.Enemy]);

		}
		#endregion

		#region Properties
		public short[] Counts
		{
			get { return m_sides[(int)BattleSideType.Player].Counts; }
		}

		public int[] Healts
		{
			get { return m_sides[(int)BattleSideType.Player].Healts; }
		}

		public short[] EnemyCounts
		{
			get { return m_sides[(int)BattleSideType.Enemy].Counts; }
		}

		public int[] EnemyHealts
		{
			get { return m_sides[(int)BattleSideType.Enemy].Healts; }
		}

		public bool General
		{
			get { return m_sides[(int)BattleSideType.Player].General; }
		}

		public bool EnemyGeneral
		{
			get { return m_sides[(int)BattleSideType.Enemy].General; }
		}

		public BattleSideStep[] Sides
		{
			get { return m_sides; }
		}
		#endregion
	}
}
