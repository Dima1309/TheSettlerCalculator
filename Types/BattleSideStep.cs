using System;

namespace TheSettlersCalculator.Types
{
	internal class BattleSideStep
	{
		#region Fields
		private readonly short[] m_counts;
		private readonly int[] m_healts;
		private readonly bool m_general;
		#endregion

		#region Constructor
		internal BattleSideStep(BattleSideStep step)
		{
			m_counts = new short[step.Counts.Length];
			Array.Copy(step.Counts, m_counts, m_counts.Length);
			m_healts = new int[step.Healts.Length];
			Array.Copy(step.Healts, m_healts, m_healts.Length);
			m_general = step.General;
		}

		internal BattleSideStep(Battle battle, BattleSideType sideType)
		{
			BattleSide battleSide = battle.Sides[(int)sideType];
			m_counts = new short[battleSide.Counts.Length];
			Array.Copy(battleSide.Counts, m_counts, m_counts.Length);
			m_healts = new int[battleSide.Units.Length];
			for (int i = 0; i < battleSide.Units.Length; i++)
			{
				m_healts[i] = battleSide.Units[i].Health;
			}
			m_general = battleSide.General;
		}
		#endregion

		internal short[] Counts
		{
			get { return m_counts; }
		}

		internal int[] Healts
		{
			get { return m_healts; }
		}

		internal bool General
		{
			get { return m_general; }
		}
	}
}
