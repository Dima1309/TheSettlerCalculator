using System.Windows.Media.Imaging;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.Quests
{
	public class Quest
	{
		#region Fields
		private string m_name;
		private BitmapSource m_icon;
		private Unit[] m_units;
		private Camp[] m_camps;
		private BitmapSource m_map;
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
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
			get { return m_icon; }
			set { m_icon = value; }
		}

		public BitmapSource Map
		{
			get { return m_map; }
			set { m_map = value; }
		}
		#endregion
	}
}
