using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Quest : ObjectWithId
	{
		#region Constants
		private const string QUEST = "quest";
		private const string CAMP = "camp";
		#endregion

		#region Fields
		private List<Camp> m_camps = new List<Camp>();
		#endregion

		#region Properties
		public List<Camp> Camps
		{
			get
			{
				return m_camps;
			}
		}
		#endregion

		#region Methods
		internal override string GetNodeName()
		{
			return QUEST;
		}

		internal override void ProcessChilds(XmlReader reader)
		{
			if (reader.Name.Equals(CAMP, StringComparison.OrdinalIgnoreCase))
			{
				Camp camp = new Camp();
				camp.Load(reader);
				m_camps.Add(camp);
			}
		}
		#endregion
	}
}
