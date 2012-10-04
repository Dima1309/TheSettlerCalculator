using System.ComponentModel;
using System.Windows.Media.Imaging;
using TheSettlersCalculator.Types;

namespace TheSettlersCalculator.WpfTypes
{
    /// <summary>
    /// Класс для хранении информации о отряде юнитов.
    /// </summary>
	public class UnitSquad : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

        #region Fields
        private readonly Unit m_unit;
        private int m_count;
        #endregion

        #region Constructor
        internal UnitSquad(Unit unit, int count)
        {
            m_unit = unit;
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

    	internal Unit Unit
    	{
    		get { return m_unit; }
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
    }
}
