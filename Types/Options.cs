namespace TheSettlersCalculator.Types
{
	public class Options
	{
		#region Fields
		private readonly static Options s_instance = new Options();
		private int m_rounds = 10000;
		private ServerType m_server;
		private int m_baracksLevel;
		private MultiWaveBattleType m_multiWaveBattleType = MultiWaveBattleType.TakeWorstWave;
		#endregion

		#region Constructor
		private Options() {}
		#endregion

		#region Properties
		public int Rounds
		{
			get { return m_rounds; }
			set { m_rounds = value; }
		}

		public ServerType Server
		{
			get { return m_server; }
			set { m_server = value; }
		}

		public int BaracksLevel
		{
			get { return m_baracksLevel; }
			set { m_baracksLevel = value; }
		}

		public MultiWaveBattleType MultiWaveBattleType
		{
			get { return m_multiWaveBattleType; }
			set { m_multiWaveBattleType = value; }
		}

		internal static Options Instance
		{
			get { return s_instance; }
		}
		#endregion
	}
}
