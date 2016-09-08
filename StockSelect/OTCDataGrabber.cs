using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace StockSelect
{
    public class OTCDataGrabber : DataGrabber
    {
        string UrlEnd;
        public OTCDataGrabber() : base()
        {
            this.Url = "http://www.tpex.org.tw/web/stock/aftertrading/daily_close_quotes/stk_quote_print.php?l=zh-tw&d=";
            this.UrlEnd = "&s=0,asc,0";
        }

        public void DownloadData(DateTime queryDate)
        {
            System.Globalization.TaiwanCalendar TC = new System.Globalization.TaiwanCalendar();

            string postData = String.Format("{0}/{1}", TC.GetYear(queryDate), queryDate.ToString("MM/dd"));

            string downloadUrl = Url + postData + UrlEnd;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(downloadUrl);

            HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes("//table//tbody");
            foreach (HtmlNode table in nameNodes)
            {
                Console.WriteLine("Found: " + table.Id);
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    if (row.SelectNodes("th|td")[0].InnerText != "管理股票")
                    {
                        if (row.SelectNodes("th|td")[0].InnerText.Length == 4 || row.SelectNodes("th|td")[0].InnerText == "006201")
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                Console.WriteLine(row.SelectNodes("th|td")[i].InnerText);
                            }
                        }                      
                    }
                }
            }
        }
    }
}
