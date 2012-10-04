using System.Windows.Media.Imaging;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	public class Losses
	{
		#region Fields
		private readonly Unit m_unit;
		private readonly int m_minCount;
		private readonly int m_maxCount;
		private readonly double m_avgCount;
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

		internal Unit Unit
		{
			get { return m_unit; }
		}
		#endregion
	}
}
