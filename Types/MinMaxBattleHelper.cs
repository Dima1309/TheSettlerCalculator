using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	internal class MinMaxBattleHelper : AbstractBaseBattleHelper
	{
		#region Private class
		private class DamageGenerator
		{
			#region Fields
			private double m_generatedCount;
			private double m_maxDamageCount;
			private readonly double m_minUnitChance;
			private readonly double m_maxUnitChance;
			private readonly int m_minDamage;
			private readonly int m_maxDamage;
			private readonly double m_targetChance;
			#endregion

			#region Constructor
			internal DamageGenerator(Unit unit, double targetChance)
			{
				m_maxUnitChance = (double)unit.Accuracy / 100;
				m_minUnitChance = 1 - m_maxUnitChance;
				m_minDamage = unit.MinDamage;
				m_maxDamage = unit.MaxDamage;
				m_targetChance = targetChance;
			}
			#endregion

			#region Method
			internal int Generate()
			{
				double chance = 0;
				double prevChance = 0;
				double combination = 1;
				double k;
				m_generatedCount++;
				for(k=0; k <= m_generatedCount; k++)
				{	
					if ( k > 0)
					{
						combination = combination / k * (m_generatedCount - k + 1);
					}
					else
					{
						combination = 1;
					}

					prevChance = chance;
					chance += combination * Math.Pow(m_minUnitChance, (m_generatedCount - k)) * Math.Pow(m_maxUnitChance, (k));

					if (chance > m_targetChance)
					{
						double delta = Math.Abs(m_targetChance - chance);
						double prevDelta = Math.Abs(m_targetChance - prevChance);
						if (prevDelta < delta)
						{
							k--;
						}
						break;
					}
				}

				if (k > m_generatedCount)
				{
					k = m_generatedCount;
				}

				if (k <= m_maxDamageCount)
				{
					return m_minDamage;
				}
				else
				{					
					m_maxDamageCount++;
					return m_maxDamage;
				}
			}
			#endregion
		}
		#endregion

		#region Fields
		private double m_targetAttackerChance = 0.5;
		private double m_targetDefenderChance = 0.5;
		private readonly Dictionary<string, DamageGenerator> m_attackerChances = new Dictionary<string, DamageGenerator>();
		private readonly Dictionary<string, DamageGenerator> m_defenderChances = new Dictionary<string, DamageGenerator>(); 
		#endregion

		#region Properties
		public double TargetAttackerChance
		{
			get { return m_targetAttackerChance; }
			set { m_targetAttackerChance = value; }
		}

		public double TargetDefenderChance
		{
			get { return m_targetDefenderChance; }
			set { m_targetDefenderChance = value; }
		}
		#endregion

		#region Methods
		public void Reset()
		{
			m_attackerChances.Clear();
			m_defenderChances.Clear();
		}

		protected override int[] GetUnitsDamage(BattleSideType battleSideTime, Unit unit, int unitCount, Random random)
		{
			int[] result = new int[unitCount];

			DamageGenerator damageGenerator = GetDamageGenerator(battleSideTime, unit);
			for(int i=0; i < result.Length; i++)
			{
				result[i] = damageGenerator.Generate();
			}

			return result;
		}

		private DamageGenerator GetDamageGenerator(BattleSideType battleSideTime, Unit unit)
		{
			DamageGenerator result;
			if (battleSideTime == BattleSideType.Player)
			{
				if (m_attackerChances.TryGetValue(unit.Id, out result))
				{
					return result;
				}
			}
			else
			{
				if (m_defenderChances.TryGetValue(unit.Id, out result))
				{
					return result;
				}				
			}

			if (result == null)
			{
				result = new DamageGenerator(unit,
				                             battleSideTime == BattleSideType.Player
				                             	? m_targetAttackerChance
				                             	: m_targetDefenderChance);

				if (battleSideTime == BattleSideType.Player)
				{
					m_attackerChances[unit.Id] = result;
				}
				else
				{
					m_defenderChances[unit.Id] = result;
				}
			}

			return result;
		}
		#endregion
	}
}
