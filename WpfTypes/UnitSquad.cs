using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
    /// <summary>
    /// Класс для хранении информации о отряде юнитов.
    /// </summary>
	public class UnitSquad : INotifyPropertyChanged, ICloneable
    {
		public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        private Unit m_unit;
        private int m_count;
        #endregion

        #region Constructor
        internal UnitSquad(Unit unit, int count)
        {
            Unit = unit;
            Count = count;
        }
        #endregion

        public string Name
        {
            get { return Unit.Name; }
        }

		public BitmapSource Icon 
		{
			get { return Unit.Icon; }
		}

        public int Count
        {
            get
            {
            	return m_count;
            }

            set
            {
            	m_count = value;
            	OnPropertyChanged("Count");
            }
        }

		public Unit Unit
		{
			get { return m_unit; }
			set
			{
				m_unit = value;
				OnPropertyChanged("Icon");
			}
		}

    	#region Methods
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

    	public object Clone()
    	{
    		return new UnitSquad(Unit, Count);
    	}
    }
}
