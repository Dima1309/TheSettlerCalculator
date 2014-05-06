using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TheSettlersCalculator.EuroCup2014.Comparers;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Model
	{
		#region Fields
		private readonly List<ResourceWithCount> m_collectibleResources;
		private readonly List<ResourceWithCount> m_nonCollectibleResources;
		private readonly List<ResourceWithCount> m_resources;
		private readonly List<BuffWithCount> m_buffs;
		private readonly List<Skill> m_skills;
		private readonly ObservableCollection<Camp> m_camps = new ObservableCollection<Camp>();
		#endregion

		#region Model
		internal Model()
		{			
			m_buffs = new List<BuffWithCount>();
			foreach(KeyValuePair<string, Buff> pair in EuroCup2014.Buffs.BuffList)
			{
				m_buffs.Add(new BuffWithCount(pair.Value, 0));
			}
			m_buffs.Sort(new ComparerByName());

			m_skills = new List<Skill>(EuroCup2014.Skills.SkillList.Values);			
			m_skills.Sort(new ComparerByName());

			m_collectibleResources = new List<ResourceWithCount>();
			m_nonCollectibleResources = new List<ResourceWithCount>();
			m_resources = new List<ResourceWithCount>();
			foreach(KeyValuePair<string, Resource> pair in EuroCup2014.Resources.ResourceList)
			{
				m_resources.Add(new ResourceWithCount(pair.Value, 0));
			}
			m_resources.Sort(new ComparerByName());

			foreach(Camp camp in Quests.QuestList[0].Camps)
			{
				m_camps.Add(camp);
			}
		}
		#endregion

		#region Properties
		public List<Skill> Skills
		{
			get
			{
				return m_skills;
			}
		}

		public List<ResourceWithCount> Resources
		{
			get
			{
				return m_resources;
			}
		}

		public List<BuffWithCount> Buffs
		{
			get
			{
				return m_buffs;
			}
		}

		public ObservableCollection<Camp> Camps
		{
			get { return m_camps; }
		}
		#endregion
	}
}
