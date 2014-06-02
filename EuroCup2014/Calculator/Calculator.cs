using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheSettlersCalculator.EuroCup2014.Comparers;
using TheSettlersCalculator.EuroCup2014.Expressions;

namespace TheSettlersCalculator.EuroCup2014.Calculator
{
	internal class Calculator
	{
		#region Internal Class
		private class InternalResult : IComparable<InternalResult>
		{
			#region Fields
			private double m_time;
			private int[] m_result;
			#endregion

			#region Constructor
			internal InternalResult(double time, int[] result)
			{
				m_time = time;
				m_result = result;
			}
			#endregion

			#region Properties
			internal double Time
			{
				get { return m_time; }
				set { m_time = value; }
			}

			internal int[] Solution
			{
				get { return m_result; }
				set { m_result = value; }
			}
			#endregion

			#region Methods
			public int CompareTo(InternalResult other)
			{
				return m_time.CompareTo(other.m_time);
			}
			#endregion
		}
		#endregion

		#region Fields
		private List<ResourceWithCount> m_existingResources;
		private List<BuffWithCount> m_existingBuffs;
		#endregion

		#region Constructor
		internal Calculator(IEnumerable<ResourceWithCount> existingResources, IEnumerable<BuffWithCount> existingBuffs)
		{
			m_existingResources = new List<ResourceWithCount>(existingResources);
			m_existingBuffs = new List<BuffWithCount>(existingBuffs);
		}
		#endregion

		internal List<Result> Calculate(IEnumerable<Camp> camps, IncomingResources incomingResourcesObject)
		{
			// Calculate total skills needed
			DateTime start = DateTime.Now;
			SortedDictionary<string, SkillWithCount> skills = new SortedDictionary<string, SkillWithCount>();
			foreach (Camp camp in camps)
			{
				foreach (SkillWithCount campSkillWithCount in camp.Skills)
				{
					SkillWithCount skillWithCount = null;
					if (skills.TryGetValue(campSkillWithCount.Skill.Id, out skillWithCount))
					{
						skillWithCount.Count += campSkillWithCount.Count;
					}
					else
					{
						skillWithCount = new SkillWithCount(campSkillWithCount.Skill, campSkillWithCount.Count);
						skills.Add(skillWithCount.Skill.Id, skillWithCount);
					}
				}
			}

			int[] skillCount = new int[skills.Count];
			List<SkillWithCount> skillsWithCount = new List<SkillWithCount>(skills.Values);
			IDictionary<string, double> incomingResources = incomingResourcesObject.GetResources();

			int MAX_RESULTS=10;
			List<InternalResult> internalResults = new List<InternalResult>(MAX_RESULTS);
			
			SortedDictionary<string, BuffCountExpression> buffExpressions = PrepareBuffExpressions(skillsWithCount);			
			SortedDictionary<string, ResourceCountExpression> resourceExpression = PrepareResourceExpressions(buffExpressions);
			TimeExpression timeExpression = new TimeExpression();
			foreach(KeyValuePair<string, ResourceCountExpression> pair in resourceExpression)
			{
				timeExpression.Add(incomingResources[pair.Key], pair.Value);
			}

			double totalVariantCount = 1;
			foreach(SkillWithCount skill in skillsWithCount)
			{
				totalVariantCount *= skill.Count + 1;
			}
			int inc = 1;
			if (totalVariantCount > 10000000)
			{
				inc = 2;
			}
			if (totalVariantCount > 15000000)
			{
				inc = 3;
			}

			while (Inc(skillCount, skillsWithCount, inc))
			{
				double time = timeExpression.Calculate(skillCount);

				if (internalResults.Count < MAX_RESULTS)
				{
					InternalResult newResult = new InternalResult(time, (int[])skillCount.Clone());
					AddResult(internalResults, newResult);
				}
				else if (time < internalResults[MAX_RESULTS-1].Time)
				{
					internalResults.RemoveAt(MAX_RESULTS - 1);
					InternalResult newResult = new InternalResult(time, (int[])skillCount.Clone());
					AddResult(internalResults, newResult);
				}
			}

			if (inc > 1)
			{
				AdjastSolutions(skillsWithCount, internalResults, timeExpression);
			}

			return PrepareResults(camps, skillsWithCount, internalResults, buffExpressions);			
		}

