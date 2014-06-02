using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TheSettlersCalculator.EuroCup2014
{
	public class IncomingResources : INotifyPropertyChanged
	{
		#region Fields
		private double m_shortSearchInDay=0;
		private double m_mediumSearchInDay=0;
		private double m_longSearchInDay=0;
		private double m_veryLongSearchInDay=0;
		private double m_collectItemsInDay=0;
		#endregion

		#region Constructor
		public IncomingResources() { }
		
		public IncomingResources(double shortSearchInDay, double mediumSearchInDay, double longSearchInDay, double veryLongSearchInDay, double collectItemsInDay)
		{
			m_shortSearchInDay = shortSearchInDay;
			m_mediumSearchInDay = mediumSearchInDay;
			m_longSearchInDay = longSearchInDay;
			m_veryLongSearchInDay = veryLongSearchInDay;
			m_collectItemsInDay = collectItemsInDay;
		}
		#endregion

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Properties
		public double ShortSearchInDay
		{
			get { return m_shortSearchInDay; }
			set 
			{ 
				m_shortSearchInDay = value;
				OnPropertyChanged("ShortSearchInDay");
			}
		}

		public double MediumSearchInDay
		{
			get { return m_mediumSearchInDay; }
			set 
			{ 
				m_mediumSearchInDay = value;
				OnPropertyChanged("MediumSearchInDay");
			}
		}

		public double LongSearchInDay
		{
			get { return m_longSearchInDay; }
			set 
			{ 
				m_longSearchInDay = value;
				OnPropertyChanged("LongSearchInDay");
			}
		}

		public double VeryLongSearchInDay
		{
			get { return m_veryLongSearchInDay; }
			set 
			{ 
				m_veryLongSearchInDay = value;
				OnPropertyChanged("VeryLongSearchInDay");
			}
		}

		public double CollectItemsInDay
		{
			get { return m_collectItemsInDay; }
			set 
			{ 
				m_collectItemsInDay = value;
				OnPropertyChanged("CollectItemsInDay");
			}
		}
		#endregion

		#region Methods
		internal IDictionary<string, double> GetResources()
		{
			IDictionary<string, double> result = new Dictionary<string, double>();
			foreach(Resource resource in Resources.ResourceList.Values)
			{
				result[resource.Id] = resource.ShortSearchRate * ShortSearchInDay +
					resource.MediumSearchRate * MediumSearchInDay +
					resource.LongSearchRate * LongSearchInDay +
					resource.VeryLongSearchRate * VeryLongSearchInDay +
					resource.CollectiableRate * CollectItemsInDay;
			}

			return result;
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
