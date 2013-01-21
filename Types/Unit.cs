using System.Windows.Media.Imaging;

namespace TheSettlersCalculator.Types
{
	public class Unit
	{
		#region Fields
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
		private BitmapSource m_icon;
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
			get { return m_icon; }
			set { m_icon = value; }
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
		#endregion
	}
}
