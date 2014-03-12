using System;
using System.Windows.Media.Imaging;
using System.Xml;
using TheSettlersCalculator.Helper;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Specialists.Generals
{
	public class General : Unit
	{
        #region Consts
		internal new const string ROOT = "general";
        internal const string ARMY_SIZE = "armySize";
        private const string QUICK = "quick";
        #endregion

		#region Fields
		private int m_armySize;
		private bool m_quick;
		#endregion

		#region Constructor
		internal General()
		{
		}

        internal General(string id):base(id)
		{
		}

        internal General(String id, String name, int armySize, bool quick, String image) :base(id)
        {
            base.Name = name;
            m_armySize = armySize;
            m_quick = quick;
            IconPath = image;
            MinDamage = 120;
            MaxDamage = 120;
            Accuracy = 100;
            Health = 1;
            AttackPriority = AttackPriority.Normal;
        }
		#endregion

		#region Properties
		public int ArmySize
		{
			get { return m_armySize; }
		}

		public bool Quick
		{
			get { return m_quick; }
		}
		#endregion

        #region Methods
        internal override void LoadAttribute(XmlReader reader)
        {
            if (reader.Name.Equals(ARMY_SIZE, StringComparison.OrdinalIgnoreCase))
            {
                m_armySize = int.Parse(reader.ReadElementString().Trim());
            }
            else if (reader.Name.Equals(QUICK, StringComparison.OrdinalIgnoreCase))
            {
                m_quick = reader.ReadElementString().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                base.LoadAttribute(reader);
            }
        }

		internal override void SaveAttributes(XmlWriter writer)
        {
            base.SaveAttributes(writer);

            writer.WriteStartElement(ARMY_SIZE);
            writer.WriteValue(ArmySize);
            writer.WriteEndElement();

            writer.WriteStartElement(QUICK);
            writer.WriteValue(m_quick ? "yes" : "no");
            writer.WriteEndElement();
        }

		internal override string GetRootNode()
		{
			return ROOT;
		}
        #endregion
    }
}
