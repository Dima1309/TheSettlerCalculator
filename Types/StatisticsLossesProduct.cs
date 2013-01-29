using TheSettlersCalculator.Price;

namespace TheSettlersCalculator.Types
{

	public class StatisticsLossesProduct
	{
		#region Fields
		private readonly Product m_product;
		private double m_minCount;
		private double m_avgCount;
		private double m_maxCount;
		#endregion

		#region Constructor
		internal StatisticsLossesProduct(Product product)
		{
			m_product = product;
		}

		internal StatisticsLossesProduct(Product product, double minCount, double avgCount, double maxCount)
		{
			m_product = product;
			m_minCount = minCount;
			m_avgCount = avgCount;
			m_maxCount = maxCount;
		}
		#endregion

		#region Properties
		public Product Product
		{
			get { return m_product; }
		}

		public double MinCount
		{
			get { return m_minCount; }
			set { m_minCount = value; }
		}

		public double AvgCount
		{
			get { return m_avgCount; }
			set { m_avgCount = value; }
		}

		public double MaxCount
		{
			get { return m_maxCount; }
			set { m_maxCount = value; }
		}
		#endregion
	}
}
