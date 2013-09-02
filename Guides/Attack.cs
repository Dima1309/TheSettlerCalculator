using System;
using System.Collections.ObjectModel;
using System.Xml;
using TheSettlersCalculator.Types;
using TheSettlersCalculator.WpfTypes;

namespace TheSettlersCalculator.Guides
{
	public class Attack
	{
		#region Fields
		private string m_name;
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
		#endregion

		#region Methods
		public void Load(XmlReader reader, Guide guide)
		{
			throw new NotImplementedException();
		}

		public void Save(XmlWriter writer, Guide guide)
		{
			throw new NotImplementedException();
		}

		internal void Calculate()
		{
			
		}
		#endregion
	}
}
