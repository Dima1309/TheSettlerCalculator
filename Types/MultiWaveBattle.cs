﻿using System;
using System.Collections.Generic;
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
			private readonly bool m_general;
			private readonly double m_towerBonus;
			#endregion

			#region Constructor
			internal BattleWave(IList<UnitSquad> squads, bool general, double towerBonus)
			{
				m_squads = squads;
				m_general = general;
				m_towerBonus = towerBonus;
			}
			#endregion

			#region Properties
			public IEnumerable<UnitSquad> Squads
			{
				get { return m_squads; }
			}

			public bool General
			{
				get { return m_general; }
			}

			public double TowerBonus
			{
				get { return m_towerBonus; }
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
		#endregion

		#region Methods
		internal void AddAttackerWave(IList<UnitSquad> units, bool general, double towerBonus)
		{
			m_playerWaves.Add(new BattleWave(units, general, towerBonus));
		}

		internal void AddEnemyWave(IList<UnitSquad> units, bool general, double towerBonus)
		{
			m_enemyWaves.Add(new BattleWave(units, general, towerBonus));
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

				while(playerIndex > m_playerWaves.Count && enemyIndex > m_enemyWaves.Count)
				{
					if(playerSquads == null)
					{
						playerSquads = new List<UnitSquad>(m_playerWaves[playerIndex].Squads);
						playerGeneral = m_playerWaves[playerIndex].General;
					}

					if(enemySquads == null)
					{
						enemySquads = new List<UnitSquad>(m_enemyWaves[enemyIndex].Squads);
						enemyGeneral = m_enemyWaves[enemyIndex].General;
					}

					Battle battle = new Battle(playerSquads, playerGeneral, enemySquads, enemyGeneral);
					battle.PlayerTowerBonus = m_playerWaves[playerIndex].TowerBonus;
					battle.EnemyTowerBonus = m_enemyWaves[enemyIndex].TowerBonus;
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
