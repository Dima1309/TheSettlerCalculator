using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;

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
		private readonly ObservableCollection<Losses> m_playerLosses = new ObservableCollection<Losses>();
		private readonly ObservableCollection<Losses> m_enemyLosses = new ObservableCollection<Losses>();
		private double m_playerTowerBonus;
		private double m_enemyTowerBonus;
		private Quest m_activeQuest;
		private EnemyCamp m_activeEnemyCamp;		
		#endregion

		#region Constructor
		internal MainWindowModel()
		{
			DarkTemplareQuest quest = new DarkTemplareQuest();
			foreach (Unit unit in Types.PlayerUnits.Units)
			{
				m_playerUnits.Add(new UnitSquad(unit, 0));
			}

			Quests.Add(quest);

			ActiveQuest = quest;
		}
		#endregion

		#region Properties
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

		public ObservableCollection<Losses> PlayerLosses
		{
			get { return m_playerLosses; }
		}

		public ObservableCollection<Losses> EnemyLosses
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
		}
		#endregion
	}
}
