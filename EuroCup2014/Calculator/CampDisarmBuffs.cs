using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Calculator
{
	public class CampDisarmBuffs
	{
		#region Fields
		private Camp m_camp;
		private List<BuffWithCount> m_buffs = new List<BuffWithCount>();
		#endregion

		#region Constructor
		internal CampDisarmBuffs(Camp camp)
		{
			m_camp = camp;
		}
		#endregion

		#region Properties
		public Camp Camp
		{
			get { return m_camp; }
		}

		public List<BuffWithCount> Buffs
		{
			get { return m_buffs; }
		}
		#endregion

		#region Methods
		internal bool Validate()
		{
			Dictionary<string, int> skills = new Dictionary<string, int>();

			foreach(SkillWithCount skill in Camp.Skills)
			{
				skills.Add(skill.Skill.Id, skill.Count);
			}

			foreach(BuffWithCount buffWithCount in m_buffs)
			{
				int count = buffWithCount.Count;
				foreach(string skillPriority in buffWithCount.Buff.SkillPriority)
				{
					if (skills.ContainsKey(skillPriority))
					{
						if (skills[skillPriority] >= count)
						{							
							skills[skillPriority] -= count;
							count = 0;
						}
						else
						{
							count -= skills[skillPriority];
							skills[skillPriority] = 0;
						}
					}

					if (count == 0) break;
				}

				if (count > 0)
				{
					return false;
				}
			}

			foreach (KeyValuePair<string, int> pair in skills)
			{
				if (pair.Value > 0) return false;
			}

			return true;
		}
		#endregion
	}
}
