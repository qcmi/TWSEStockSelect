using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StockSelect
{
    public class DataGrabber
    {
        protected List<StockInfo> data_list = new List<StockInfo>();
        protected System.Globalization.TaiwanCalendar TC;
        public bool IsDownloadFinish { get; set; }
        protected string Url;

        public DataGrabber()
        {
            TC = new System.Globalization.TaiwanCalendar();
            this.IsDownloadFinish = false;
        }

        public void ClearData()
        {
            data_list.Clear();
        }

        public List<StockInfo> GetStockInfoList()
        {
            return this.data_list;
        }

        public void SetStockInfoList(List<StockInfo> list)
        {
            this.data_list.Clear();
            this.data_list = list;
        }

        protected void InsertStockPrice(DateTime queryDate, string Code, string Name, string Open, string High,
                                        string Low, string Close, string Volume)
        {
            StockInfo stock = (from ss in data_list
                               where ss.Code == Code
                               select ss).FirstOrDefault();

            Volume = Volume.Replace(",", "");

            if (stock == null)
            {
                stock = new StockInfo();
                stock.Code = Code;
                stock.Name = Name;
                this.data_list.Add(stock);
            }

            // avoid repeating 
            Price existP = (from p in stock.GetPrice
                            where p.Date.Date == queryDate.Date
                            select p).FirstOrDefault();

            if (existP == null && Int32.Parse(Volume) != 0 && Open != "--" && Open != "---")
            {
                Price p = new Price();
                p.Date = queryDate.Date;

                p.Volume = Int32.Parse(Volume);
                p.Open = Double.Parse(Open);
                p.High = Double.Parse(High);
                p.Low = Double.Parse(Low);
                p.Close = Double.Parse(Close);

                stock.AddPrice(p);
            }
        }

        public void DownloadDataRange(DateTime EndDate, int backDays, MainForm form)
        {
            int count = 0;
            DateTime date = EndDate;
            double percent;

            Thread t = new Thread(() =>
            {
                while (count < backDays)
                {
                    DownloadData(date);
                    date = date.AddDays(-1);
                    count = this.data_list[0].GetPrice.Count;

                    percent = (double)(((double)100 * count) / backDays);
                    form.updateProgress(percent);
                }
                this.IsDownloadFinish = true;
            });
            t.Start();
        }

        public virtual void DownloadData(DateTime date)
        {
            // 必須在子代實作
        }
    }
}
