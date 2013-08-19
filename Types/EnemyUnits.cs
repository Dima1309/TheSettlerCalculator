using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TheSettlersCalculator.Types
{
	internal static class EnemyUnits
	{
		private const string FILENAME = "enemies.xml";
		private const string UNITS_TAG = "units";

		#region Fields
		private static Dictionary<string, Unit> s_units;

		#endregion

		public static Dictionary<string, Unit> Units
		{
			get
			{
				if (s_units == null)
				{
					Load();
				}

				return s_units;
			}
		}

		internal static void Load()
		{
			if (File.Exists(FILENAME))
			{
				Dictionary<string, Unit> result = new Dictionary<string, Unit>(100);
				XmlReader reader = null;

				try
				{
					reader = XmlReader.Create(FILENAME);

					while (!reader.EOF)
					{
						if (reader.IsStartElement(Unit.UNIT))
						{
							Unit unit = new Unit();
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

				s_units = result;
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

				writer.WriteStartElement(UNITS_TAG);
				foreach (Unit unit in Units.Values)
				{
					unit.Save(writer);
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
	}
}
