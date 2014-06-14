using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Expressions
{
	internal class TimeExpression
	{
		#region Fields
		private List<KeyValuePair<double, ResourceCountExpression>> m_expressions = new List<KeyValuePair<double, ResourceCountExpression>>();
		#endregion

		#region Methods
		internal void SetTime(double time)
		{
			foreach (KeyValuePair<double, ResourceCountExpression> pair in m_expressions)
			{
				ResourceInStorageExpression exp = pair.Value as ResourceInStorageExpression;
				if (exp != null)
				{
					exp.Time = time;
				}
			}
		}

		public void Add(double incommingResourceRate, ResourceCountExpression expression)
		{
			m_expressions.Add(new KeyValuePair<double, ResourceCountExpression>(incommingResourceRate, expression));
		}

		public double Calculate(int[] x)
		{
			double result = 0;

			foreach(KeyValuePair<double, ResourceCountExpression> pair in m_expressions)
			{
				double value = pair.Value.Calculate(x) / pair.Key;

				if (value > result)
				{
					result = value;
				}
			}

			return result; ;
		}
		#endregion
	}
}
