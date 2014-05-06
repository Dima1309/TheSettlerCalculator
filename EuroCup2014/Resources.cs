using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	internal static class Resources
	{
		#region Constants
		private const string FILENAME = "EuroCup2014\\resources.xml";
		private const string RESOURCE = "resource";
		#endregion

		#region Fields
		private static Dictionary<string, Resource> m_resources;
		#endregion

		#region Properties
		internal static Dictionary<string, Resource> ResourceList
		{
			get
			{
				if (m_resources == null)
				{
					Load();
				}

				return m_resources;
			}
		}
		#endregion

		#region Methods
		private static void Load()
		{
			m_resources = new Dictionary<string, Resource>();
			XmlReader reader = XmlReader.Create(FILENAME);			
			while (reader.Read())
			{
				if (!reader.IsStartElement())
				{
					continue;
				}

				try
				{
					if (string.Equals(reader.Name, RESOURCE, StringComparison.OrdinalIgnoreCase))
					{
						Resource res = new Resource();
						res.Load(reader);
						if (!string.IsNullOrEmpty(res.Id))
							m_resources[res.Id] = res;
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
