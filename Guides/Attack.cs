using System;
using System.Collections.ObjectModel;
using System.Xml;
using TheSettlersCalculator.Specialists.Generals;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Guides
{
	public class Attack
	{
		#region Constants
		private static string ATTACK = "attack";
		private static string NAME = "name";
		private static string GENERAL = "general";
		private static string TARGET = "target";
		private static string ATTACK_TYPE = "attackType";
		private static string UNITS = "army";
		private static string UNIT = "unit";
		private static string UNIT_NAME = "name";
		private static string LOSSES = "losses";
		private static string COMMENT = "comment";
		private static string IMAGE = "image";
		#endregion

		#region Fields
		private string m_name;
		private General m_general;
		private int m_targetIndex;
		private Camp m_target;
		private AttackType m_attackType;
		private ObservableCollection<UnitSquad> m_units;
		private readonly BattleLosses m_losses;
		private string m_comment;
		private int m_imageIndex;
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public Camp Target
		{
			get { return m_target; }
			set { m_target = value; }
		}

		public AttackType AttackType
		{
			get { return m_attackType; }
			set { m_attackType = value; }
		}

		public ObservableCollection<UnitSquad> Units
		{
			get { return m_units; }
		}

		public BattleLosses Losses
		{
			get { return m_losses; }
		}

		public string Comment
		{
			get { return m_comment; }
			set { m_comment = value; }
		}

		public int ImageIndex
		{
			get { return m_imageIndex; }
			set { m_imageIndex = value; }
		}

		public int TargetIndex
		{
			get { return m_targetIndex; }
			set { m_targetIndex = value; }
		}

		public General General
		{
			get { return m_general; }
			set { m_general = value; }
		}
		#endregion

		#region Methods
		public void Load(XmlReader reader, Guide guide)
		{
			throw new NotImplementedException();
		}

		public void Save(XmlWriter writer, Guide guide)
		{
			writer.WriteStartElement(ATTACK);

			writer.WriteStartElement(NAME);
			writer.WriteValue(m_name);
			writer.WriteEndElement();
		
			writer.WriteStartElement(GENERAL);
			writer.WriteValue(m_general.Id);
			writer.WriteEndElement();

			writer.WriteStartElement(TARGET);
			writer.WriteValue(m_targetIndex);
			writer.WriteEndElement();

			writer.WriteStartElement(ATTACK_TYPE);
			writer.WriteValue(m_attackType);
			writer.WriteEndElement();
		
			writer.WriteStartElement(UNITS);
			foreach(UnitSquad squad in m_units)
			{
				writer.WriteStartElement(UNIT);
				writer.WriteAttributeString(UNIT_NAME, squad.Unit.Id);
				writer.WriteValue(squad.Count);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();

			//m_losses;

			writer.WriteStartElement(COMMENT);
			writer.WriteValue(m_comment);
			writer.WriteEndElement();

			writer.WriteStartElement(IMAGE);
			writer.WriteValue(m_imageIndex);
			writer.WriteEndElement();

			writer.WriteEndElement();
		}

		internal void Calculate()
		{
			
		}
		#endregion
	}
}
