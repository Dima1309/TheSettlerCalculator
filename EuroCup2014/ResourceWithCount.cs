using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014
{
	public class ResourceWithCount
	{
		#region Fields
		private readonly Resource m_resource;
		private int m_count;
		#endregion

		#region Constructor
		public ResourceWithCount(string resourceId, int count)
		{
			m_resource = Resources.ResourceList[resourceId];
			m_count = count;
		}

		internal ResourceWithCount(Resource resource, int count)
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

		public int Count
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
