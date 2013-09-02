using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Xml;
using TheSettlersCalculator.Quests;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Guides
{
	public class Guide : IXMLSerializable
	{
		#region Fields
		private string m_title;
		private string m_filename;
		private Quest m_quest;

		private readonly ObservableCollection<Attack> m_attacks;
		private readonly ObservableCollection<BitmapSource> m_images;
		
		private BattleLosses m_losses;
		private ObservableCollection<UnitSquad> m_army;
		#endregion

		#region Properties
		public string Title
		{
			get { return m_title; }
			set { m_title = value; }
		}

		public Quest Quest
		{
			get { return m_quest; }
			set { m_quest = value; }
		}

		public string Filename
		{
			get { return m_filename; }
			set { m_filename = value; }
		}

		public ObservableCollection<Attack> Attacks
		{
			get { return m_attacks; }
		}

		public BattleLosses Losses
		{
			get { return m_losses; }
		}

		public ObservableCollection<BitmapSource> Images
		{
			get { return m_images; }
		}

		public ObservableCollection<UnitSquad> Army
		{
			get { return m_army; }
		}
		#endregion

		#region Methods
		public void Load(XmlReader reader)
		{
			throw new NotImplementedException();
		}

		public void Save(XmlWriter writer)
		{
			throw new NotImplementedException();
		}

		public void CalculateAll()
		{}
		#endregion
	}
}
