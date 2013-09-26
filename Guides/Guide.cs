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
		#region Constants
		private static string FILENAME = "filename";
		private static string TITLE = "title";
		private static string ATTACKS = "attacks";
		private static string IMAGES = "images";
		private static string IMAGE = "image";
		private static string LOSSES = "losses";
		private static string ARMY = "army";
		#endregion

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
			writer.WriteStartElement(TITLE);
			writer.WriteValue(m_title);
			writer.WriteEndElement();

			writer.WriteStartElement(FILENAME);
			writer.WriteValue(m_filename);
			writer.WriteEndElement();

			writer.WriteStartElement(ATTACKS);
			foreach(Attack attack in m_attacks)
			{
				attack.Save(writer, this);
			}
			writer.WriteEndElement();

			writer.WriteStartElement(IMAGES);
			foreach (BitmapSource image in m_images)
			{

			}
			writer.WriteEndElement();

			writer.WriteStartElement(LOSSES);
			writer.WriteEndElement();

			writer.WriteStartElement(ARMY);
			foreach(UnitSquad squad in m_army)
			{
				
			}
			writer.WriteEndElement();
		}

		public void CalculateAll()
		{}
		#endregion
	}
}
