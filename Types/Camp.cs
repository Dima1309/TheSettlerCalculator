using System.Collections.Generic;
using System.ComponentModel;

namespace TheSettlersCalculator.Types
{
	public class Camp : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Fields
		private readonly SortedDictionary<short, short> m_counts = new SortedDictionary<short, short>();
		private string m_name;
		private CampType m_campType;
		private CampWinTime m_winTime = CampWinTime.Normal;
		private byte m_sectorId;
		private double m_left;
		private double m_top;
		#endregion

		#region Constructors
		public Camp()
		{}

		internal Camp(Camp camp)
		{
			m_name = camp.Name;
			m_campType = camp.CampType;
			m_winTime = camp.m_winTime;
			m_sectorId = camp.SectorId;
			m_left = camp.Left;
			m_top = camp.Top;
		}
		#endregion

		#region Properties
		public string Name
		{
			get { return m_name; }
			set { SetField(ref m_name, value, "Name"); }
		}

		public SortedDictionary<short, short> Counts
		{
			get { return m_counts; }
		}

		public CampType CampType
		{
			get { return m_campType; }
			set { SetField(ref m_campType, value, "CampType"); }
		}

		public byte SectorId
		{
			get { return m_sectorId; }
			set { SetField(ref m_sectorId, value, "SectorId"); }
		}

		public double Left
		{
			get { return m_left; }
			set { SetField(ref m_left, value, "Left"); }
		}

		public double Top
		{
			get { return m_top; }
			set { SetField(ref m_top, value, "Top"); }
		}

		public int WinTime
		{
			get { return (int)m_winTime; }
			set { SetField(ref m_winTime, (CampWinTime)value, "WinTime"); }
		}
		#endregion

		#region Methods
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected bool SetField<T>(ref T field, T value, string propertyName)
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
			{
				return false;
			}

			field = value;
			
			OnPropertyChanged(propertyName);

			return true;
		}
		#endregion
	}
}
