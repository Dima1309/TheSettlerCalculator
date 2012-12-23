using System;
using TheSettlersCalculator.Statistics;

namespace TheSettlersCalculator.Types
{
	internal class MultiWaveBatleWaveCompleteArgs : EventArgs
	{
		private readonly WaveKey m_key;
		private readonly Statistics.Statistics m_statistics;

		public MultiWaveBatleWaveCompleteArgs(WaveKey key, Statistics.Statistics statistics)
		{
			m_key = key;
			m_statistics = statistics;
		}

		public WaveKey Key
		{
			get { return m_key; }
		}

		public Statistics.Statistics Statistics
		{
			get { return m_statistics; }
		}
	}

	internal delegate void MultiWaveBattleWaveCompleteHandler(object sender, MultiWaveBatleWaveCompleteArgs args);
}
