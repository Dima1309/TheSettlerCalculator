using System;

namespace TheSettlersCalculator.Types
{
	internal class RoundStateArgs : EventArgs
	{
		private readonly BattleSideStep m_attackerStep;
		private readonly BattleSideStep m_enemyStep;

		public RoundStateArgs(BattleStep battleStep)
		{
			m_attackerStep = battleStep.Sides[(int) BattleSideType.Player];
			m_enemyStep = battleStep.Sides[(int)BattleSideType.Enemy];
		}


		public RoundStateArgs(BattleSideStep attackerStep, BattleSideStep enemyStep)
		{
			m_enemyStep = enemyStep;
			m_attackerStep = attackerStep;
		}

		public BattleSideStep EnemyStep
		{
			get { return m_enemyStep; }
		}

		public BattleSideStep AttackerStep
		{
			get { return m_attackerStep; }
		}
	}

	internal delegate void RoundStateHandler(object sender, RoundStateArgs args);
}
