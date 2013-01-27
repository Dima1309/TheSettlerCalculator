using System.Collections.Generic;

namespace TheSettlersCalculator.Types
{
	public class LossesPrice
	{
		#region Fields
		private readonly List<LossesProduct> m_products;
		private double m_coinsLosses;
		#endregion

		#region Constructor
		internal LossesPrice(List<LossesProduct> products)
		{
			m_products = products;
			m_coinsLosses = 0;
			foreach(LossesProduct lossesProduct in products)
			{
				m_coinsLosses += lossesProduct.Product.Cost * lossesProduct.Count / 1000;
			}
		}
		#endregion

		#region Properties
		public double CoinsLosses
		{
			get { return m_coinsLosses; }
			set { m_coinsLosses = value; }
		}

		public List<LossesProduct> Products
		{
			get { return m_products; }
		}
		#endregion
	}
}
