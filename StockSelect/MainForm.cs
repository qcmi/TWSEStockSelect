using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace StockSelect
{
	public partial class MainForm : Form
	{
		TWSEDataGrabber dataGrabber = new TWSEDataGrabber();
		BindingList<StockView> day1_list = new BindingList<StockView>();
        FileController controller = new FileController();

        public MainForm()
		{
			InitializeComponent();
			this.panelProgress.Visible = false;
            if (controller.CheckFileExist())
            {
                this.dataGrabber.SetStockInfoList(controller.ReadXML<List<StockInfo>>());
            }
		}

		private void buttonDownload_Click(object sender, EventArgs e)
		{
			DateTime endDate = this.dateTimePickerQueryDate.Value;

			if (endDate.Date == DateTime.Now.Date && DateTime.Now.Hour < 14)
			{
				MessageBox.Show("今天資料請下午兩點後再下載!", "請注意", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				this.setProgressPanelVisible(true);
				this.dataGrabber.ClearData();


				int backdays = (int)this.numericUpDownBackDays.Value;
				dataGrabber.DownloadDataRange(endDate, backdays, this);

				Thread t = new Thread(() =>
				{
					while (!dataGrabber.IsDownloadFinish)
					{
						Thread.Sleep(1000);
					}
					this.setProgressPanelVisible(false);
					this.resetProgress();
					MessageBox.Show("下載完成!", "下載完成",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					dataGrabber.IsDownloadFinish = false;
				});
				t.Start();
			}			
		}

		public void updateProgress(double percent)
		{
			this.Invoke((MethodInvoker)delegate()
			{
				this.labelProgress.Text = "已完成[" + percent.ToString("0.00") + "%]";
				this.progressBarDownload.Value = Convert.ToInt32(percent);
			});			
		}

		private void resetProgress()
		{
			this.Invoke((MethodInvoker)delegate()
			{
				this.progressBarDownload.Value = 0;
				this.labelProgress.Text = "已完成[0.00%]";
			});	
		}

		public void setProgressPanelVisible(bool isVisible)
		{
			this.Invoke((MethodInvoker)delegate()
			{
				this.panelProgress.Visible = isVisible;
			});	
		}

		private void buttonSelectStocks_Click(object sender, EventArgs e)
		{
			this.Day1Analys();
			this.refreshDay1DataGridView();
		}

		private void Day1Analys()
		{
			this.day1_list.Clear();
			double leverage = (double)this.numericUpDownLeverage.Value;
			List<StockInfo> info_list = this.dataGrabber.GetStockInfoList();
			foreach (var info in info_list)
			{
				if (info.GetPrice.Count > 0)
				{
					if (info.IsLastPriceMax() && info.LastVolume() > info.AvgVolume() * leverage)
					{
						StockView s = new StockView();
						s.Code = info.Code;
						s.Name = info.Name;
						this.day1_list.Add(s);
					}
				}				
			}
		}

		private void refreshDay1DataGridView()
		{
			this.dataGridViewDay1.DataSource = new BindingSource(this.day1_list, null);
		}

        private void buttonSaveXml_Click(object sender, EventArgs e)
        {
            controller.WriteXML(this.dataGrabber.GetStockInfoList());
        }
    }
}
