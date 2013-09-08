using System.Windows.Media.Imaging;
using TheSettlersCalculator.Helper;

namespace TheSettlersCalculator.Specialists.Generals
{
	public class General
	{
		#region Fields
		private readonly GeneralType m_id;		
		private readonly string m_name;
		private readonly int m_armySize;
		private readonly bool m_quick;
		private readonly string m_iconPath;
		private BitmapSource m_icon;
		#endregion

		#region Constructor
		public General(GeneralType id, string name, int armySize, bool quick, string iconPath)
		{
			m_id = id;
			m_iconPath = iconPath;
			m_armySize = armySize;
			m_name = name;
			m_quick = quick;
		}
		#endregion

		#region Proeprties
		public GeneralType Id
		{
			get { return m_id; }
		}

		public string Name
		{
			get { return m_name; }
		}

		public int ArmySize
		{
			get { return m_armySize; }
		}

		public bool Quick
		{
			get { return m_quick; }
		}

		public BitmapSource Icon
		{
			get
			{
				if (m_icon == null)
				{
					m_icon = ImageHelper.LoadFromResources(m_iconPath);
				}
				return m_icon;
			}
		}
		#endregion
	}
}
