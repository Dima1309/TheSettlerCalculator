using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014
{
	public class ResourceWithDouble
	{
		#region Fields
		private readonly Resource m_resource;
		private double m_count;
		#endregion

		#region Constructor
		public ResourceWithDouble(string resourceId, double count)
		{
			m_resource = Resources.ResourceList[resourceId];
			m_count = count;
		}

		internal ResourceWithDouble(Resource resource, double count)
		{
			m_resource = resource;
			m_count = count;
		}
		#endregion

		#region Properties
		public Resource Resource
		{
			get
			{
				return m_resource;
			}
		}

		public double Count
		{
			get
			{
				return m_count;
			}

			set
			{
				m_count = value;
			}
		}
		#endregion
	}
}
