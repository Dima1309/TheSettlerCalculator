using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014.Calculator
{
	public class Result
	{
		#region Fields
		private double m_time;
		private List<BuffWithCount> m_producedBuffs = new List<BuffWithCount>();
		private List<CampDisarmBuffs> m_solution = new List<CampDisarmBuffs>();
		#endregion

		#region Constructor
		internal Result(double time)
		{
			m_time = time;
		}
		#endregion

		#region Properties
		public double Time
		{
			get { return m_time;  }
		}

		public List<BuffWithCount> ProducedBuffs
		{
			get { return m_producedBuffs;  }
		}

		public List<CampDisarmBuffs> Solution
		{
			get { return m_solution; }
		}
		#endregion
	}
}
