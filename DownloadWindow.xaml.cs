using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheSettlersCalculator
{
	/// <summary>
	/// Логика взаимодействия для DownloadWindow.xaml
	/// </summary>
	public partial class DownloadWindow : Window
	{
		public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(int), typeof(DownloadWindow));
		public static readonly DependencyProperty BytesReceivedProperty = DependencyProperty.Register("BytesReceived", typeof(long), typeof(DownloadWindow));
		public static readonly DependencyProperty TotalBytesToReceiveProperty = DependencyProperty.Register("TotalBytesToReceive", typeof(long), typeof(DownloadWindow));

		#region Fields
		private String m_fileName;		
		#endregion 

		#region Constructor
		public DownloadWindow(String fileName)
		{
			m_fileName = fileName;
			InitializeComponent();
		}
		#endregion

		#region Properties
		public int Progress
		{
			get { return (int)GetValue(ProgressProperty); }
			set { SetValue(ProgressProperty, value); }
		}

		public long BytesReceived
		{
			get { return (long)GetValue(BytesReceivedProperty); }
			set { SetValue(BytesReceivedProperty, value); }
		}

		public long TotalBytesToReceive
		{
			get { return (long)GetValue(TotalBytesToReceiveProperty); }
			set { SetValue(TotalBytesToReceiveProperty, value); }
		}
		#endregion

		#region Methods
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
			webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
			Uri url = new Uri(new Uri("https://googledrive.com/host/0B_4wpSXnSMGScjdOR1E5aFJmNDA/"), m_fileName);			
			webClient.DownloadFileAsync(url, m_fileName);
		}

		void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			Progress = e.ProgressPercentage;
			BytesReceived = e.BytesReceived;
			TotalBytesToReceive = e.TotalBytesToReceive;
		}

		void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show("При загрузке карта произошла ошибка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				DialogResult = false;
				Close();
			}
			else
			{
				DialogResult = true;
				Close();
			}
		}
		#endregion
	}
}
