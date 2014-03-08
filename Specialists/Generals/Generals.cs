using System.Collections.Generic;
using System.IO;
using System.Xml;
using TheSettlersCalculator.Properties;

namespace TheSettlersCalculator.Specialists.Generals
{
	public class Generals
	{
		internal const string DEFAULT_GENERAL = "TavernGeneral";
		private const string FILENAME = "generals.xml";
		private const string GENERALS_TAG = "generals";

		#region Fields
		private static Dictionary<string, General> s_generals;
		#endregion

		#region Properties
		public static Dictionary<string, General> GeneralsDictionary
		{
			get
			{
				if (s_generals == null)
				{
					Load();
				}
				return s_generals;
			}
		}

		public static IEnumerable<General> GeneralList
		{
			get
			{
				if (s_generals == null)
				{
					Load();
				}
				return s_generals.Values;
			}
		}
		#endregion

		#region Methods
		internal static void Load()
		{
			if (File.Exists(FILENAME))
			{
				Dictionary<string, General> result = new Dictionary<string, General>(10);
				XmlReader reader = null;

				try
				{
					reader = XmlReader.Create(FILENAME);

					while (!reader.EOF)
					{
						if (reader.IsStartElement(General.ROOT))
						{
							General unit = new General();
							unit.Load(reader);
							result.Add(unit.Id, unit);
							continue;
						}

						if (!reader.Read())
						{
							break;
						}
					}
				}
				finally
				{
					if (reader != null)
					{
						reader.Close();
					}
				}

				s_generals = result;
			}
		}

		internal static void Save()
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			XmlWriter writer = null;

			try
			{
				writer = XmlWriter.Create(FILENAME, settings);

				writer.WriteStartElement(GENERALS_TAG);
				foreach (General general in GeneralsDictionary.Values)
				{
					general.Save(writer);
				}
				writer.WriteEndElement();
			}
			finally
			{
				if (writer != null)
				{
					writer.Close();
				}
			}
		}
		#endregion
	}
}
