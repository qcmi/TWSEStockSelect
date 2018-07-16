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
            //this.Url = "http://www.tpex.org.tw/web/stock/aftertrading/daily_close_quotes/stk_quote_print.php?l=zh-tw&d=";
            //this.UrlEnd = "&s=0,asc,0";
			this.Url = "http://www.tpex.org.tw/web/stock/aftertrading/otc_quotes_no1430/stk_wn1430_print.php?l=zh-tw&d=";
			this.UrlEnd = "&se=EW&s=0,asc,0";
        }

         override public void DownloadData(DateTime queryDate)
        {
            System.Globalization.TaiwanCalendar TC = new System.Globalization.TaiwanCalendar();

            string postData = String.Format("{0}/{1}", TC.GetYear(queryDate), queryDate.ToString("MM/dd"));

            string downloadUrl = Url + postData + UrlEnd;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(downloadUrl);

            HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes("//table//tbody");
			if (nameNodes != null)
			{
				foreach (HtmlNode table in nameNodes)
				{
                    //Console.WriteLine("Found: " + table.Id);
                    var htmlNode_list = table.SelectNodes("tr");
                    if (htmlNode_list != null)
                    {
                        foreach (HtmlNode row in htmlNode_list)
                        {
                            if (row.SelectNodes("th|td")[0].InnerText != "管理股票")
                            {
                                if (row.SelectNodes("th|td")[0].InnerText.Length == 4 || row.SelectNodes("th|td")[0].InnerText == "006201")
                                {

                                    // 0 代號
                                    // 1 名稱  
                                    // 2 收盤 
                                    // 3 漲跌  
                                    // 4 開盤 
                                    // 5 最高  
                                    // 6 最低 
                                    // 7 均價  
                                    // 8 成交股數
                                    // 9 成交金額(元)
                                    // Console.WriteLine(row.SelectNodes("th|td")[i].InnerText);
                                    this.InsertStockPrice(queryDate,
                                                           row.SelectNodes("th|td")[0].InnerText.Trim(),   // Code
                                                           row.SelectNodes("th|td")[1].InnerText.Trim(),   // Name                                                
                                                           row.SelectNodes("th|td")[4].InnerText,   // Open
                                                           row.SelectNodes("th|td")[5].InnerText,   // High
                                                           row.SelectNodes("th|td")[6].InnerText,   // Low
                                                           row.SelectNodes("th|td")[2].InnerText,   // Close
                                                           row.SelectNodes("th|td")[8].InnerText);  // Volume

                                }
                            }
                        }
                    }				
				}
			}      
        }
    }
}
