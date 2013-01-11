﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Statistics;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.Types.Simulation;

namespace TheSettlersCalculator.WpfTypes
{
	public class MainWindowModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Constants
		private const int ROUNDS = 10000;
		private const int MAX_WAVES_COUNT = 5;
		#endregion

		#region Fields
		private readonly ObservableCollection<UnitSquad>[] m_playerWaves = new ObservableCollection<UnitSquad>[MAX_WAVES_COUNT];
		private readonly ObservableCollection<UnitSquad>[] m_enemyWaves = new ObservableCollection<UnitSquad>[MAX_WAVES_COUNT];
		private int m_playerWaveIndex = 0;
		private int m_enemyWaveIndex = 0;
		private readonly ObservableCollection<EnemyCamp> m_activeQuestCamps = new ObservableCollection<EnemyCamp>();
		private readonly ObservableCollection<Quest> m_quests = new ObservableCollection<Quest>();
		private readonly List<Losses> m_playerLosses = new List<Losses>();
		private readonly List<Losses> m_enemyLosses = new List<Losses>();
		private double[] m_playerTowerBonus = new double[MAX_WAVES_COUNT];
		private double[] m_enemyTowerBonus = new double[MAX_WAVES_COUNT];
		private Quest m_activeQuest;
		private EnemyCamp m_activeEnemyCamp;
		private bool m_veteranAvailable;
		private bool m_userUnitsCountWarning;
		private MultyWaveBattleSimulation m_simulation;
		#endregion

		#region Constructor
		internal MainWindowModel()
		{
			for(int i = 0; i < MAX_WAVES_COUNT; i++)
			{
				m_playerWaves[i] = new ObservableCollection<UnitSquad>();
				m_enemyWaves[i] = new ObservableCollection<UnitSquad>();
			}

			DarkTemplareQuest quest = new DarkTemplareQuest();

			for(int i = 0; i < MAX_WAVES_COUNT; i++)
			{				
				m_playerWaves[i].Clear();
				foreach (Unit unit in Types.PlayerUnits.Units)
				{
					UnitSquad unitSquad = new UnitSquad(unit, 0);
					m_playerWaves[i].Add(unitSquad);
					unitSquad.PropertyChanged += UpdateUserUnitCount;
				}
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
				foreach (UnitSquad squad in PlayerUnits)
				{
					result += squad.Count;
				}

				return result;
			}
		}

		public ObservableCollection<UnitSquad> PlayerUnits
		{
			get { return m_playerWaves[m_playerWaveIndex]; }
		}

		public ObservableCollection<UnitSquad> EnemyUnits
		{
			get { return m_enemyWaves[m_enemyWaveIndex]; }
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

						for(int i=0;i<MAX_WAVES_COUNT;i++)
						{
							m_enemyWaves[i].Clear();
							foreach (Unit unit in m_activeQuest.Units)
							{
								m_enemyWaves[i].Add(new UnitSquad(unit, 0));
							}
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

						foreach(UnitSquad enemyUnit in EnemyUnits)
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
			get
			{
				return m_playerTowerBonus[m_playerWaveIndex];
			}

			set
			{
				if (m_playerTowerBonus[m_playerWaveIndex] != value)
				{
					m_playerTowerBonus[m_playerWaveIndex] = value;
					OnPropertyChanged("PlayerTowerBonus");
				}
			}
		}

		public double EnemyTowerBonus
		{
			get
			{
				return m_enemyTowerBonus[m_enemyWaveIndex];
			}

			set
			{
				if (m_enemyTowerBonus[m_enemyWaveIndex] != value)
				{
					m_enemyTowerBonus[m_enemyWaveIndex] = value;
					OnPropertyChanged("EnemyTowerBonus");
				}
			}
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

		public MultyWaveBattleSimulation Simulation
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

		public int PlayerWaveIndex
		{
			get
			{
				return m_playerWaveIndex;
			}

			set
			{
				if (m_playerWaveIndex != value)
				{
					m_playerWaveIndex = value;
					OnPropertyChanged("PlayerWaveIndex");
					OnPropertyChanged("PlayerUnits");
					OnPropertyChanged("PlayerUnitsCount");
					OnPropertyChanged("PlayerTowerBonus");
				}
			}
		}

		public int EnemyWaveIndex
		{
			get
			{
				return m_enemyWaveIndex;
			}

			set
			{
				if (m_enemyWaveIndex != value)
				{
					m_enemyWaveIndex = value;
					OnPropertyChanged("EnemyWaveIndex");
					OnPropertyChanged("EnemyUnits");
					OnPropertyChanged("EnemyTowerBonus");
				}
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
			//unist, counts, general, enemy units, counts, generals
			MultiWaveBattle battle = new MultiWaveBattle(ROUNDS);

			for(int i=0;i<MAX_WAVES_COUNT;i++)
			{
				battle.AddAttackerWave(m_playerWaves[i], true, m_playerTowerBonus[i]);
				battle.AddEnemyWave(m_enemyWaves[i], false, m_enemyTowerBonus[i]);
			}

			MultiWaveStatistics statistics = new MultiWaveStatistics(battle);
			battle.OnBattleComplete += statistics.MultiWaveBattleCompleteHandler;
			battle.OnWaveComplete += statistics.MultiWaveBattleWaveCompleteHandler;

			MultyWaveBattleSimulation simulation = new MultyWaveBattleSimulation();
			battle.OnBattleComplete += simulation.MultiWaveBattleCompleteHandler;
			battle.OnWaveComplete += simulation.MultiWaveBattleWaveCompleteHandler;

			battle.Calculate(calculator);

			battle.OnBattleComplete -= statistics.MultiWaveBattleCompleteHandler;
			battle.OnWaveComplete -= statistics.MultiWaveBattleWaveCompleteHandler;

			battle.OnBattleComplete -= simulation.MultiWaveBattleCompleteHandler;
			battle.OnWaveComplete -= simulation.MultiWaveBattleWaveCompleteHandler;

			PlayerLosses.Clear();
			for(int i = 0; i < statistics.TotalStatistics.MinAttackerLosses.Length; i++)
			{
				PlayerLosses.Add(new Losses(
					battle.Units[i],
					statistics.TotalStatistics.MinAttackerLosses[i],
					statistics.TotalStatistics.AvgAttackerLosses[i],
					statistics.TotalStatistics.MaxAttackerLosses[i]));
			}

			EnemyLosses.Clear();
			for (int i = 0; i < statistics.TotalStatistics.MinDefenderLosses.Length; i++)
			{
				EnemyLosses.Add(new Losses(
					battle.EnemyUnits[i],
					statistics.TotalStatistics.MinDefenderLosses[i],
					statistics.TotalStatistics.AvgDefenderLosses[i],
					statistics.TotalStatistics.MaxDefenderLosses[i]));
			}

			OnPropertyChanged("PlayerLosses");
			OnPropertyChanged("EnemyLosses");

			Simulation = simulation;
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
