
using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public abstract class SimulationGroup
	{
		#region Fields
		private readonly List<SquadState> m_playerBeginState = new List<SquadState>();
		private readonly List<SquadState> m_enemyBeginState = new List<SquadState>();
		private readonly List<SquadState> m_playerLosses = new List<SquadState>();
		private readonly List<SquadState> m_enemyLosses = new List<SquadState>();
		private readonly List<SquadState> m_playerEndState = new List<SquadState>();
		private readonly List<SquadState> m_enemyEndState = new List<SquadState>();
		#endregion

		#region Properties
		public List<SquadState> PlayerBeginState
		{
			get { return m_playerBeginState; }
		}

		public List<SquadState> EnemyBeginState
		{
			get { return m_enemyBeginState; }
		}

		public List<SquadState> PlayerLosses
		{
			get { return m_playerLosses; }
		}

		public List<SquadState> EnemyLosses
		{
			get { return m_enemyLosses; }
		}

		public List<SquadState> PlayerEndState
		{
			get { return m_playerEndState; }
		}

		public List<SquadState> EnemyEndState
		{
			get { return m_enemyEndState; }
		}
		#endregion

		#region Methods
		internal void AddAttacks(Battle battle, List<UnitAttackArgs> attacks)
		{
			List<SquadState> playerTemp = GenerateTempCollection(battle.Units, m_playerLosses);
			List<SquadState> enemyTemp = GenerateTempCollection(battle.EnemyUnits, m_enemyLosses);

			foreach (UnitAttackArgs attack in attacks)
			{
				if (attack.TargetUnit == PlayerUnits.GENERAL)
				{
					continue;
				}

				if (attack.AttackerSide == BattleSideType.Enemy)
				{
					playerTemp[attack.TargetUnit].Health += Math.Min(attack.Damage, attack.UnitHealth);
					if (attack.Damage >= attack.UnitHealth)
					{
						playerTemp[attack.TargetUnit].Count++;
					}
				}
				else
				{					
					enemyTemp[attack.TargetUnit].Health += Math.Min(attack.Damage, attack.UnitHealth);
					if (attack.Damage >= attack.UnitHealth)
					{
						enemyTemp[attack.TargetUnit].Count++;
					}
				}
			}

			m_playerLosses.Clear();
			m_playerLosses.AddRange(TrimSquadStates(playerTemp));

			m_enemyLosses.Clear();
			m_enemyLosses.AddRange(TrimSquadStates(enemyTemp));
		}

		internal void SetBeginState(Battle battle)
		{
			for (int i = 0; i < battle.Units.Length; i++)
			{
				m_playerBeginState.Add(new SquadState(battle.Units[i], battle.Counts[i], battle.Units[i].Health));
			}

			for (int i = 0; i < battle.EnemyUnits.Length; i++)
			{
				m_enemyBeginState.Add(new SquadState(battle.EnemyUnits[i], battle.EnemyCounts[i], battle.EnemyUnits[i].Health));
			}
		}

		internal void SetBeginState(Battle battle, BattleSideStep playerStep, BattleSideStep enemyStep)
		{
			for (int i = 0; i < playerStep.Counts.Length; i++)
			{
				m_playerBeginState.Add(new SquadState(battle.Units[i], playerStep.Counts[i], playerStep.Healts[i]));
			}

			for (int i = 0; i < playerStep.Counts.Length; i++)
			{
				m_enemyBeginState.Add(new SquadState(battle.EnemyUnits[i], enemyStep.Counts[i], enemyStep.Healts[i]));
			}
		}

		internal void SetEndState(Battle battle, BattleSideStep playerStep, BattleSideStep enemyStep)
		{
			for (int i = 0; i < playerStep.Counts.Length; i++)
			{
				m_playerEndState.Add(new SquadState(battle.Units[i], playerStep.Counts[i], playerStep.Healts[i]));
			}

			for (int i = 0; i < playerStep.Counts.Length; i++)
			{
				m_enemyEndState.Add(new SquadState(battle.EnemyUnits[i], enemyStep.Counts[i], enemyStep.Healts[i]));
			}
		}

		private static List<SquadState> GenerateTempCollection(Unit[] units, IEnumerable<SquadState> current)
		{
			List<SquadState> result = new List<SquadState>(units.Length);

			foreach (Unit unit in units)
			{
				SquadState squadState = null;
				if (current != null)
				{
					foreach (SquadState existState in current)
					{
						if (ReferenceEquals(existState.Unit, unit))
						{
							squadState = existState;
							break;
						}
					}
				}

				if (squadState == null)
				{
					squadState = new SquadState(unit, 0, 0);
				}

				result.Add(squadState);
			}

			return result;
		}

		private static IEnumerable<SquadState> TrimSquadStates(IList<SquadState> current)
		{
			int i = 0;
			while (i < current.Count)
			{
				if (current[i].Count == 0 && current[i].Health == 0)
				{
					current.RemoveAt(i);
					continue;
				}

				i++;
			}

			return current;
		}
		#endregion
	}
}
