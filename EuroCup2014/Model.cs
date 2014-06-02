using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using TheSettlersCalculator.EuroCup2014.Calculator;
using TheSettlersCalculator.EuroCup2014.Comparers;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Model : INotifyPropertyChanged
	{
		#region Fields
		private readonly List<ResourceWithCount> m_resources;
		private readonly List<BuffWithCount> m_buffs;
		private readonly List<Skill> m_skills;
		private readonly ObservableCollection<Camp> m_camps = new ObservableCollection<Camp>();
		private readonly List<SkillWithCount> m_totalSkills;
		private readonly IncomingResources m_incomingResources = new IncomingResources(0, 0, 0, 1.5, 1);
		private readonly ObservableCollection<ResourceWithDouble> m_incomingResourcesList = new ObservableCollection<ResourceWithDouble>();
		private ObservableCollection<Result> m_results = new ObservableCollection<Result>();
		private Result m_result = null;		
		#endregion

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Constructor
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

			m_totalSkills = new List<SkillWithCount>(m_skills.Count);
			foreach (Skill skill in m_skills)
			{
				m_totalSkills.Add(new SkillWithCount(skill, 0));
			}

			m_resources = new List<ResourceWithCount>();
			foreach(KeyValuePair<string, Resource> pair in EuroCup2014.Resources.ResourceList)
			{
				m_resources.Add(new ResourceWithCount(pair.Value, 0));
			}
			m_resources.Sort(new ComparerByName());
			
			m_camps.CollectionChanged += CampsCollectionChanged;
			CalculateTotalSkills();
			m_incomingResources.PropertyChanged += IncommingResources_Changed;
			IncommingResources_Changed(null, null);
		}

		#endregion

		#region Properties
		public IncomingResources IncomingResources
		{
			get { return m_incomingResources; }
		}

		public ObservableCollection<ResourceWithDouble> IncommingResourcesList
		{
			get { return m_incomingResourcesList; }
		}

		public List<Skill> Skills
		{
			get
			{
				return m_skills;
			}
		}

		public  List<SkillWithCount> TotalSkills
		{
			get { return m_totalSkills; }
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

		public ObservableCollection<Result> Results
		{
			get { return m_results; }
		}

		public Result Result
		{
			get { return m_result; }
			set 
			{ 
				m_result = value;
				OnPropertyChanged("Result");
			}
		}
		#endregion

		#region Methods
		internal void Calculate()
		{
			try
			{
				Calculator.Calculator calculator = new Calculator.Calculator(m_resources, m_buffs);
				m_results = new ObservableCollection<Calculator.Result>(calculator.Calculate(new List<Camp>(m_camps), m_incomingResources));
				m_result = m_results.Count > 0 ? m_results[0] : null;
				OnPropertyChanged("Result");
				OnPropertyChanged("Results");
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK);
			}
		}

		internal void SelectQuest(Quest quest)
		{
			m_camps.Clear();
			foreach (Camp camp in quest.Camps)
			{
				Camp newCamp = new Camp(camp);
				foreach (SkillWithCount skill in newCamp.Skills)
				{
					skill.PropertyChanged += Model_PropertyChanged;
				}
				m_camps.Add(newCamp);
			}
		}

		internal void AddCamp(Camp camp)
		{
			foreach (SkillWithCount skill in camp.Skills)
			{
				skill.PropertyChanged += Model_PropertyChanged;
			}
			m_camps.Add(camp);
		}

		internal void EditCamp(Camp camp)
		{
			foreach (SkillWithCount skill in camp.Skills)
			{
				skill.PropertyChanged -= Model_PropertyChanged;
				skill.PropertyChanged += Model_PropertyChanged;
			}
			CalculateTotalSkills();
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void CalculateTotalSkills()
		{
			Dictionary<string, int> temp = new Dictionary<string, int>(m_skills.Count);
			foreach(Skill skill in m_skills)
			{
				temp.Add(skill.Id, 0);
			}

			foreach(Camp camp in m_camps)
			{
				foreach(SkillWithCount skill in camp.Skills)
				{
					temp[skill.Skill.Id] += skill.Count;
				}
			}

			foreach(SkillWithCount skill in m_totalSkills)
			{
				skill.Count = temp[skill.Skill.Id];
			}

			OnPropertyChanged("TotalSkills");
		}

		private void CampsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			CalculateTotalSkills();
		}

		private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals("Count", StringComparison.Ordinal))
			{
				CalculateTotalSkills();
			}
		}

		private void IncommingResources_Changed(object sender, PropertyChangedEventArgs e)
		{
			IDictionary<string, double> temp = m_incomingResources.GetResources();			
			List<ResourceWithDouble> result = new List<ResourceWithDouble>(temp.Count);
			foreach(KeyValuePair<string, double> pair in temp)
			{
				result.Add(new ResourceWithDouble(pair.Key, pair.Value));
			}

			result.Sort(new ComparerByName());
			m_incomingResourcesList.Clear();			
			foreach(ResourceWithDouble value in result)
			{
				m_incomingResourcesList.Add(value);
			}			
		}
		#endregion
	}
}
