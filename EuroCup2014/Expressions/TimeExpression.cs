﻿using System;
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
		public void Add(double incommingResource, ResourceCountExpression expression)
		{
			m_expressions.Add(new KeyValuePair<double, ResourceCountExpression>(incommingResource, expression));
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
