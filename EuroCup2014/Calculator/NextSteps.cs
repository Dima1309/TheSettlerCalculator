using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Calculator
{
	internal class NextSteps
	{
		#region Fields
		private int[] m_init;
		private List<SkillWithCount> m_skills;
		#endregion

		#region Constructor
		internal NextSteps(int[] init, List<SkillWithCount> skills)
		{
			m_init = init;
			m_skills = skills;
		}
		#endregion

		#region Methods
		internal IEnumerable<int[]> GetSteps()
		{
			int[] result = (int[])m_init.Clone();

			for (int i = 0; i < result.Length; i++)
			{
				if (result[i] > 0)
				{
					result[i]--;
					yield return result;
					result[i]++;
				}

				if (result[i]+1<m_skills[i].Count)
				{
					result[i]++;
					yield return result;
					result[i]--;
				}
			}

			//decrease at index i and increase at index j
			for(int i=0; i< result.Length; i++)
			{
				if (result[i] == 0) continue;//cannot decrease

				for(int j=0; j < result.Length; j++)
				{
					if (i == j) continue;

					if (result[j] + 1 < m_skills[i].Count) continue; //cannot increase

					result[i]--;
					result[j]++;
					yield return result;
					result[i]++;
					result[j]--;
				}
			}
		}
		#endregion
	}
}
