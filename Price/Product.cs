using System.Windows.Media.Imaging;
using TheSettlersCalculator.Helper;

namespace TheSettlersCalculator.Price
{
	public class Product
	{
		#region Fields
		private readonly ProductEnum m_index;
		private string m_name;
		private ProductType m_productType;
		private double m_cost;
		private BitmapSource m_icon;
		private string m_iconSource;
		#endregion

		#region Constructor
		internal Product(ProductEnum index, string name, ProductType productType, double cost, string iconSource)
		{
			m_index = index;
			m_name = name;
			m_productType = productType;
			m_cost = cost;
			m_iconSource = iconSource;
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public ProductType ProductType
		{
			get { return m_productType; }
			set { m_productType = value; }
		}

		public double Cost
		{
			get { return m_cost; }
			set { m_cost = value; }
		}

		public BitmapSource Icon
		{
			get
			{
				if (m_icon == null && m_iconSource != null)
				{
					m_icon = ImageHelper.LoadPng("TheSettlersCalculator.Price.Icons." + m_iconSource +".png");
				}

				return m_icon;
			}
		}

		internal string IconSource
		{
			get { return m_iconSource; }
			set { m_iconSource = value; }
		}

		public ProductEnum Index
		{
			get { return m_index; }
		}
		#endregion
	}
}
