using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockSelect
{
    public class DataGrabber
    {
        protected List<StockInfo> data_list = new List<StockInfo>();
        System.Globalization.TaiwanCalendar TC;
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
    }
}
