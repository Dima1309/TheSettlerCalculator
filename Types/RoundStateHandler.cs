using System;

namespace TheSettlersCalculator.Types
{
	internal class RoundStateArgs : EventArgs
	{
		#region Fields
		private readonly BattleSideStep m_attackerStep;
		private readonly BattleSideStep m_enemyStep;
		private readonly int m_roundIndex;
		#endregion

		#region Constructor
		public RoundStateArgs(BattleStep battleStep, int roundIndex)
		{
			m_attackerStep = battleStep.Sides[(int) BattleSideType.Player];
			m_enemyStep = battleStep.Sides[(int)BattleSideType.Enemy];
			m_roundIndex = roundIndex;
		}

		public RoundStateArgs(BattleSideStep attackerStep, BattleSideStep enemyStep, int roundIndex)
		{
			m_enemyStep = enemyStep;
			m_attackerStep = attackerStep;
			m_roundIndex = roundIndex;
		}
		#endregion

		#region Properties
		public BattleSideStep EnemyStep
		{
			get { return m_enemyStep; }
		}

		public BattleSideStep AttackerStep
		{
			get { return m_attackerStep; }
		}

		public int RoundIndex
		{
			get { return m_roundIndex; }
		}
		#endregion
	}

	internal delegate void RoundStateHandler(object sender, RoundStateArgs args);
}
