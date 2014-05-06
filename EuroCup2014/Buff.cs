using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Buff : ObjectWithId
	{
		#region Constants
		private const string BUFF = "buff";
		private const string PROVISION_HOUSE = "provision_house";
		private const string RARIRY_PROVISION_HOUSE = "rarity_provision_house";
		private const string RESOURCE = "resource";
		private const string ID = "id";
		private const string COUNT = "count";
		#endregion

		#region Fields
		private List<ResourceWithCount> m_temp;
		private List<ResourceWithCount> m_provisionHouseCost;
		private List<ResourceWithCount> m_rarityProvisionHouseCost;
		#endregion

		#region Properties
		public List<ResourceWithCount> ProvisionHouseCost
		{
			get { return m_provisionHouseCost; }
		}

		public  List<ResourceWithCount> RarityProvisionHouseCost
		{
			get { return m_rarityProvisionHouseCost; }		
		}
		#endregion

		#region Methods
		internal override string GetNodeName()
		{
			return BUFF;
		}

		internal override void ProcessChilds(XmlReader reader)
		{
			if (reader.Name.Equals(PROVISION_HOUSE, StringComparison.OrdinalIgnoreCase))
			{
				if (reader.NodeType == XmlNodeType.EndElement)
				{
					m_provisionHouseCost = m_temp;
				} else if (reader.IsStartElement())
				{
					m_temp = new List<ResourceWithCount>(2);
				}
			} else if (reader.Name.Equals(RARIRY_PROVISION_HOUSE, StringComparison.OrdinalIgnoreCase))
			{
				if (reader.NodeType == XmlNodeType.EndElement)
				{
					m_rarityProvisionHouseCost = m_temp;
				}
				else if (reader.IsStartElement())
				{
					m_temp = new List<ResourceWithCount>(2);
				}
			}
			else if (reader.Name.Equals(RESOURCE, StringComparison.OrdinalIgnoreCase))
			{
				if (m_temp == null)
				{
					return;
				}
				m_temp.Add(
						new ResourceWithCount(reader.GetAttribute(ID).Trim(),
						int.Parse(reader.GetAttribute(COUNT).Trim(), CultureInfo.InvariantCulture)));
			}
		}
		#endregion
	}
}
