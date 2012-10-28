using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public class Round : SimulationGroup
	{
		#region Fields
		private int m_index;
		private readonly List<Step> m_steps = new List<Step>();
		#endregion

		#region Properties
		public int Index
		{
			get { return m_index; }
			set { m_index = value; }
		}

		public List<Step> Steps
		{
			get { return m_steps; }
		}
		#endregion
	}
}
