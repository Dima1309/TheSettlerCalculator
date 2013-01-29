using System.Collections.Generic;
using TheSettlersCalculator.Price;

namespace TheSettlersCalculator.Types
{
	public class StatisticsLossesPrice
	{
		#region Fields
		private readonly List<StatisticsLossesProduct> m_products = new List<StatisticsLossesProduct>();
		private readonly StatisticsLossesProduct m_total;
		#endregion

		#region Constructor
		internal StatisticsLossesPrice(LossesPrice min, LossesPrice avg, LossesPrice max)
		{
			m_total = new StatisticsLossesProduct(min.Total.Product, min.Total.Count, avg.Total.Count, max.Total.Count);
			SortedDictionary<ProductEnum, StatisticsLossesProduct> byProducts = new SortedDictionary<ProductEnum, StatisticsLossesProduct>();

			foreach(LossesProduct lossesProduct in min.Products)
			{
				StatisticsLossesProduct product;
				if (byProducts.TryGetValue(lossesProduct.Product.Index, out product))
				{
					product.MinCount = lossesProduct.Count;
				}
				else
				{
					byProducts.Add(
						lossesProduct.Product.Index,
						new StatisticsLossesProduct(lossesProduct.Product, lossesProduct.Count, 0, 0));
				}
			}

			foreach (LossesProduct lossesProduct in avg.Products)
			{
				StatisticsLossesProduct product;
				if (byProducts.TryGetValue(lossesProduct.Product.Index, out product))
				{
					product.AvgCount = lossesProduct.Count;
				}
				else
				{
					byProducts.Add(
						lossesProduct.Product.Index,
						new StatisticsLossesProduct(lossesProduct.Product, lossesProduct.Count, 0, 0));
				}
			}

			foreach (LossesProduct lossesProduct in max.Products)
			{
				StatisticsLossesProduct product;
				if (byProducts.TryGetValue(lossesProduct.Product.Index, out product))
				{
					product.MaxCount = lossesProduct.Count;
				}
				else
				{
					byProducts.Add(
						lossesProduct.Product.Index,
						new StatisticsLossesProduct(lossesProduct.Product, 0, 0, lossesProduct.Count));
				}
			}

			foreach(KeyValuePair<ProductEnum, StatisticsLossesProduct> product in byProducts)
			{
				m_products.Add(product.Value);
			}
		}
		#endregion

		#region Properties
		public List<StatisticsLossesProduct> Products
		{
			get { return m_products; }
		}

		public StatisticsLossesProduct Total
		{
			get { return m_total; }
		}
		#endregion
	}
}
