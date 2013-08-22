using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
	public class EnemyCamp : Camp
	{
		#region Fields
		private readonly ObservableCollection<UnitSquad> m_squads = new ObservableCollection<UnitSquad>();
		#endregion

		#region Constructor
		internal EnemyCamp(Quest quest, Camp camp) : base(camp)
		{
			foreach(KeyValuePair<short, short> pair in camp.Counts)
			{
				if (pair.Value > 0)
				{
					m_squads.Add(new UnitSquad(quest.Units[pair.Key], pair.Value));
				}
			}
			m_squads.CollectionChanged += CollectionChanged;
		}
		#endregion

		#region Properties
		public ObservableCollection<UnitSquad> Squads
		{
			get { return m_squads; }
		}
		#endregion

		#region Methods
		void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("Squads");
		}

		#endregion
	}
}
