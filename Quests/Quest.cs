using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.Xml;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	public class Quest : IXMLSerializable
	{
		#region Consts
		private const string QUEST = "quest";
		private const string NAME = "name";
		private const string MAP_PATH = "map";
		private const string ICON_PATH = "icon";
		private const string ENEMIES = "enemies";
		private const string ENEMY = "enemy";
		private const string CAMPS = "camps";
		private const string CAMP = "camp";

		private const string CAMP_TYPE = "type";
		private const string WIN_TIME = "wintime";
		private const string SECTOR = "sector";
		private const string LEFT = "left";
		private const string TOP = "top";
		private const string UNIT = "unit";
		private const string COUNT = "count";
		#endregion

		#region Fields
		private string m_fileName;
		private string m_resourceName;
		private string m_name;
		private BitmapSource m_icon;
		private Unit[] m_units;
		private Camp[] m_camps;
		private BitmapSource m_map;
		private string m_mapPath;
		private string m_iconPath;
		#endregion

		#region Properties
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(m_name))
				{
					m_name = Helper.Helper.getResourceText(m_resourceName);
				}
				return m_name;
			}

			set { m_name = value; }
		}

		internal Unit[] Units
		{
			get { return m_units; }
			set { m_units = value; }
		}

		internal Camp[] Camps
		{
			get { return m_camps; }
			set { m_camps = value; }
		}

		public BitmapSource Icon
		{
			get { return m_icon ?? (m_icon = ImageHelper.LoadFromFile(m_iconPath)); }
		}

		public BitmapSource Map
		{
			get { return m_map ?? (m_map = ImageHelper.LoadFromFile(m_mapPath)); }
		}

		internal string MapPath
		{
			get { return m_mapPath; }
			set { m_mapPath = value; }
		}

		public string IconPath
		{
			get { return m_iconPath; }
			set { m_iconPath = value; }
		}

		public string FileName
		{
			get { return m_fileName; }
			set { m_fileName = value; }
		}
		#endregion

		public void Load(XmlReader reader)
		{
			List<string> enemies = new List<string>();
			List<Unit> units = new List<Unit>();
			List<Camp> camps = new List<Camp>();
			int level = reader.Depth;
			while (reader.Read())
			{
				if(level > reader.Depth)
				{
					break;
				}

				if(reader.Name.Equals(NAME, StringComparison.OrdinalIgnoreCase))
				{
					m_resourceName = reader.ReadElementString().Trim();
				}
				else if(reader.Name.Equals(MAP_PATH, StringComparison.OrdinalIgnoreCase))
				{
					m_mapPath = reader.ReadElementString().Trim();
				}
				else if(reader.Name.Equals(ICON_PATH, StringComparison.OrdinalIgnoreCase))
				{
					m_iconPath = reader.ReadElementString().Trim();
				}
				else if(reader.Name.Equals(ENEMY, StringComparison.OrdinalIgnoreCase))
				{
					string value = reader.ReadElementString().Trim();					
					if (!enemies.Contains(value))
					{
						enemies.Add(value);
					}
					if (!EnemyUnits.Units.ContainsKey(value))
					{
						units.Add(EnemyUnits.Units[value]);	
					}

					units.Add(EnemyUnits.Units[value]);
				}
				else if(reader.Name.Equals(CAMP, StringComparison.OrdinalIgnoreCase))
				{
					camps.Add(LoadCamp(reader, enemies));
				}
			}

			m_units = units.ToArray();
			m_camps = camps.ToArray();
		}

		public void Save(XmlWriter writer)
		{
			writer.WriteStartElement(QUEST);

			//m_name;//resource
			writer.WriteStartElement(NAME);
			writer.WriteValue(m_resourceName??m_name);
			writer.WriteEndElement();

			writer.WriteStartElement(MAP_PATH);
			writer.WriteValue(m_mapPath);
			writer.WriteEndElement();

			//m_iconPath;
			writer.WriteStartElement(ICON_PATH);
			writer.WriteValue(m_iconPath);
			writer.WriteEndElement();

			//m_units;//convert to EnemyUnit
			string[] enemies = new string[Units.Length];
			writer.WriteStartElement(ENEMIES);
			foreach(Unit unit in Units)
			{
				writer.WriteStartElement(ENEMY);
				writer.WriteValue(unit.Id);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();

			//m_camps;//save camps
			writer.WriteStartElement(CAMPS);
			foreach (Camp camp in Camps)
			{
				SaveCamps(writer, camp, enemies);
			}
			writer.WriteEndElement();

			writer.WriteEndElement();
		}

		private void SaveCamps(XmlWriter writer, Camp camp, string[] enemies)
		{
			writer.WriteStartElement(CAMP);

			//m_name;//resource
			writer.WriteStartElement(NAME);
			writer.WriteValue(camp.Name);
			writer.WriteEndElement();

			//m_campType;//CampType
			writer.WriteStartElement(CAMP_TYPE);
			writer.WriteValue(camp.CampType.ToString());
			writer.WriteEndElement();

			//m_winTime;//CampWinTime or integer
			writer.WriteStartElement(WIN_TIME);
			writer.WriteValue(camp.WinTime.ToString());
			writer.WriteEndElement();

			//m_sectorId;//integer
			writer.WriteStartElement(SECTOR);
			writer.WriteValue(camp.SectorId);
			writer.WriteEndElement();

			//m_left;//double
			if (camp.Left > 0)
			{
				writer.WriteStartElement(LEFT);
				writer.WriteValue(camp.Left.ToString(CultureInfo.InvariantCulture));
				writer.WriteEndElement();
			}

			//m_top;//double
			if (camp.Top > 0)
			{
				writer.WriteStartElement(TOP);
				writer.WriteValue(camp.Top.ToString(CultureInfo.InvariantCulture));
				writer.WriteEndElement();
			}

			//unit(convert to EnemyUnit), count
			//m_counts;
			foreach (KeyValuePair<short, short> pair in camp.Counts)
			{
				writer.WriteStartElement(ENEMY);
				writer.WriteAttributeString(UNIT, m_units[pair.Key].Id);
				writer.WriteAttributeString(COUNT, pair.Value.ToString(CultureInfo.InvariantCulture));
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
		}

		private static Camp LoadCamp(XmlReader reader, List<string> enemies)
		{
			Camp result = new Camp();
			int level = reader.Depth;
			Type campType = typeof(CampType);
			Type campWinTimeType = typeof(CampWinTime);
			while (reader.Read())
			{
				if (level >= reader.Depth)
				{
					break;
				}

				if (reader.Name.Equals(NAME, StringComparison.OrdinalIgnoreCase))
				{
					result.Name = reader.ReadElementString().Trim();
				}
				else if (reader.Name.Equals(CAMP_TYPE, StringComparison.OrdinalIgnoreCase))
				{
					result.CampType = (CampType) Enum.Parse(campType, reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(WIN_TIME, StringComparison.OrdinalIgnoreCase))
				{
					result.WinTime = (int)(CampWinTime)Enum.Parse(campWinTimeType, reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(SECTOR, StringComparison.OrdinalIgnoreCase))
				{
					result.SectorId = byte.Parse(reader.ReadElementString().Trim());
				}
				else if (reader.Name.Equals(LEFT, StringComparison.OrdinalIgnoreCase))
				{
					result.Left = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
				}
				else if (reader.Name.Equals(TOP, StringComparison.OrdinalIgnoreCase))
				{
					result.Top = double.Parse(reader.ReadElementString().Trim(), CultureInfo.InvariantCulture);
				}
				else if (reader.Name.Equals(ENEMY, StringComparison.OrdinalIgnoreCase))
				{
					result.Counts[(short) enemies.IndexOf(reader.GetAttribute(UNIT))] = 
						short.Parse(reader.GetAttribute(COUNT), CultureInfo.InvariantCulture);
				}
			}

			return result;
		}
	}
}