		private static List<Result> PrepareResults(IEnumerable<Camp> camps, List<SkillWithCount> skillsWithCount, List<InternalResult> internalResults, SortedDictionary<string, BuffCountExpression> buffExpressions)
		{
			List<Result> result = new List<Result>(internalResults.Count);
			for (int i = 0; i < internalResults.Count; i++)
			{
				Result newResult = new Result(internalResults[i].Time);
				foreach (KeyValuePair<string, BuffCountExpression> pair in buffExpressions)
				{
					int count = (int)pair.Value.Calculate(internalResults[i].Solution);
					if (count <= 0) continue;
					newResult.ProducedBuffs.Add(new BuffWithCount(Buffs.BuffList[pair.Key], count));
				}
				newResult.ProducedBuffs.Sort(new ComparerByName());
				bool skipResult = false;

				//Key: skill_buff, remain_count
				Dictionary<string, int> remainingBuffs = GetRemainingSkills(skillsWithCount, internalResults[i]);

				foreach (Camp camp in camps)
				{
					CampDisarmBuffs campBuffs = new CampDisarmBuffs(camp);
					foreach (SkillWithCount skill in camp.Skills)
					{
						int count = skill.Count;
						int j = 0;
						while (count > 0)
						{
							int tmp;
							string buffId = string.Format("{0}_{1}", skill.Skill.Id, j);
							if (remainingBuffs.TryGetValue(buffId, out tmp) && tmp > 0)
							{
								if (tmp >= count)
								{
									tmp -= count;
									campBuffs.Buffs.Add(new BuffWithCount(skill.Skill.Buffs[j], count));
									count = 0;
								}
								else
								{
									count -= tmp;
									campBuffs.Buffs.Add(new BuffWithCount(skill.Skill.Buffs[j], tmp));
									tmp = 0;
								}

								remainingBuffs[buffId] = tmp;
							}

							j++;
						}
					}

					if (!campBuffs.Validate())
					{
						skipResult = true;
					}

					newResult.Solution.Add(campBuffs);
				}

				if (!skipResult)
				{
					result.Add(newResult);
				}
			}
			return result;
		}

		private static Dictionary<string, int> GetRemainingSkills(List<SkillWithCount> skillsWithCount, InternalResult internalResult)
		{
			Dictionary<string, int> result = new Dictionary<string,int>();
			
			for(int i=0; i < skillsWithCount.Count; i++)
			{
				int j = 0;
				foreach (Buff buff in skillsWithCount[i].Skill.Buffs)
				{
					int count = internalResult.Solution[i];
					if (j > 0)
					{
						count = skillsWithCount[i].Count - count;
					}

					result.Add(string.Format("{0}_{1}", skillsWithCount[i].Skill.Id, j), count);
					j++;
				}				
			}

			return result;
		}

		private static void AddResult(List<InternalResult> results, InternalResult newResult)
		{
			int index = results.BinarySearch(newResult);
			if (index < 0)
			{
				results.Insert(~index, newResult);
			}
			else
			{
				results.Insert(index, newResult);
			}
		}

		private static void AdjastSolutions(List<SkillWithCount> skillsWithCount, List<InternalResult> results, TimeExpression timeExpression)
		{
			for (int i = 0; i < results.Count; i++)
			{
				double bestTime = results[i].Time;
				int[] bestResult = results[i].Solution;
				bool flag = true;
				while (flag)
				{
					flag = false;
					NextSteps nextSteps = new NextSteps(bestResult, skillsWithCount);
					foreach (int[] tmp in nextSteps.GetSteps())
					{
						double time = timeExpression.Calculate(tmp);
						if (time < bestTime)
						{
							bestResult = (int[])tmp.Clone();
							bestTime = time;
							flag = true;
						}
					}

					if (flag)
					{
						results[i].Time = bestTime;
						results[i].Solution = bestResult;
					}
				}
			}

			results.Sort();
		}
		
		private void CalculateExistingBuffs(IDictionary<Buff, int> buffs)
		{
			foreach (BuffWithCount existingBuff in m_existingBuffs)
			{
				if (buffs.ContainsKey(existingBuff.Buff))
				{
					buffs[existingBuff.Buff] -= existingBuff.Count;
					if (buffs[existingBuff.Buff] < 0)
					{
						buffs[existingBuff.Buff] = 0;
					}
				}
			}
		}

		private void CalculateExistingResoruces(IDictionary<Resource, int> resources)
		{
			foreach (ResourceWithCount existingResoruce in m_existingResources)
			{
				if (resources.ContainsKey(existingResoruce.Resource))
				{
					resources[existingResoruce.Resource] -= existingResoruce.Count;
					if (resources[existingResoruce.Resource] < 0)
					{
						resources[existingResoruce.Resource] = 0;
					}
				}
			}
		}

