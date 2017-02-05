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
		TWSEDataGrabber twseDataGrabber = new TWSEDataGrabber();
        OTCDataGrabber otcDataGrabber = new OTCDataGrabber();

		BindingList<StockView> twse_list = new BindingList<StockView>();
        BindingList<StockView> otc_list = new BindingList<StockView>();
		BindingList<NoDataInfo> noData_list = new BindingList<NoDataInfo>();

        FileController controller = new FileController();

		string TWSExmlFileName = "TWSE_Data";
		string OTCxmlFileName = "OTC_Data";

        public MainForm()
		{
			InitializeComponent();
			this.panelProgress.Visible = false;
		}

		private void buttonDownload_Click(object sender, EventArgs e)
		{
			DateTime startDate = this.dateTimePickerDownloadDateFrom.Value;
            DateTime endDate = this.dateTimePickerDownloadDateTo.Value;

            // Difference in days, hours, and minutes.
            TimeSpan ts = endDate - startDate;

            // Difference in days.
            int backdays = ts.Days;

            if (endDate.Date == DateTime.Now.Date && DateTime.Now.Hour < 14)
			{
				MessageBox.Show("今天資料請下午兩點後再下載!", "請注意", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				this.setProgressPanelVisible(true);
				//this.twseDataGrabber.ClearData();
                //this.otcDataGrabber.ClearData();

				this.twseDataGrabber.DownloadDataRange(endDate, backdays, this);
                

				Thread t = new Thread(() =>
				{
					while (!twseDataGrabber.IsDownloadFinish)
					{
						Thread.Sleep(1000);
					}
					this.resetProgress();

                    this.otcDataGrabber.DownloadDataRange(endDate, backdays, this);

                    while (!this.otcDataGrabber.IsDownloadFinish)
                    {
                        Thread.Sleep(1000);
                    }
                    this.setProgressPanelVisible(false);
                    this.resetProgress();

                    MessageBox.Show("下載完成!", "下載完成",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					twseDataGrabber.IsDownloadFinish = false;
                    otcDataGrabber.IsDownloadFinish = false;
				});
				t.Start();
			}			
		}

		public void updateProgress(double percent)
		{
			this.Invoke((MethodInvoker)delegate()
			{
				this.labelProgress.Text = "已完成[" + percent.ToString("0.00") + "%]";
                if (percent >= 100)
                    this.progressBarDownload.Value = 100;
                else if (percent <= 0)
                    this.progressBarDownload.Value = 0;
                else
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

		private void StocksAnalys(ref BindingList<StockView> viewList, DataGrabber grabber)
        {
            viewList.Clear();
            DateTime date = this.dateTimePickerAnalysisDate.Value;
            int backdays = (int)this.numericUpDownAnalysisBackdays.Value;
            double leverage = (double)this.numericUpDownLeverage.Value;
			List<StockInfo> info_list = grabber.GetStockInfoList();

            int flowNo = 1;
			foreach (var info in info_list)
			{
				if (info.GetPrice.Count > (backdays - 2) && info.DataExist(date))
				{
                    //if (info.IsLastPriceMax() && info.LastVolume() > info.AvgVolume() * leverage)
                    if (info.IsPriceMaxFromDateByBackdays(date,backdays) 
                        && info.Volume(date) > info.AvgVolume(date,backdays) * leverage)
					{
						StockView s = new StockView();
                        s.FlowNo = flowNo;
						s.Code = info.Code;
						s.Name = info.Name;
                        viewList.Add(s);
                        flowNo++;
					}
				}				
			}
		}

        private void StocksPsyLineAnalys(ref BindingList<StockView> viewList, DataGrabber grabber)
        {
            viewList.Clear();
            DateTime date = this.dateTimePickerAnalysisDate.Value;
            int backdays = 5; //心理線參數固定5天，意思是連續下跌5天的挑出來
            List<StockInfo> info_list = grabber.GetStockInfoList();

            int flowNo = 1;
            foreach (var info in info_list)
            {
                if (info.GetPrice.Count > (backdays - 2) && info.DataExist(date))
                {
                    if (info.IsPriceContinuiouslyDown(date, backdays))                     
                    {
                        StockView s = new StockView();
                        s.FlowNo = flowNo;
                        s.Code = info.Code;
                        s.Name = info.Name;
                        viewList.Add(s);
                        flowNo++;
                    }
                }
            }
        }

		private void refreshDataGridView()
		{
			this.dataGridViewTWSE.DataSource = new BindingSource(this.twse_list, null);
            this.dataGridViewOTC.DataSource = new BindingSource(this.otc_list, null);
			this.dataGridViewNoData.DataSource = new BindingSource(this.noData_list, null);
		}

        private void buttonSaveXml_Click(object sender, EventArgs e)
        {
			if (controller.CheckFileExist(TWSExmlFileName))
			{
				DialogResult dialogResult = MessageBox.Show("已經有TWSE的資料，確定要覆蓋?", "警告"
					, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (dialogResult == DialogResult.Yes)
				{
					controller.WriteXML(this.twseDataGrabber.GetStockInfoList(), this.TWSExmlFileName);
				}
				else if (dialogResult == DialogResult.No)
				{
					//do nothing.
				}
			}
			else
			{
				controller.WriteXML(this.twseDataGrabber.GetStockInfoList(), this.TWSExmlFileName);
			}

			if (controller.CheckFileExist(OTCxmlFileName))
			{
				DialogResult dialogResult = MessageBox.Show("已經有OTC的資料，確定要覆蓋?", "警告"
					, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (dialogResult == DialogResult.Yes)
				{
					controller.WriteXML(this.otcDataGrabber.GetStockInfoList(), this.OTCxmlFileName);
				}
				else if (dialogResult == DialogResult.No)
				{
					//do nothing.
				}
			}
			else
			{
				controller.WriteXML(this.otcDataGrabber.GetStockInfoList(), this.OTCxmlFileName);
			}
			

            MessageBox.Show("資料儲存完成!", "資料儲存完成!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoadXml_Click(object sender, EventArgs e)
        {
			// TWSE
            if (controller.CheckFileExist(TWSExmlFileName))
            {
                this.twseDataGrabber.SetStockInfoList(controller.ReadXML<List<StockInfo>>(TWSExmlFileName));
                MessageBox.Show("TWSE資料讀取完成!", "資料讀取完成!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(TWSExmlFileName + " 資料檔案不存在!", "TWSE資料檔案不存在!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

			// OTC
			if (controller.CheckFileExist(OTCxmlFileName))
			{
				this.otcDataGrabber.SetStockInfoList(controller.ReadXML<List<StockInfo>>(OTCxmlFileName));
				MessageBox.Show("OTC資料讀取完成!", "資料讀取完成!",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(OTCxmlFileName + " 資料檔案不存在!", "OTC資料檔案不存在!",
						MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
        }


		private void arangeNoDataList(int backdays)
		{
			this.noData_list.Clear();
			DateTime date = this.dateTimePickerAnalysisDate.Value;
			
			this.AddNoDataInfo(this.twseDataGrabber.GetNoDataList(date, backdays));
			this.AddNoDataInfo(this.otcDataGrabber.GetNoDataList(date, backdays));
		}

		private void AddNoDataInfo(List<DateTime> nodatalist)
		{
			foreach (var data in nodatalist)
			{
				NoDataInfo d = (from dd in this.noData_list
								where dd.Date.Date == data.Date.Date
								select dd).FirstOrDefault();

				if (d == null)
				{
					NoDataInfo info = new NoDataInfo();
					info.Date = data.Date;
					info.Weekday = data.Date.ToString("ddd");
					this.noData_list.Add(info);
				}
			}
		}

        private void buttonCheckDataVolumn_Click(object sender, EventArgs e)
        {
            int backdays = (int)this.numericUpDownAnalysisBackdays.Value;
            this.arangeNoDataList(backdays);
            this.refreshDataGridView();
        }

        private void buttonSelectStocksVolumn_Click(object sender, EventArgs e)
        {
            this.StocksAnalys(ref this.twse_list, this.twseDataGrabber);
            this.StocksAnalys(ref this.otc_list, this.otcDataGrabber);
            this.refreshDataGridView();
        }

        private void buttonCheckDataPsy_Click(object sender, EventArgs e)
        {
            int backdays = 5;
            this.arangeNoDataList(backdays);
            this.refreshDataGridView();
        }

        private void buttonSelectStocksPsy_Click(object sender, EventArgs e)
        {
            this.StocksPsyLineAnalys(ref this.twse_list, this.twseDataGrabber);
            this.StocksPsyLineAnalys(ref this.otc_list, this.otcDataGrabber);
            this.refreshDataGridView();
        }
    }

    public class NoDataInfo
	{
		public DateTime Date { get; set; }
		public string Weekday { get; set; }
	}
}
