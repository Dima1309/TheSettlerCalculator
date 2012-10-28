using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.Types.Simulation;

namespace TheSettlersCalculator.WpfTypes
{
	public class MainWindowModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Constants
		private const int ROUNDS = 10000;
		#endregion

		#region Fields
		private readonly ObservableCollection<UnitSquad> m_playerUnits = new ObservableCollection<UnitSquad>();
		private readonly ObservableCollection<UnitSquad> m_enemyUnits = new ObservableCollection<UnitSquad>();
		private readonly ObservableCollection<EnemyCamp> m_activeQuestCamps = new ObservableCollection<EnemyCamp>();
		private readonly ObservableCollection<Quest> m_quests = new ObservableCollection<Quest>();
		private readonly List<Losses> m_playerLosses = new List<Losses>();
		private readonly List<Losses> m_enemyLosses = new List<Losses>();
		private double m_playerTowerBonus;
		private double m_enemyTowerBonus;
		private Quest m_activeQuest;
		private EnemyCamp m_activeEnemyCamp;
		private bool m_veteranAvailable;
		private bool m_userUnitsCountWarning;
		private BattleSimulation m_simulation;
		#endregion

		#region Constructor
		internal MainWindowModel()
		{			
			DarkTemplareQuest quest = new DarkTemplareQuest();
			foreach (Unit unit in Types.PlayerUnits.Units)
			{
				m_playerUnits.Add(new UnitSquad(unit, 0));
			}

			foreach(UnitSquad squad in  m_playerUnits)
			{
				squad.PropertyChanged += UpdateUserUnitCount;
			}

			Quests.Add(quest);

			ActiveQuest = quest;
		}
		#endregion

		#region Properties
		public int PlayerUnitsCount
		{
			get 
			{ 
				int result = 0;
				foreach(UnitSquad squad in m_playerUnits)
				{
					result += squad.Count;
				}

				return result;
			}
		}

		public ObservableCollection<UnitSquad> PlayerUnits
		{
			get { return m_playerUnits; }
		}

		public ObservableCollection<UnitSquad> EnemyUnits
		{
			get { return m_enemyUnits; }
		}

		public ObservableCollection<Quest> Quests
		{
			get { return m_quests; }
		}

		public Quest ActiveQuest
		{
			get
			{
				return m_activeQuest;
			}

			set
			{
				if (!ReferenceEquals(m_activeQuest, value))
				{
					m_activeQuest = value;
					OnPropertyChanged("ActiveQuest");

					m_activeQuestCamps.Clear();
					if (m_activeQuest != null)
					{
						foreach(Camp camp in ActiveQuest.Camps)
						{
							m_activeQuestCamps.Add(new EnemyCamp(m_activeQuest, camp));
						}

						m_enemyUnits.Clear();
						foreach (Unit unit in m_activeQuest.Units)
						{
							m_enemyUnits.Add(new UnitSquad(unit, 0));
						}
					}
				}
			}
		}

		public ObservableCollection<EnemyCamp> ActiveQuestCamps
		{
			get { return m_activeQuestCamps; }
		}

		public EnemyCamp ActiveEnemyCamp
		{
			get
			{
				return m_activeEnemyCamp;
			}
			set
			{
				if (!ReferenceEquals(m_activeEnemyCamp, value))
				{
					m_activeEnemyCamp = value;
					OnPropertyChanged("ActiveEnemyCamp");

					if (m_activeEnemyCamp != null)
					{
						Dictionary<string, int> counts = new Dictionary<string, int>();
						foreach (UnitSquad squad in m_activeEnemyCamp.Squads)
						{
							counts.Add(squad.Name, squad.Count);
						}

						foreach(UnitSquad enemyUnit in m_enemyUnits)
						{
							int count;
							if (!counts.TryGetValue(enemyUnit.Name, out count))
							{
								count = 0;
							}

							enemyUnit.Count = count;
						}
					}
				}
			}
		}

		public List<Losses> PlayerLosses
		{
			get { return m_playerLosses; }
		}

		public List<Losses> EnemyLosses
		{
			get { return m_enemyLosses; }
		}

		public double PlayerTowerBonus
		{
			get { return m_playerTowerBonus; }
			set { m_playerTowerBonus = value; }
		}

		public double EnemyTowerBonus
		{
			get { return m_enemyTowerBonus; }
			set { m_enemyTowerBonus = value; }
		}

		public int PlayerUnitLimit
		{
			get { return m_veteranAvailable ? 250 : 200; }
		}

		public bool VeteranAvailable
		{
			get { return m_veteranAvailable; }
			set
			{
				if (m_veteranAvailable != value)
				{
					m_veteranAvailable = value;
					OnPropertyChanged("PlayerUnitLimit");
					CheckUserUnitsCount();					
				}
			}
		}

		public bool UserUnitsCountWarning
		{
			get
			{
				return m_userUnitsCountWarning;
			}

			set
			{
				if (m_userUnitsCountWarning != value)
				{
					m_userUnitsCountWarning = value;
					OnPropertyChanged("UserUnitsCountWarning");
				}
			}
		}

		public BattleSimulation Simulation
		{
			get
			{
				return m_simulation;
			}

			set
			{
				m_simulation = value;
				OnPropertyChanged("Simulation");
			}
		}
		#endregion

		#region Methods
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		internal void Calculate()
		{			
			Calculator calculator = new Calculator(ROUNDS);
			//unist, counts, generatl, enemy units, counts, generals
			Battle battle = new Battle(PlayerUnits, true, EnemyUnits, false);
			Statistics.Statistics statistics = new Statistics.Statistics(battle);
			calculator.OnBattleComplete += statistics.BattleComplete;
			calculator.Calculate(battle);

			PlayerLosses.Clear();
			for(int i = 0; i < statistics.MinAttackerLosses.Length; i++)
			{
				PlayerLosses.Add(new Losses(
					battle.Units[i], 
					statistics.MinAttackerLosses[i],
					statistics.AvgAttackerLosses[i],
					statistics.MaxAttackerLosses[i]));
			}

			EnemyLosses.Clear();
			for (int i = 0; i < statistics.MinDefenderLosses.Length; i++)
			{
				EnemyLosses.Add(new Losses(
					battle.EnemyUnits[i],
					statistics.MinDefenderLosses[i],
					statistics.AvgDefenderLosses[i],
					statistics.MaxDefenderLosses[i]));
			}

			OnPropertyChanged("PlayerLosses");
			OnPropertyChanged("EnemyLosses");

			Simulation = new BattleSimulation(battle);
		}

		private void UpdateUserUnitCount(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName=="Count")
			{
				OnPropertyChanged("PlayerUnitsCount");
				CheckUserUnitsCount();
			}
		}

		private void CheckUserUnitsCount()
		{
			int maxCount = PlayerUnitLimit;
			UserUnitsCountWarning = PlayerUnitsCount > maxCount;
		}
		#endregion
	}
}
