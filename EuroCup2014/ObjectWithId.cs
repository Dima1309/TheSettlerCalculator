using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public abstract class ObjectWithId
	{
		#region Constants
		private const string RESOURCE_PREFIX = "EUROCUP2014_";
		private const string ICON_PREFIX = ".\\EUROCUP2014\\Icons\\";

		private const string ID = "id";
		private const string ICON = "icon";		
		#endregion

		#region Fields
		private string m_id;
		private string m_name;
		private string m_iconPath;
		private BitmapSource m_icon;
		#endregion

		#region Properties
		public string Id
		{
			get { return m_id; }
			set { m_id = value; }
		}

		public string Name
		{
			get
			{
				if (m_name == null && m_id != null)
				{
					m_name = Helper.Helper.getResourceText(RESOURCE_PREFIX + m_id, m_id);
				}
				return m_name;
			}

			set
			{
				m_name = value;
			}
		}

		public BitmapSource Icon
		{
			get
			{
				if (m_icon == null && m_iconPath != null)
				{
					m_icon = Helper.ImageHelper.LoadFromFile(ICON_PREFIX + m_iconPath);
				}
				return m_icon;
			}
		}
		#endregion

		#region Methods
		internal abstract string GetNodeName();
		internal abstract void ProcessChilds(XmlReader reader);

		internal virtual void Load(XmlReader reader)
		{
			int level = reader.Depth;
			m_id = reader.GetAttribute(ID);
			m_iconPath = reader.GetAttribute(ICON);

			while (reader.Read())
			{
				if (level > reader.Depth ||
					(reader.NodeType == XmlNodeType.EndElement &&
					 reader.Name.Equals(GetNodeName(), StringComparison.OrdinalIgnoreCase)))
				{
					break;
				}

				ProcessChilds(reader);
			}
		}
		#endregion
	}
}
