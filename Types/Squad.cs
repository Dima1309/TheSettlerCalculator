using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	public class Camp
	{
		#region Fields
		private readonly SortedDictionary<short, short> m_counts = new SortedDictionary<short, short>();
		private string m_name;
		private CampType m_campType;
		private byte m_sectorId;
		private double m_left;
		private double m_top;
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public SortedDictionary<short, short> Counts
		{
			get { return m_counts; }
		}

		public CampType CampType
		{
			get { return m_campType; }
			set { m_campType = value; }
		}

		public byte SectorId
		{
			get { return m_sectorId; }
			set { m_sectorId = value; }
		}

		public double Left
		{
			get { return m_left; }
			set { m_left = value; }
		}

		public double Top
		{
			get { return m_top; }
			set { m_top = value; }
		}
		#endregion
	}
}
