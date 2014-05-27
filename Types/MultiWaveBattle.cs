using System;
using System.Collections.Generic;
using TheSettlersCalculator.Specialists.Generals;
using TheSettlersCalculator.Statistics;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Types
{
	internal class MultiWaveBattle
	{
		#region Private class
		private class BattleWave
		{
			#region Fields
			private readonly IList<UnitSquad> m_squads;
			private readonly General m_general;
			private readonly double m_towerBonus;
			private readonly double m_destroyCampTime;
			#endregion

			#region Constructor
			internal BattleWave(IList<UnitSquad> squads, General general, double towerBonus, double destroyCampTime)
			{
				m_squads = new List<UnitSquad>(squads.Count);
				foreach(UnitSquad squad in squads)
				{
					m_squads.Add(squad.Clone() as UnitSquad);
				}
				m_general = general;
				m_towerBonus = towerBonus;
				m_destroyCampTime = destroyCampTime;
			}
			#endregion

			#region Properties
			public IEnumerable<UnitSquad> Squads
			{
				get { return m_squads; }
			}

			public General General
			{
				get { return m_general; }
			}

			public double TowerBonus
			{
				get { return m_towerBonus; }
			}

			public double DestroyCampTime
			{
				get { return m_destroyCampTime; }
			}
			#endregion
		}
		#endregion

		#region Fields
		private readonly List<BattleWave> m_playerWaves = new List<BattleWave>();
		private readonly List<BattleWave> m_enemyWaves = new List<BattleWave>();
		private MultiWaveBattleType m_battleType = MultiWaveBattleType.TakeWorstWave;
		private readonly int m_iterationCount;
		private List<Unit> m_units;
		private List<Unit> m_enemyUnits;

		private StatisticsType m_statisticsType;
		private MultiWaveBattleWaveCompleteHandler m_waveCompleteHandler;
		private MultiWaveBattleCompleteHandler m_battleCompleteHandler;
		#endregion

		public event MultiWaveBattleWaveCompleteHandler OnWaveComplete
		{
			add { m_waveCompleteHandler += value; }
			remove { m_waveCompleteHandler -= value; }
		}

		public event MultiWaveBattleCompleteHandler OnBattleComplete
		{
			add { m_battleCompleteHandler += value; }
			remove { m_battleCompleteHandler -= value; }
		}

		#region Constructor
		internal MultiWaveBattle(int iterationCount)
		{
			m_iterationCount = iterationCount;
		}
		#endregion

		#region Properties
		public MultiWaveBattleType BattleType
		{
			get { return m_battleType; }
			set { m_battleType = value; }
		}

		public int IterationCount
		{
			get { return m_iterationCount; }
		}

		public List<Unit> Units
		{
			get
			{
				if (m_units == null)
				{
					m_units = GetUnits(m_playerWaves);
				}

				return m_units;
			}
		}		

		public List<Unit> EnemyUnits
		{
			get
			{
				if (m_enemyUnits == null)
				{
					m_enemyUnits = GetUnits(m_enemyWaves);
				}

				return m_enemyUnits;
			}
		}

		public StatisticsType StatisticsType
		{
			get { return m_statisticsType; }
			set { m_statisticsType = value; }
		}
		#endregion

		#region Methods
		internal void AddAttackerWave(IList<UnitSquad> units, General general, double towerBonus)
		{
			m_playerWaves.Add(new BattleWave(units, general, towerBonus, 0));
		}

		internal void AddEnemyWave(IList<UnitSquad> units, General general, double towerBonus, double destroyCampTime)
		{
			m_enemyWaves.Add(new BattleWave(units, general, towerBonus, destroyCampTime));
		}

		internal void Calculate(ICalculator calculator)
		{
			Random random = new Random(Options.SEED);
			int iterationCount = GetRepeatCount();

			for(int iter = 0 ; iter < iterationCount; iter++)
			{
				int playerIndex = 0;
				int enemyIndex = 0;
				IList<UnitSquad> playerSquads = null;
				General playerGeneral = null;
				IList<UnitSquad> enemySquads = null;
				General enemyGeneral = null;
				int destroyEnemyCampTime = 0;

				while(playerIndex < m_playerWaves.Count && enemyIndex < m_enemyWaves.Count)
				{
					if (iterationCount == 1)
					{
						random = new Random(Options.SEED);
					}

					if(playerSquads == null)
					{
						playerSquads = new List<UnitSquad>();
						foreach(UnitSquad squad  in m_playerWaves[playerIndex].Squads)
						{
							playerSquads.Add(new UnitSquad(squad.Unit, squad.Count));
						}

						playerGeneral = m_playerWaves[playerIndex].General;
						bool emptyWave = true;
						foreach(UnitSquad squad in playerSquads)
						{
							if (squad.Count > 0)
							{
								emptyWave = false;
								break;
							}
						}

						if (emptyWave)
						{
							playerSquads = null;
							playerIndex++;
							continue;
						}
					}

					if(enemySquads == null)
					{
						enemySquads = new List<UnitSquad>();
						foreach (UnitSquad squad in m_enemyWaves[enemyIndex].Squads)
						{
							enemySquads.Add(new UnitSquad(squad.Unit, squad.Count));
						}
						enemyGeneral = m_enemyWaves[enemyIndex].General;
						destroyEnemyCampTime = (int)m_enemyWaves[enemyIndex].DestroyCampTime;

						bool emptyWave = true;
						foreach (UnitSquad squad in enemySquads)
						{
							if (squad.Count > 0)
							{
								emptyWave = false;
								break;
							}
						}

						if (emptyWave)
						{
							enemySquads = null;
							enemyIndex++;
							continue;
						}
					}

					Battle battle = new Battle(playerSquads, playerGeneral, enemySquads, enemyGeneral);
					battle.PlayerTowerBonus = m_playerWaves[playerIndex].TowerBonus;
					battle.EnemyTowerBonus = m_enemyWaves[enemyIndex].TowerBonus;
					battle.WinBattleTime = destroyEnemyCampTime;
					battle.StatisticsType = m_statisticsType;
					calculator.IterationCount = GetBattleIterationCount();
					Statistics.Statistics statistics = new Statistics.Statistics(battle);
					calculator.OnBattleComplete += statistics.BattleComplete;
					calculator.Calculate(battle, random);
					calculator.OnBattleComplete -= statistics.BattleComplete;
					if (m_waveCompleteHandler!=null)
					{
						m_waveCompleteHandler(this, new MultiWaveBatleWaveCompleteArgs(new WaveKey(playerIndex, enemyIndex), statistics));
					}

					statistics.Calculate();
					bool empty = true;
					short[] defenderLosses = GetEnemyLosses(statistics);
					int i = 0;
					int j = 0;
					while (i < defenderLosses.Length)
					{
						if (enemySquads[j].Count <= 0)
						{
							j++;
							continue;
						}

						enemySquads[j].Count -= defenderLosses[i];
						if (enemySquads[j].Count > 0)
						{
							empty = false;
						}
						i++;
						j++;
					}

					if (empty)
					{
						enemySquads = null;
						enemyIndex++;
					}

					bool enemyEmpty = empty;
					empty = true;
					short[] attackerLosses = GetPlayerLosses(statistics);
					i = 0;
					j = 0;
					while (i < attackerLosses.Length)
					{
						if (playerSquads[j].Count <= 0)
						{
							j++;
							continue;
						}

						playerSquads[j].Count -= attackerLosses[i];
						if(playerSquads[j].Count > 0)
						{
							empty = false;
						}
						i++;
						j++;
					}

					if(empty || !enemyEmpty)
					{
						playerSquads = null;
						playerIndex++;
					}
				}

				//iteration complete
				if (m_battleCompleteHandler!= null)
				{
					m_battleCompleteHandler(this, new EventArgs());
				}
			}
		}

		private static List<Unit> GetUnits(IEnumerable<BattleWave> waves)
		{
			List<Unit> result = new List<Unit>();
			foreach (BattleWave wave in waves)
			{
				foreach (UnitSquad squad in wave.Squads)
				{
					if (result.IndexOf(squad.Unit) < 0)
					{
						result.Add(squad.Unit);
					}
				}
			}

			return result;
		}

		private int GetRepeatCount()
		{
			switch(m_battleType)
			{
				case MultiWaveBattleType.TakeWorstWave:
					return 1;
				case MultiWaveBattleType.TakeAverageWave:
					return 1;
				case MultiWaveBattleType.TakeAllWaves:
					return m_iterationCount;
				default:
					break;
			}

			return -1;
		}

		private int GetBattleIterationCount()
		{
			switch (m_battleType)
			{
				case MultiWaveBattleType.TakeWorstWave:
					return m_iterationCount;
				case MultiWaveBattleType.TakeAverageWave:
					return m_iterationCount;
				case MultiWaveBattleType.TakeAllWaves:
					return 1;
				default:
					break;
			}

			return -1;
		}

		private short[] GetPlayerLosses(Statistics.Statistics statistics)
		{
			switch(m_battleType)
			{
				case MultiWaveBattleType.TakeWorstWave:
					return statistics.MaxAttackerLosses;
				case MultiWaveBattleType.TakeAverageWave:
					short[] result = new short[statistics.AvgAttackerLosses.Length];
					for(int i = 0; i < statistics.AvgAttackerLosses.Length; i++)
					{
						result[i] = (short) Math.Round(statistics.AvgAttackerLosses[i]);
					}
					return result;
				case MultiWaveBattleType.TakeAllWaves:
					return statistics.MaxAttackerLosses;
				default:
					break;
			}

			return null;
		}

		private short[] GetEnemyLosses(Statistics.Statistics statistics)
		{
			switch (m_battleType)
			{
				case MultiWaveBattleType.TakeWorstWave:
					return statistics.MinDefenderLosses;
				case MultiWaveBattleType.TakeAverageWave:
					short[] result = new short[statistics.AvgDefenderLosses.Length];
					for (int i = 0; i < statistics.AvgDefenderLosses.Length; i++)
					{
						result[i] = (short)Math.Round(statistics.AvgDefenderLosses[i]);
					}
					return result;
				case MultiWaveBattleType.TakeAllWaves:
					return statistics.MinDefenderLosses;
				default:
					break;
			}

			return null;
		}
		#endregion
	}
}