		internal static IDictionary<Buff, int> CalculateBuffs(int[] skillCount, List<SkillWithCount> skills)
		{
			Dictionary<Buff, int> result = new Dictionary<Buff, int>();

			for (int i = 0; i < skillCount.Length; i++)
			{
				int count1 = skills[i].Count - skillCount[i];
				int count2 = skills[i].Count - skillCount[i];
				foreach (Buff buff in skills[i].Skill.Buffs)
				{
					if (!result.ContainsKey(buff))
					{
						result.Add(buff, 0);
					}
				}

				result[skills[i].Skill.Buffs[0]] += count1;
				result[skills[i].Skill.Buffs[1]] += count2;
			}

			return result;
		}

		internal static IDictionary<Resource, int> CalculateResources(IDictionary<Buff, int> buffs)
		{
			Dictionary<Resource, int> result = new Dictionary<Resource, int>();
			foreach(KeyValuePair<string, Resource> resource in Resources.ResourceList)
			{
				result.Add(resource.Value, 0);
			}

			foreach(KeyValuePair<Buff, int> buff in buffs)
			{
				foreach(ResourceWithCount resource in buff.Key.ProvisionHouseCost)
				{
					result[resource.Resource] += resource.Count * buff.Value;
				}
			}

			return result;
		}

		private bool Inc(int[] skillCount, List<SkillWithCount> skillWithCount, int inc)
		{
			int i = 0;
			while (i < skillCount.Length)
			{
				skillCount[i] += inc;
				if (skillCount[i] > skillWithCount[i].Count)
				{
					skillCount[i] = 0;
					i++;
					continue;
				}

				return true;
			}

			return false;
		}

		private double CalculateTime(IDictionary<Resource, int> resources, IDictionary<string, double> incommingResources)
		{
			double result = 0;

			foreach(KeyValuePair<Resource, int> pair in resources)
			{
				double value = (double)pair.Value / incommingResources[pair.Key.Id];
				if (value > result)
				{
					result = value;
				}
			}

			return result;
		}

		private SortedDictionary<string, BuffCountExpression> PrepareBuffExpressions(List<SkillWithCount> skillsWithCount)
		{
			SortedDictionary<string, BuffCountExpression> buffExpressions = new SortedDictionary<string, BuffCountExpression>();
			int index = 0;
			foreach (SkillWithCount skill in skillsWithCount)
			{
				for (int i = 0; i < skill.Skill.Buffs.Count; i++)
				{
					BuffCountExpression expression = null;

					if (!buffExpressions.TryGetValue(skill.Skill.Buffs[i].Id, out expression))
					{
						expression = new BuffCountExpression();
						buffExpressions.Add(skill.Skill.Buffs[i].Id, expression);
					}

					if (i == 0)
					{
						expression.AddPrimaryBuff(index);
					}
					else
					{
						expression.AddSecondaryBuff(skill.Count, index);
					}
				}

				index++;
			}

			foreach (BuffWithCount buff in m_existingBuffs)
			{
				BuffCountExpression expression = null;
				if (buffExpressions.TryGetValue(buff.Buff.Id, out expression))
				{
					expression.ExistingCount = buff.Count;
				}
			}

			return buffExpressions;
		}

		private SortedDictionary<string, ResourceCountExpression> PrepareResourceExpressions(SortedDictionary<string, BuffCountExpression> buffExpressions)
		{
			 SortedDictionary<string, ResourceCountExpression> result= new SortedDictionary<string, ResourceCountExpression>();			
			
			foreach (KeyValuePair<string, BuffCountExpression> pair in buffExpressions)
			{
				Buff buff = Buffs.BuffList[pair.Key];
				
				foreach(ResourceWithCount resource in buff.ProvisionHouseCost)
				{
					ResourceCountExpression expression = null;

					if (!result.TryGetValue(resource.Resource.Id, out expression))
					{
						expression = new ResourceCountExpression();
						result.Add(resource.Resource.Id, expression);
					}

					expression.AddBuff(resource.Count, pair.Value);
				}
				
			}

			foreach (ResourceWithCount resource in m_existingResources)
			{
				ResourceCountExpression expression = null;
				if (result.TryGetValue(resource.Resource.Id, out expression))
				{
					expression.ExistingResource = resource.Count;
				}
			}

			return result;
		}
	}
}
