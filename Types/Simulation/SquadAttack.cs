using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public class SquadAttack
	{
		#region Fields
		private readonly List<UnitAttack> m_unitAttack;
		private readonly List<SquadState> m_totalDamage;
		private readonly Unit m_unit;
		private readonly int m_count;
		#endregion

		#region Constructor
		internal SquadAttack(Battle battle, ICollection<UnitAttackArgs> attacks)
		{
			IDictionary<int, SquadState> losses = new SortedDictionary<int, SquadState>();
			m_unitAttack = new List<UnitAttack>(attacks.Count);
			int attackerId = int.MinValue;
			foreach(UnitAttackArgs arg in attacks)
			{
				Unit attacker;
				Unit target;
				if (arg.AttackerSide==BattleSideType.Player)
				{
					attacker = arg.AttackerUnit == PlayerUnits.GENERAL ? PlayerUnits.General : battle.Units[arg.AttackerUnit];
					target = arg.TargetUnit == PlayerUnits.GENERAL ? PlayerUnits.General : battle.EnemyUnits[arg.TargetUnit];
				}
				else
				{
					attacker = arg.AttackerUnit == PlayerUnits.GENERAL ? PlayerUnits.General : battle.EnemyUnits[arg.AttackerUnit];
					target = arg.TargetUnit == PlayerUnits.GENERAL ? PlayerUnits.General : battle.Units[arg.TargetUnit];					
				}

				m_unit = attacker;
				if (attackerId != arg.AttackerUnitId)
				{
					attackerId = arg.AttackerUnitId;
					m_count++;
				}

				UnitAttack.Add(new UnitAttack(attacker, arg.AttackerUnitId, target, arg.Damage, arg.UnitHealth));

				SquadState squadState;
				if (!losses.TryGetValue(arg.TargetUnit, out squadState))
				{
					squadState = new SquadState(target, 0, 0);
					losses.Add(arg.TargetUnit, squadState);
				}

				if (squadState != null)
				{
					if (arg.Damage >= arg.UnitHealth)
					{
						squadState.Count++;
					}

					squadState.Health += Math.Min(arg.Damage, arg.UnitHealth);
				}
			}

			m_totalDamage = new List<SquadState>(losses.Count);
			foreach(KeyValuePair<int, SquadState> pair in losses)
			{
				TotalDamage.Add(pair.Value);
			}
		}
		#endregion

		public List<UnitAttack> UnitAttack
		{
			get { return m_unitAttack; }
		}

		public List<SquadState> TotalDamage
		{
			get { return m_totalDamage; }
		}

		public Unit Unit
		{
			get { return m_unit; }
		}

		public int Count
		{
			get { return m_count; }
		}
	}
}
