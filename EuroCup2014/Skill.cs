using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TheSettlersCalculator.EuroCup2014
{
	public class Skill : ObjectWithId
	{
		#region Constants
		private const string SKILL = "skill";
		private const string BUFF = "buff";
		private const string ID = "id";
		#endregion

		#region Fields
		private readonly List<Buff> m_buffs = new List<Buff>();
		#endregion

		#region Properties
		public List<Buff> Buffs
		{
			get { return m_buffs; }
		}
		#endregion

		#region Methods
		internal override string GetNodeName()
		{
			return SKILL;
		}

		internal override void ProcessChilds(XmlReader reader)
		{
			if (reader.Name.Equals(BUFF, StringComparison.OrdinalIgnoreCase))
			{
				m_buffs.Add(EuroCup2014.Buffs.BuffList[reader.GetAttribute(ID)]);
			}
		}
		#endregion
	}
}
