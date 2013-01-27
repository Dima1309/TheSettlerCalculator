using TheSettlersCalculator.Price;

namespace TheSettlersCalculator.Types
{
	public class LossesProduct
	{
		#region Fields
		private readonly Product m_product;
		private double m_count;
		#endregion

		#region Constructor
		internal LossesProduct(Product product)
		{
			m_product = product;
		}

		internal LossesProduct(ProductEnum product, double count)
		{
			m_product = Price.Price.Products[product];
			m_count = count;
		}

		#endregion

		public Product Product
		{
			get { return m_product; }
		}

		public double Count
		{
			get { return m_count; }
			internal set { m_count = value; }
		}
	}
}
