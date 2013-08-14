using System;
using System.Windows.Media.Imaging;
using System.Xml;
using TheSettlersCalculator.Helper;

namespace TheSettlersCalculator.Types
{
	public class Unit	 : IXMLSerializable
	{
		#region Consts
		internal const string UNIT = "unit";
		private const string ID = "id";
		private const string NAME = "name";
		private const string HEALTH = "health";
		private const string MIN_DAMAGE = "minDamage";
		private const string MAX_DAMAGE = "maxDamage";
		private const string ACCURACY = "accuracy";
		private const string ATTACK_PRIORITY = "priority";
		private const string ON_AREA = "attack_on_area";
		private const string WEAKNESS = "attack_weakness";
		private const string TOWER_BONUS = "tower_bonus";
		private const string IGNORE_TOWER_BONUS = "ignore_tower_bonus";
		private const string EXPERIENCE = "experience";
		private const string ICON_PATH = "icon";		
		#endregion

		#region Fields
		private static readonly Type s_attackPriorityType = typeof(AttackPriority);
		private string m_id;
		private string m_name;
		private int m_health;
		private int m_minDamage;
		private int m_maxDamage;
		private byte m_accuracy;
		private AttackPriority m_attackPriority;
		private bool m_attackOnArea;
		private bool m_attackWeaknessTarget;
		private bool m_towerBonus;
		private byte m_ignoreTowerBonus;
		private int m_experience;
		private int m_productionTime;
		private string m_iconPath;
		private BitmapSource m_icon;
		private LossesProduct[] m_lossesProduct;
		#endregion

		#region Constructor
		internal Unit()
		{			
		}

