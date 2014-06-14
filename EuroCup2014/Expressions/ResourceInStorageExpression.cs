using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Expressions
{
	internal class ResourceInStorageExpression : ResourceCountExpression
	{
		#region Fields
		private double m_time = 0;
		private double m_incommingRate = 0;
		#endregion

		#region Properties
		public double Time
		{
			get { return m_time; }
			set { m_time = value; }
		}

		public double IncommingRate
		{
			get { return m_incommingRate; }
			set { m_incommingRate = value; }
		}
		#endregion

		#region Methods
		public override double Calculate(int[] x)
		{
			double result = m_existingResource + m_time * m_incommingRate;

			foreach (KeyValuePair<int, BuffCountExpression> pair in m_buffs)
			{
				result -= pair.Value.Calculate(x) * pair.Key;
			}

			return result;
		}
		#endregion
	}
}
