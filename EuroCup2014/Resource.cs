using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014 
{
	public class Resource : ObjectWithId
	{
		#region Constants
		private const string RESOURCE = "resource";
		private const string COLLECTIBLE_RATE = "collectible_rate";
		private const string SHORT_SEARCH_RATE = "short_treasure_search_rate";
		private const string MEDIUM_SEARCH_RATE = "medium_treasure_search_rate";
		private const string LONG_SEARCH_RATE = "long_treasure_search_rate";
		private const string VERY_LONG_SEARCH_RATE = "very_long_treasure_search_rate";
		#endregion

		#region Fields
		private double m_collectiableRate = 0;
		private double m_shortSearchRate = 0;
		private double m_mediumSearchRate = 0;
		private double m_longSearchRate = 0;
		private double m_veryLongSearchRate = 0;
		#endregion

		#region Properties
		public bool IsCollectiable
		{
			get { return m_collectiableRate > 0; }
		}

		public double CollectiableRate
		{
			get { return m_collectiableRate; }
		}

		public double ShortSearchRate
		{
			get { return m_shortSearchRate; }
		}

		public double MediumSearchRate
		{
			get { return m_mediumSearchRate; }
		}

		public double LongSearchRate
		{
			get { return m_longSearchRate; }
		}

		public double VeryLongSearchRate
		{
			get { return m_veryLongSearchRate; }
		}
		#endregion

		#region Methods
		internal override string GetNodeName()
		{
			return RESOURCE;
		}

		internal override void ProcessChilds(XmlReader reader)
		{
			if (reader.Name.Equals(COLLECTIBLE_RATE, StringComparison.OrdinalIgnoreCase))
			{
				m_collectiableRate = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
			} else if (reader.Name.Equals(SHORT_SEARCH_RATE, StringComparison.OrdinalIgnoreCase))
			{
				m_shortSearchRate = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
			} else if (reader.Name.Equals(MEDIUM_SEARCH_RATE, StringComparison.OrdinalIgnoreCase))
			{
				m_mediumSearchRate = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
			} else if (reader.Name.Equals(LONG_SEARCH_RATE, StringComparison.OrdinalIgnoreCase))
			{
				m_longSearchRate = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
			} else if (reader.Name.Equals(VERY_LONG_SEARCH_RATE, StringComparison.OrdinalIgnoreCase))
			{
				m_veryLongSearchRate = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
			}
		}
		#endregion 
	}
}
