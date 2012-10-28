using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public class Step : SimulationGroup
	{
		#region Fields
		private readonly List<SquadAttack> m_playerSqadsAttacks = new List<SquadAttack>();
		private readonly List<SquadAttack> m_enemySqadsAttacks = new List<SquadAttack>();
		private AttackPriority m_stepType;
		#endregion

		#region Constructor
		internal Step(Battle battle, List<UnitAttackArgs> attacks)
		{
			AddAttacks(battle, attacks);

			List<UnitAttackArgs> temp = new List<UnitAttackArgs>();
			BattleSideType side = BattleSideType.Player;
			int attacker = int.MinValue;
			foreach(UnitAttackArgs arg in attacks)
			{
				if (side!=arg.AttackerSide || arg.AttackerUnit!=attacker)
				{
					if (temp.Count > 0)
					{
						SquadAttack attack = new SquadAttack(battle, temp);
						if (side==BattleSideType.Player)
						{
							PlayerSqadsAttacks.Add(attack);
						}
						else
						{
							EnemySqadsAttacks.Add(attack);
						}
						temp.Clear();
					}

					side = arg.AttackerSide;
					attacker = arg.AttackerUnit;					
				}

				temp.Add(arg);
			}

			if (temp.Count > 0)
			{
				SquadAttack attack = new SquadAttack(battle, temp);
				if (side == BattleSideType.Player)
				{
					PlayerSqadsAttacks.Add(attack);
				}
				else
				{
					EnemySqadsAttacks.Add(attack);
				}
			}
		}
		#endregion

		#region Properties
		public AttackPriority StepType
		{
			get { return m_stepType; }
			set { m_stepType = value; }
		}

		public List<SquadAttack> PlayerSqadsAttacks
		{
			get { return m_playerSqadsAttacks; }
		}

		public List<SquadAttack> EnemySqadsAttacks
		{
			get { return m_enemySqadsAttacks; }
		}
		#endregion
	}
}
