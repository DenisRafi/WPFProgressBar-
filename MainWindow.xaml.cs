using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace WpfProgressBar
{
	public partial class wpf1 : Window
	{
		public wpf1()
		{
			InitializeComponent();
		}

		private void Window(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += DoWork;
			worker.ProgressChanged += ProgressChanged;

			worker.RunWorkerAsync();
		}

		void DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 100; i++)
			{
				(sender as BackgroundWorker).ReportProgress(i);
				Thread.Sleep(50);
			}
		}

		void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ByDenisRafi.Value = e.ProgressPercentage;
		}
	}
}