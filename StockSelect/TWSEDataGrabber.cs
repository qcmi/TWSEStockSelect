using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Threading;
//using System.Windows.Forms;


namespace StockSelect
{
    public class TWSEDataGrabber : DataGrabber
    {
        public TWSEDataGrabber()
        {
            //台灣證劵交易所
            // this.Url = "http://www.twse.com.tw/ch/trading/exchange/MI_INDEX/MI_INDEX.php";

            // 證交所網頁 2017/5/23改版
            this.Url = "https://www.twse.com.tw/exchangeReport/MI_INDEX";
        }

        //public void DownloadDataRange(DateTime FromDate, DateTime ToDate)
        //{
        //	DateTime date = FromDate;
        //	while (date.Date <= ToDate.Date)
        //	{
        //		DownloadData(date);
        //		//Thread.Sleep(1000);
        //		date = date.AddDays(1);
        //	}
        //}

       


        override public void DownloadData(DateTime queryDate)
        {
            string requestUrl = this.Url + "?response=html&date=" + queryDate.ToString("yyyyMMdd") + "&type=ALLBUT0999";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            // Analyze the content.

                            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(responseFromServer);

                            //HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='content']//a[@href]");

                            HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes("//table//tbody");

                            if (nameNodes != null)
                            {
                                foreach (HtmlNode row in nameNodes[8].SelectNodes("tr")) //20190718 改成Node 8
                                {
                                    // 0 證券代號 	
                                    // 1 證券名稱 	
                                    // 2 成交股數 	
                                    // 3 成交筆數 	
                                    // 4 成交金額 	
                                    // 5 開盤價 	
                                    // 6 最高價 	
                                    // 7 最低價 	
                                    // 8 收盤價 	
                                    // 9 漲跌(+/-) 	
                                    // 10 漲跌價差
                                    this.InsertStockPrice(queryDate,
                                        row.SelectNodes("th|td")[0].InnerText.Trim(), // Code
                                        row.SelectNodes("th|td")[1].InnerText.Trim(), // Name
                                        row.SelectNodes("th|td")[5].InnerText,  // Open
                                        row.SelectNodes("th|td")[6].InnerText,  // High
                                        row.SelectNodes("th|td")[7].InnerText,  // Low
                                        row.SelectNodes("th|td")[8].InnerText,  // Close
                                        row.SelectNodes("th|td")[2].InnerText);  // Volume

                                }
                            }
                        }
                    }


                }

                request.Abort();
            }

            // 證交所改版
            //      override public void DownloadData(DateTime queryDate)
            //{
            //	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //	// If required by the server, set the credentials.
            //	request.Credentials = CredentialCache.DefaultCredentials;
            //	// Set the Method property of the request to POST.
            //	request.Method = "POST";
            //	// Set the ContentType property of the WebRequest.
            //	request.ContentType = "application/x-www-form-urlencoded";
            //	// Create a request for the URL. 

            //	// Create POST data and convert it to a byte array.
            //	string postData = String.Format("qdate={0}/{1}&selectType={2}", TC.GetYear(queryDate), queryDate.ToString("MM/dd"), "ALLBUT0999");
            //	byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //	// Set the ContentLength property of the WebRequest.
            //	if (request.ContentLength != byteArray.Length)
            //	{
            //		request.ContentLength = byteArray.Length;
            //	}

            //	// Get the request stream.
            //	Stream dataStream;
            //	using (dataStream = request.GetRequestStream())
            //	{
            //		try
            //		{
            //			dataStream.Write(byteArray, 0, byteArray.Length);
            //		}
            //		catch (WebException e)
            //		{
            //			throw e;
            //		}

            //	}
            //	//Stream dataStream = request.GetRequestStream();
            //	//// Write the data to the request stream.
            //	//dataStream.Write(byteArray, 0, byteArray.Length);
            //	//// Close the Stream object.
            //	//dataStream.Close();
            //	// Get the response.
            //	using (WebResponse response = request.GetResponse())
            //	{
            //		using (dataStream = response.GetResponseStream())
            //		{
            //			using (StreamReader reader = new StreamReader(dataStream))
            //			{
            //				string responseFromServer = reader.ReadToEnd();
            //				// Analyze the content.

            //				HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //				doc.LoadHtml(responseFromServer);

            //				//HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='content']//a[@href]");

            //				HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes("//table//tbody");

            //				if (nameNodes != null)
            //				{
            //					foreach (HtmlNode row in nameNodes[4].SelectNodes("tr"))
            //					{
            //                              // 0 證券代號 	
            //                              // 1 證券名稱 	
            //                              // 2 成交股數 	
            //                              // 3 成交筆數 	
            //                              // 4 成交金額 	
            //                              // 5 開盤價 	
            //                              // 6 最高價 	
            //                              // 7 最低價 	
            //                              // 8 收盤價 	
            //                              // 9 漲跌(+/-) 	
            //                              // 10 漲跌價差
            //                              this.InsertStockPrice(queryDate,
            //                                  row.SelectNodes("th|td")[0].InnerText.Trim(), // Code
            //                                  row.SelectNodes("th|td")[1].InnerText.Trim(), // Name
            //                                  row.SelectNodes("th|td")[5].InnerText,  // Open
            //                                  row.SelectNodes("th|td")[6].InnerText,  // High
            //                                  row.SelectNodes("th|td")[7].InnerText,  // Low
            //                                  row.SelectNodes("th|td")[8].InnerText,  // Close
            //                                  row.SelectNodes("th|td")[2].InnerText);  // Volume

            //					}
            //				}
            //			}
            //		}


            //	}

            //	request.Abort();
            //}
        }
    }
