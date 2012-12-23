using System;
using System.Collections.Generic;
using TheSettlersCalculator.Statistics;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Types
{
	internal class MultiWaveBattle
	{
		#region Fields
		private readonly List<KeyValuePair<IList<UnitSquad>, bool>> m_playerWaves = new List<KeyValuePair<IList<UnitSquad>, bool>>();
		private readonly List<KeyValuePair<IList<UnitSquad>, bool>> m_enemyWaves = new List<KeyValuePair<IList<UnitSquad>, bool>>();
		private MultiWaveBattleType m_battleType = MultiWaveBattleType.TakeWorstWave;
		private readonly int m_iterationCount;
		private List<Unit> m_units;
		private List<Unit> m_enemyUnits;

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

		public List<KeyValuePair<IList<UnitSquad>, bool>> PlayerWaves
		{
			get { return m_playerWaves; }
		}

		public List<KeyValuePair<IList<UnitSquad>, bool>> EnemyWaves
		{
			get { return m_enemyWaves; }
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
		#endregion

		#region Methods
		internal void AddAttackerWave(IList<UnitSquad> units, bool general)
		{
			PlayerWaves.Add(new KeyValuePair<IList<UnitSquad>, bool>(new List<UnitSquad>(units), general));
		}

		internal void AddEnemyWave(IList<UnitSquad> units, bool general)
		{
			EnemyWaves.Add(new KeyValuePair<IList<UnitSquad>, bool>(new List<UnitSquad>(units), general));
		}

		internal void Calculate(ICalculator calculator)
		{
			int iterationCount = GetRepeatCount();

			for(int iter = 0 ; iter < iterationCount; iter++)
			{
				int playerIndex = 0;
				int enemyIndex = 0;
				IList<UnitSquad> playerSquads = null;
				bool playerGeneral = false;
				IList<UnitSquad> enemySquads = null;
				bool enemyGeneral = false;

				while(playerIndex > PlayerWaves.Count && enemyIndex > EnemyWaves.Count)
				{
					if(playerSquads == null)
					{
						playerSquads = new List<UnitSquad>(PlayerWaves[playerIndex].Key);
						playerGeneral = PlayerWaves[playerIndex].Value;
					}

					if(enemySquads == null)
					{
						enemySquads = new List<UnitSquad>(EnemyWaves[enemyIndex].Key);
						enemyGeneral = EnemyWaves[enemyIndex].Value;
					}

					Battle battle = new Battle(playerSquads, playerGeneral, enemySquads, enemyGeneral);
					calculator.IterationCount = GetBattleIterationCount();
					Statistics.Statistics statistics = new Statistics.Statistics(battle);
					calculator.OnBattleComplete += statistics.BattleComplete;
					calculator.Calculate(battle);
					calculator.OnBattleComplete -= statistics.BattleComplete;
					if (m_waveCompleteHandler!=null)
					{
						m_waveCompleteHandler(this, new MultiWaveBatleWaveCompleteArgs(new WaveKey(playerIndex, enemyIndex), statistics));
					}

					bool empty = true;
					short[] attackerLosses = GetPlayerLosses(statistics);
					for(int i = 0; i < attackerLosses.Length; i++)
					{
						playerSquads[i].Count -= attackerLosses[i];
						if(playerSquads[i].Count > 0)
						{
							empty = false;
						}
					}

					if(empty)
					{
						playerSquads = null;
						playerIndex++;
					}

					short[] defenderLosses = GetEnemyLosses(statistics);
					for(int i = 0; i < defenderLosses.Length; i++)
					{
						enemySquads[i].Count -= defenderLosses[i];
						if(enemySquads[i].Count > 0)
						{
							empty = false;
						}
					}

					if(empty)
					{
						enemySquads = null;
						enemyIndex++;
					}
				}

				//iteration complete
				if (m_battleCompleteHandler!= null)
				{
					m_battleCompleteHandler(this, new EventArgs());
				}
			}
		}

		private static List<Unit> GetUnits(IEnumerable<KeyValuePair<IList<UnitSquad>, bool>> waves)
		{
			List<Unit> result = new List<Unit>();
			foreach (KeyValuePair<IList<UnitSquad>, bool> keyValuePair in waves)
			{
				foreach (UnitSquad squad in keyValuePair.Key)
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
