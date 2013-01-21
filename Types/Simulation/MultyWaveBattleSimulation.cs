using System;
using System.Collections.Generic;

namespace TheSettlersCalculator.Types.Simulation
{
	public class MultyWaveBattleSimulation
	{
		#region Fields
		private readonly List<BattleSimulation> m_simulations = new List<BattleSimulation>();
		private bool m_simulationComplete;
		#endregion

		#region Constructor
		internal MultyWaveBattleSimulation()
		{}
		#endregion

		#region Properties
		public List<BattleSimulation> Simulations
		{
			get { return m_simulations; }
		}
		#endregion

		#region Methods
		internal void MultiWaveBattleCompleteHandler(object sender, EventArgs args)
		{
			m_simulationComplete = true;
			MultiWaveBattle battle = (sender as MultiWaveBattle);
			if (battle != null)
			{
				battle.OnBattleComplete -= MultiWaveBattleCompleteHandler;
				battle.OnWaveComplete -= MultiWaveBattleWaveCompleteHandler;
			}
		}

		internal void MultiWaveBattleWaveCompleteHandler(object sender, MultiWaveBatleWaveCompleteArgs args)
		{
			if (m_simulationComplete)
			{
				return;
			}

			m_simulations.Add(new BattleSimulation(args.Statistics.Battle));
		}
		#endregion
	}
}
