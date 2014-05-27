using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Expressions
{
	internal class BuffCountExpression
	{
		#region Fields
		private int m_existingCount = 0;
		private List<int> m_skills1 = new List<int>();
		private List<KeyValuePair<int, int>> m_skills2 = new List<KeyValuePair<int, int>>();
		#endregion

		#region Properties
		public int ExistingCount
		{
			get { return m_existingCount; }
			set { m_existingCount = value; }
		}
		#endregion

		#region Methods
		public void AddPrimaryBuff(int skillIndexCount)
		{
			m_skills1.Add(skillIndexCount);
		}

		public void AddSecondaryBuff(int maxSkillValue,  int skillIndexCount)
		{
			m_skills2.Add(new KeyValuePair<int, int>(maxSkillValue, skillIndexCount));
		}

		public double Calculate(int[] x)
		{
			int result = 0;
			foreach(int skillCount in m_skills1)
			{
				result += x[skillCount];
			}

			foreach (KeyValuePair<int, int> skillCount in m_skills2)
			{
				result += skillCount.Key - x[skillCount.Value];
			}

			result -= m_existingCount;
			if (result < 0)
			{
				result = 0;
			}

			return result;
		}
		#endregion
	}
}
