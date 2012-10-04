using System;
using System.Collections.Generic;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Types
{
	internal class Battle : ICloneable
	{
		#region Fields
		private readonly BattleSide[] m_sides;
		#endregion

		#region Constructor
		internal Battle(IList<UnitSquad> units, bool general, IList<UnitSquad> enemyUnits, bool enemyGeneral)
		{
			KeyValuePair<Unit[], short[]> result = InitializeUnits(units);
			m_sides = new BattleSide[2];
			Sides[(int)BattleSideType.Player] = new BattleSide(result.Key, result.Value, general);

			result = InitializeUnits(enemyUnits);
			Sides[(int)BattleSideType.Enemy] = new BattleSide(result.Key, result.Value, enemyGeneral);
		}

		internal Battle(Unit[] units, short[] counts, bool general, Unit[] enemyUnits, short[] enemyCounts, bool enemyGeneral)
		{
			KeyValuePair<Unit[], short[]> result = InitializeUnits(units, counts);
			m_sides = new BattleSide[2];
			Sides[(int)BattleSideType.Player] = new BattleSide(result.Key, result.Value, general);

			result = InitializeUnits(enemyUnits, enemyCounts);
			Sides[(int)BattleSideType.Enemy] = new BattleSide(result.Key, result.Value, enemyGeneral);
		}

		private static KeyValuePair<Unit[], short[]> InitializeUnits(IList<UnitSquad> unitSquads)
		{
			Unit[] units = new Unit[unitSquads.Count];
			short[] counts = new short[unitSquads.Count];
			for(int i = 0; i < unitSquads.Count; i++)
			{
				units[i] = unitSquads[i].Unit;
				counts[i] = (short) unitSquads[i].Count;
			}

			return InitializeUnits(units, counts);
		}

		private static KeyValuePair<Unit[], short[]> InitializeUnits(IList<Unit> units, IList<short> counts)
		{
			int nonZeroCount = 0;
			foreach(short count in counts)
			{
				if (count > 0)
				{
					nonZeroCount++;
				}
			}

			Unit[] unitResult = new Unit[nonZeroCount];
			short[] countResult = new short[nonZeroCount];

			int i = 0;
			int j = 0;
			while (i<counts.Count)
			{
				if (counts[i] > 0)
				{
					unitResult[j] = units[i];
					countResult[j] = counts[i];
					j++;
				}

				i++;
			}

			return new KeyValuePair<Unit[], short[]>(unitResult, countResult);
		}
		#endregion

		#region Properties
		public Unit[] Units
		{
			get { return m_sides[(int)BattleSideType.Player].Units; }
		}

		public short[] Counts
		{
			get { return m_sides[(int)BattleSideType.Player].Counts; }
		}

		public Unit[] EnemyUnits
		{
			get { return m_sides[(int)BattleSideType.Enemy].Units; }
		}

		public short[] EnemyCounts
		{
			get { return m_sides[(int)BattleSideType.Enemy].Counts; }
		}

		public bool EnemyGeneral
		{
			get { return m_sides[(int)BattleSideType.Enemy].General;  }
		}

		public bool General
		{
			get { return m_sides[(int)BattleSideType.Player].General; }
		}

		internal BattleSide[] Sides
		{
			get { return m_sides; }
		}
		#endregion

		public object Clone()
		{
			return new Battle(Units, Counts, General, EnemyUnits, EnemyCounts, EnemyGeneral);
		}
	}
}