		internal Unit(string id)
		{
			m_id = id;
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public int Health
		{
			get { return m_health; }
			set { m_health = value; }
		}

		public int MinDamage
		{
			get { return m_minDamage; }
			set { m_minDamage = value; }
		}

		public int MaxDamage
		{
			get { return m_maxDamage; }
			set { m_maxDamage = value; }
		}

		public byte Accuracy
		{
			get { return m_accuracy; }
			set { m_accuracy = value; }
		}

		public AttackPriority AttackPriority
		{
			get { return m_attackPriority; }
			set { m_attackPriority = value; }
		}

		public bool AttackOnArea
		{
			get { return m_attackOnArea; }
			set { m_attackOnArea = value; }
		}

		public bool AttackWeaknessTarget
		{
			get { return m_attackWeaknessTarget; }
			set { m_attackWeaknessTarget = value; }
		}

		public int Experience
		{
			get { return m_experience; }
			set { m_experience = value; }
		}

		public BitmapSource Icon
		{
			get { return m_icon ?? (m_icon = ImageHelper.LoadFromFile(m_iconPath)); }
		}

		public bool TowerBonus
		{
			get { return m_towerBonus; }
			set { m_towerBonus = value; }
		}

		public byte IgnoreTowerBonus
		{
			get { return m_ignoreTowerBonus; }
			set { m_ignoreTowerBonus = value; }
		}

		public int ProductionTime
		{
			get { return m_productionTime; }
			set { m_productionTime = value; }
		}

		public LossesProduct[] LossesProduct
		{
			get { return m_lossesProduct; }
			internal set { m_lossesProduct = value; }
		}

		public string IconPath
		{
			get { return m_iconPath; }
			set { m_iconPath = value; }
		}

		public string MId
		{
			get { return m_id; }
			set { m_id = value; }
		}

		#endregion

		public void Load(XmlReader reader)
		{			
			int level = reader.Depth;
			while (reader.Read())
			{
				if (level > reader.Depth)
				{
					break;
				}

				if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals(UNIT, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}

				if (reader.Name.Equals(ID, StringComparison.OrdinalIgnoreCase))
				{
					m_id = reader.ReadElementString().Trim();
				}
				else if (reader.Name.Equals(NAME, StringComparison.OrdinalIgnoreCase))
				{
					m_name = Helper.Helper.getResourceText(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(ICON_PATH, StringComparison.OrdinalIgnoreCase))
				{
					m_iconPath = reader.ReadElementString().Trim();
				}
				else if (reader.Name.Equals(ATTACK_PRIORITY, StringComparison.OrdinalIgnoreCase))
				{
					string value = reader.ReadElementString().Trim();
					m_attackPriority = (AttackPriority)Enum.Parse(s_attackPriorityType, value);
				}
				else if (reader.Name.Equals(HEALTH, StringComparison.OrdinalIgnoreCase))
				{
					m_health = int.Parse(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(MIN_DAMAGE, StringComparison.OrdinalIgnoreCase))
				{
					m_minDamage = int.Parse(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(MAX_DAMAGE, StringComparison.OrdinalIgnoreCase))
				{
					m_maxDamage = int.Parse(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(ACCURACY, StringComparison.OrdinalIgnoreCase))
				{
					m_accuracy = byte.Parse(reader.ReadElementString().Trim());
					if (m_accuracy < 0 || m_accuracy > 100)
					{
						m_accuracy = 0;
					}
				}
				else if (reader.Name.Equals(EXPERIENCE, StringComparison.OrdinalIgnoreCase))
				{
					m_experience = int.Parse(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(ON_AREA, StringComparison.OrdinalIgnoreCase))
				{
					m_attackOnArea = reader.ReadElementString().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
				}
				else if (reader.Name.Equals(WEAKNESS, StringComparison.OrdinalIgnoreCase))
				{
					m_attackWeaknessTarget = reader.ReadElementString().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
				}
				else if (reader.Name.Equals(TOWER_BONUS, StringComparison.OrdinalIgnoreCase))
				{
					m_towerBonus = reader.ReadElementString().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
				}
				else if (reader.Name.Equals(IGNORE_TOWER_BONUS, StringComparison.OrdinalIgnoreCase))
				{
					m_ignoreTowerBonus = byte.Parse(reader.ReadElementString().Trim());
				}
			}
		}

		public void Save(XmlWriter writer)
		{
			writer.WriteStartElement(UNIT);

			writer.WriteStartElement(ID);
			writer.WriteValue(m_id);
			writer.WriteEndElement();
			
			writer.WriteStartElement(NAME);
			writer.WriteValue("UNIT_" + m_id);
			writer.WriteEndElement();

			writer.WriteStartElement(HEALTH);
			writer.WriteValue(Health);
			writer.WriteEndElement();

			writer.WriteStartElement(MIN_DAMAGE);
			writer.WriteValue(MinDamage);
			writer.WriteEndElement();

			writer.WriteStartElement(MAX_DAMAGE);
			writer.WriteValue(MaxDamage);
			writer.WriteEndElement();

			writer.WriteStartElement(ACCURACY);
			writer.WriteValue(Accuracy);
			writer.WriteEndElement();

			writer.WriteStartElement(EXPERIENCE);
			writer.WriteValue(Experience);
			writer.WriteEndElement();

			writer.WriteStartElement(ICON_PATH);
			writer.WriteValue(IconPath);
			writer.WriteEndElement();

			writer.WriteStartElement(ATTACK_PRIORITY);
			writer.WriteValue(AttackPriority.ToString());
			writer.WriteEndElement();			

			writer.WriteStartElement(ON_AREA);
			writer.WriteValue(m_attackOnArea?"yes":"no");
			writer.WriteEndElement();

			writer.WriteStartElement(WEAKNESS);
			writer.WriteValue(m_attackWeaknessTarget ? "yes" : "no");
			writer.WriteEndElement();
			
			writer.WriteStartElement(TOWER_BONUS);
			writer.WriteValue(m_towerBonus ? "yes" : "no");
			writer.WriteEndElement();
			
			writer.WriteStartElement(IGNORE_TOWER_BONUS);
			writer.WriteValue(m_ignoreTowerBonus);
			writer.WriteEndElement();				

			writer.WriteEndElement();
		}
	}
}
