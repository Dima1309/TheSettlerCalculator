using System;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.Xml;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	public class Losses : IXMLSerializable
	{
		#region Constants
		private static string UNIT = "unit";
		private static string MIN = "min";
		private static string MAX = "max";
		private static string AVG = "avg";
		#endregion

		#region Fields
		private Unit m_unit;
		private int m_minCount;
		private int m_maxCount;
		private double m_avgCount;
		#endregion

		#region Constructor
		internal Losses(Unit unit, int min, double avg, int max)
		{
			m_unit = unit;
			m_minCount = min;
			m_maxCount = max;
			m_avgCount = avg;
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return Unit.Name; }
		}

		public BitmapSource Icon
		{
			get { return Unit.Icon; }
		}

		public int MinCount
		{
			get { return m_minCount; }
		}

		public int MaxCount
		{
			get { return m_maxCount; }
		}

		public double AvgCount
		{
			get { return m_avgCount; }
		}

		public Unit Unit
		{
			get { return m_unit; }
		}
		#endregion

		public void Load(XmlReader reader)
		{
			int level = reader.Depth;
			while (reader.Read())
			{
				if(level > reader.Depth)
				{
					break;
				}

				if (reader.Name.Equals(UNIT, StringComparison.OrdinalIgnoreCase))
				{
					m_unit = EnemyUnits.Units[reader.ReadElementString().Trim()];
				}
				if (reader.Name.Equals(MIN, StringComparison.OrdinalIgnoreCase))
				{
					m_minCount = int.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
				}
				if (reader.Name.Equals(MAX, StringComparison.OrdinalIgnoreCase))
				{
					m_maxCount = int.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
				}
				if (reader.Name.Equals(AVG, StringComparison.OrdinalIgnoreCase))
				{
					m_avgCount = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
				}
			}
		}

		public void Save(XmlWriter writer)
		{
			writer.WriteStartElement(UNIT);
			writer.WriteValue(m_unit.Id);
			writer.WriteEndElement();

			writer.WriteStartElement(MIN);
			writer.WriteValue(m_minCount.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();

			writer.WriteStartElement(MAX);
			writer.WriteValue(m_maxCount.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();

			writer.WriteStartElement(AVG);
			writer.WriteValue(m_avgCount.ToString(CultureInfo.InvariantCulture));
			writer.WriteEndElement();
		}
	}
}
