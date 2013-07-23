using System;
using System.Xml;

namespace TheSettlersCalculator.Types
{
	public class Options : IXMLSerializable
	{
		private const string OPTIONS = "options";
		private const string ROUNDS = "rounds";
		private const string SERVER = "server";
		private const string BARACK = "barackLevel";
		private const string MULTI_WAVE_BATTLE_TYPE = "multiWaveBattleType";

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

		#region Methods
		public void Load(XmlReader reader)
		{
			int level = reader.Depth;
			while (reader.Read())
			{
				if (string.Equals(reader.Name, OPTIONS, StringComparison.OrdinalIgnoreCase) ||
					level > reader.Depth)
				{
					break;
				}

				if (!reader.IsStartElement())
				{
					continue;
				}

				try
				{
					if(string.Equals(reader.Name, ROUNDS, StringComparison.OrdinalIgnoreCase))
					{
						m_rounds = int.Parse(reader.Value);
					}
					else if(string.Equals(reader.Name, SERVER, StringComparison.OrdinalIgnoreCase))
					{
						m_server = (ServerType)Enum.Parse(typeof(ServerType), reader.Value, true);
					}
					else if(string.Equals(reader.Name, BARACK, StringComparison.OrdinalIgnoreCase))
					{
						m_baracksLevel = int.Parse(reader.Value);
					}
					else if(string.Equals(reader.Name, MULTI_WAVE_BATTLE_TYPE, StringComparison.OrdinalIgnoreCase))
					{
						m_multiWaveBattleType = (MultiWaveBattleType) int.Parse(reader.Value);
					}
				}
				catch (Exception)
				{
				}

			}
		}

		public void Save(XmlWriter writer)
		{
			writer.WriteStartElement(OPTIONS);
			
			writer.WriteStartElement(ROUNDS);
			writer.WriteValue(m_rounds);
			writer.WriteEndElement();

			writer.WriteStartElement(SERVER);
			writer.WriteValue(m_server.ToString());
			writer.WriteEndElement();
			
			writer.WriteStartElement(BARACK);
			writer.WriteValue(m_baracksLevel);
			writer.WriteEndElement();
			
			writer.WriteStartElement(MULTI_WAVE_BATTLE_TYPE);
			writer.WriteValue((int)m_multiWaveBattleType);
			writer.WriteEndElement();

			writer.WriteEndElement();
		}
		#endregion
	}
}
