using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Expressions
{
	internal class ResourceCountExpression
	{
		#region Fields
		private int m_existingResource = 0;
		private List<KeyValuePair<int, BuffCountExpression>> m_buffs = new List<KeyValuePair<int,BuffCountExpression>>();
		#endregion

		#region Properties
		public int ExistingResource
		{
			get { return m_existingResource; }
			set { m_existingResource = value; }
		}
		#endregion

		#region Methods
		public void AddBuff(int resourceCountInBuff, BuffCountExpression buffExpression)
		{
			m_buffs.Add(new KeyValuePair<int, BuffCountExpression>(resourceCountInBuff, buffExpression));
		}

		public double Calculate(int[] x)
		{
			double result = 0;

			foreach(KeyValuePair<int, BuffCountExpression> pair in m_buffs)
			{
				result += pair.Value.Calculate(x) * pair.Key;
			}

			result -= m_existingResource;
			if (result < 0)
			{
				result = 0;
			}

			return result;
		}
		#endregion
	}
}
