using System;
using System.Collections.Generic;
using System.Threading;

namespace TheSettlersCalculator.Types
{
	internal class Calculator2 : Calculator
	{
		#region Fields
		private Thread[] m_threads;
		private ManualResetEvent[] m_events;
		private Queue<List<BattleStep>> m_battles;
		#endregion

		internal Calculator2(int iterationCount) : base(iterationCount)
		{
		}

		#region Methods
		public override void Calculate(Battle battle)
		{
			BattleWaves battleWaves = SplitByWaves(battle);

			int threadCounts = Environment.ProcessorCount;
			m_battles = new Queue<List<BattleStep>>(IterationCount / threadCounts);
			m_threads = new Thread[threadCounts];
			m_events = new ManualResetEvent[threadCounts];
			for(int i = 0; i < m_events.Length; i++)
			{
				m_events[i] = new ManualResetEvent(false);
				m_threads[i] = new Thread(ThreadMethod);
				m_threads[i].Start(new ThreadParameter(
				                   	i,
				                   	IterationCount / threadCounts,
				                   	battle,
									battleWaves));
			}			

			while (true)
			{
				while(true)
				{
					List<BattleStep> result;
					lock(m_battles)
					{
						if(m_battles.Count > 0)
						{
							result = m_battles.Dequeue();
						}
						else
						{
							break;
						}
					}

					BattleComplete(battle, result);
				}

				bool threadStopped = WaitHandle.WaitAll(m_events, 50);
				if(threadStopped)
				{
					if(m_battles.Count == 0)
					{
						return;
					}
				}
			}
		}

		private void ThreadMethod(object parameter)
		{
			ThreadParameter threadParameter = (ThreadParameter) parameter;
			Random random = new Random();

			for(int i = 0; i < threadParameter.IterationCount; i++)
			{
				List<BattleStep> result = BattleHelper.CalculateBattle2(threadParameter.Battle, threadParameter.BattleWaves, random, null, null);

				lock(m_battles)
				{
					m_battles.Enqueue(result);
				}
			}			

			m_events[threadParameter.Index].Set();
		}
		#endregion

		#region Datatypes
		private struct ThreadParameter
		{
			#region Fields
			private readonly Battle m_battle;
			private readonly BattleWaves m_battleWaves;

			private readonly int m_index;
			private readonly int m_iterationCount;
			#endregion

			#region Constructor
			public ThreadParameter(
				int index, 
				int iterationCount, 
				Battle battle,
				BattleWaves battleWaves)
			{
				m_index = index;
				m_battleWaves = battleWaves;
				m_battle = battle;
				m_iterationCount = iterationCount;
			}
			#endregion

			internal int Index
			{
				get { return m_index; }
			}

			internal int IterationCount
			{
				get { return m_iterationCount; }
			}

			public Battle Battle
			{
				get { return m_battle; }
			}

			public BattleWaves BattleWaves
			{
				get { return m_battleWaves; }
			}
		}
		#endregion
	}
}
