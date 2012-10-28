using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public class BattleSimulation
	{
		#region Fields
		private readonly List<Round> m_rounds = new List<Round>();

		private Round m_currentRound;
		private int m_roundIndex;
		private readonly List<UnitAttackArgs> m_unitAttacks = new List<UnitAttackArgs>(1000);
		private readonly Battle m_battle;
		private RoundStateArgs m_prevState;
		#endregion

		#region Constructor
		internal BattleSimulation(Battle battle)
		{
			m_battle = battle;
			m_currentRound = new Round();
			m_currentRound.SetBeginState(battle);
			m_prevState = null;
			m_roundIndex = 0;

			BattleHelper.CalculateBattle2(
				battle,
				Calculator.SplitByWaves(battle),
				new Random(),
				RoundStateHandler,
				UnitAttackHandler);

			m_unitAttacks = null;
			m_battle = null;
			m_prevState = null;
		}
		#endregion

		#region Properties
		public List<Round> Rounds
		{
			get { return m_rounds; }
		}
		#endregion

		#region Methods
		private void RoundStateHandler(object sender, RoundStateArgs args)
		{
			if (m_currentRound != null && m_unitAttacks.Count > 0)
			{
				Step step = new Step(m_battle, m_unitAttacks);
				if (m_prevState == null)
				{
					step.SetBeginState(m_battle, args.AttackerStep, args.EnemyStep);
				}
				else
				{
					step.SetBeginState(m_battle, m_prevState.AttackerStep, m_prevState.EnemyStep);
				}

				step.SetEndState(m_battle, args.AttackerStep, args.EnemyStep);
				step.StepType = (AttackPriority) (m_roundIndex % 3);
				m_currentRound.AddAttacks(m_battle, m_unitAttacks);
				m_currentRound.SetEndState(m_battle, args.AttackerStep, args.EnemyStep);
				m_currentRound.Steps.Add(step);
			}

			// last step in round ended
			if (m_roundIndex%3==2)
			{
				if (m_currentRound != null)
				{
					m_currentRound.Index = Rounds.Count + 1;
					Rounds.Add(m_currentRound);					
				}

				m_currentRound = new Round();
				m_currentRound.SetBeginState(m_battle, args.AttackerStep, args.EnemyStep);
			}
			m_prevState = args;
			m_unitAttacks.Clear();
			m_roundIndex++;			
		}

		private void UnitAttackHandler(object sender, UnitAttackArgs args)
		{
			m_unitAttacks.Add(args);
		}
		#endregion
	}
}
