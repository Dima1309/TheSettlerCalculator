using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public static class Buffs
	{
		#region Constants
		private const string FILENAME = "EuroCup2014\\buffs.xml";
		private const string BUFF = "buff";
		#endregion

		#region Fields
		private static Dictionary<string, Buff> m_buffs;
		#endregion

		#region Properties
		internal static Dictionary<string, Buff> BuffList
		{
			get
			{
				if (m_buffs == null)
				{
					Load();
				}

				return m_buffs;
			}
		}
		#endregion

		#region Methods
		private static void Load()
		{
			m_buffs = new Dictionary<string, Buff>();
			XmlReader reader = XmlReader.Create(FILENAME);
			while (reader.Read())
			{
				if (!reader.IsStartElement())
				{
					continue;
				}

				try
				{
					if (string.Equals(reader.Name, BUFF, StringComparison.OrdinalIgnoreCase))
					{
						Buff res = new Buff();
						res.Load(reader);
						if (!string.IsNullOrEmpty(res.Id))
							m_buffs[res.Id] = res;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}
		#endregion
	}
}
