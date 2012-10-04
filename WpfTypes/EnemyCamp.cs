using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	public class EnemyCamp
	{
		#region Fields
		private readonly string m_name;
		private readonly CampType m_campType;
		private readonly ObservableCollection<UnitSquad> m_squads = new ObservableCollection<UnitSquad>();
		private readonly double m_left;
		private readonly double m_top;
		#endregion

		#region Constructor
		internal EnemyCamp(Quest quest, Camp camp)
		{
			m_name = camp.Name;
			m_campType = camp.CampType;

			foreach(KeyValuePair<short, short> pair in camp.Counts)
			{
				if (pair.Value > 0)
				{
					m_squads.Add(new UnitSquad(quest.Units[pair.Key], pair.Value));
				}
			}

			m_left = camp.Left;
			m_top = camp.Top;
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
		}

		public CampType CampType
		{
			get { return m_campType; }
		}

		public ObservableCollection<UnitSquad> Squads
		{
			get { return m_squads; }
		}

		public double Left
		{
			get { return m_left; }
		}

		public double Top
		{
			get { return m_top; }
		}
		#endregion
	}
}
