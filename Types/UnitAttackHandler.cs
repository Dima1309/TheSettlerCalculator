using System;

namespace TheSettlersCalculator.Types
{
	internal class UnitAttackArgs : EventArgs
	{
		private readonly BattleSideType m_attackerSideType;
		private readonly int m_attackerUnit;
		private readonly int m_attackerUnitId;
		private readonly int m_targetUnit;
		private readonly int m_damage;
		private readonly int m_unitHealth;

		public UnitAttackArgs(BattleSideType attackerSideType, int attackerUnit, int attackerUnitId, int targetUnit, int damage, int unitHealth)
		{
			m_attackerSideType = attackerSideType;
			m_damage = damage;
			m_targetUnit = targetUnit;
			m_attackerUnit = attackerUnit;
			m_attackerUnitId = attackerUnitId;
			m_unitHealth = unitHealth;
		}

		public BattleSideType AttackerSide
		{
			get { return m_attackerSideType; }
		}

		public int AttackerUnit
		{
			get { return m_attackerUnit; }
		}

		public int TargetUnit
		{
			get { return m_targetUnit; }
		}

		public int Damage
		{
			get { return m_damage; }
		}

		public int AttackerUnitId
		{
			get { return m_attackerUnitId; }
		}

		public int UnitHealth
		{
			get { return m_unitHealth; }
		}
	}

	internal delegate void UnitAttackHandler(object sender, UnitAttackArgs args);
}
