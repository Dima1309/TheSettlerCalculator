using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal class Calculator : ICalculator
	{
		#region Fields
		private readonly int m_iterationCount;
		private BattleCompleteHandler m_onBattleComplete;
		#endregion

		#region Constructor
		internal Calculator(int iterationCount)
		{
			m_iterationCount = iterationCount;
		}
		#endregion

		public event BattleCompleteHandler OnBattleComplete
		{
			add { m_onBattleComplete += value; }
			remove { m_onBattleComplete -= value; }
		}

		public int IterationCount
		{
			get { return m_iterationCount; }
		}

		public virtual void Calculate(Battle battle)
		{
			BattleWaves waves = SplitByWaves(battle);

			for (int j = 0; j < IterationCount; j++)
			{
				BattleComplete(battle, BattleHelper.CalculateBattle2(battle, waves));
			}		
		}

		internal static BattleWaves SplitByWaves(Battle battle)
		{
			BattleWaves result = new BattleWaves();
			int i = 0;
			foreach(Unit unit in battle.Units)
			{
				switch(unit.AttackPriority)
				{
					case AttackPriority.AvantGarde:
						result.Avantgard.Add(i);
						break;
					case AttackPriority.Normal:
						result.Normal.Add(i);
						break;
					case AttackPriority.RearGuard:
						result.RearGuard.Add(i);
						break;
					default:
						break;
				}
				i++;
			}

			i = 0;
			foreach (Unit unit in battle.EnemyUnits)
			{
				switch (unit.AttackPriority)
				{
					case AttackPriority.AvantGarde:
						result.EnemyAvantgard.Add(i);
						break;
					case AttackPriority.Normal:
						result.EnemyNormal.Add(i);
						break;
					case AttackPriority.RearGuard:
						result.EnemyRearGuard.Add(i);
						break;
					default:
						break;
				}
				i++;
			}

			return result;
		}

		protected internal void BattleComplete(Battle result, IList<BattleStep> battleSteps)
		{
			if (m_onBattleComplete != null)
			{
				m_onBattleComplete(this, new BattleCompleteArgs(result, battleSteps));
			}
		}
	}
}
