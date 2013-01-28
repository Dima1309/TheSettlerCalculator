using System.Collections.Generic;
using TheSettlersCalculator.Price;

namespace TheSettlersCalculator.Types
{
	public class LossesPrice
	{
		#region Fields
		private readonly List<LossesProduct> m_products;
		private LossesProduct m_total;
		#endregion

		#region Constructor
		internal LossesPrice(List<LossesProduct> products)
		{
			m_products = products;
			double coinsLosses = 0;
			foreach(LossesProduct lossesProduct in products)
			{
				coinsLosses += lossesProduct.Product.Cost * lossesProduct.Count / 1000;
			}

			m_total = new LossesProduct(ProductEnum.RESOURCE_COINS, coinsLosses);
		}
		#endregion

		#region Properties
		public LossesProduct Total
		{
			get { return m_total; }
			set { m_total = value; }
		}

		public List<LossesProduct> Products
		{
			get { return m_products; }
		}
		#endregion
	}
}
