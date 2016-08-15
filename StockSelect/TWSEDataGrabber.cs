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
	public class TWSEDataGrabber
	{
		List<StockInfo> data_list = new List<StockInfo>();
		System.Globalization.TaiwanCalendar TC;
		public bool IsDownloadFinish { get; set; }
		//台灣證劵交易所
		string url = "http://www.twse.com.tw/ch/trading/exchange/MI_INDEX/MI_INDEX.php";

		public TWSEDataGrabber()
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
            this.data_list = list;
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

		public void DownloadDataRange(DateTime FromDate, DateTime ToDate)
		{
			DateTime date = FromDate;
			while (date.Date <= ToDate.Date)
			{
				DownloadData(date);
				//Thread.Sleep(1000);
				date = date.AddDays(1);
			}
		}

		public void DownloadData(DateTime queryDate)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			// If required by the server, set the credentials.
			request.Credentials = CredentialCache.DefaultCredentials;
			// Set the Method property of the request to POST.
			request.Method = "POST";
			// Set the ContentType property of the WebRequest.
			request.ContentType = "application/x-www-form-urlencoded";
			// Create a request for the URL. 

			// Create POST data and convert it to a byte array.
			string postData = String.Format("qdate={0}/{1}&selectType={2}", TC.GetYear(queryDate), queryDate.ToString("MM/dd"), "ALLBUT0999");
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);

			// Set the ContentLength property of the WebRequest.
			if (request.ContentLength != byteArray.Length)
			{
				request.ContentLength = byteArray.Length;
			}

			// Get the request stream.
			Stream dataStream;
			using (dataStream = request.GetRequestStream())
			{
				try
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
				}
				catch (WebException e)
				{
					throw e;
				}

			}
			//Stream dataStream = request.GetRequestStream();
			//// Write the data to the request stream.
			//dataStream.Write(byteArray, 0, byteArray.Length);
			//// Close the Stream object.
			//dataStream.Close();
			// Get the response.
			using (WebResponse response = request.GetResponse())
			{
				using (dataStream = response.GetResponseStream())
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
							foreach (HtmlNode row in nameNodes[4].SelectNodes("tr"))
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
								string Code = row.SelectNodes("th|td")[0].InnerText.Trim();

								StockInfo stock = (from ss in data_list
												   where ss.Code == Code
												   select ss).FirstOrDefault();

								if (stock == null)
								{
									stock = new StockInfo();
									stock.Code = Code;
									stock.Name = row.SelectNodes("th|td")[1].InnerText.Trim();
									this.data_list.Add(stock);
								}

								// avoid repeating 
								Price existP = (from p in stock.GetPrice
												where p.Date.Date == queryDate.Date
												select p).FirstOrDefault();

								int volume = Int32.Parse(row.SelectNodes("th|td")[2].InnerText.Replace(",", ""));
								string open = row.SelectNodes("th|td")[5].InnerText;

								if (existP == null && volume != 0 && open != "--")
								{
									Price p = new Price();
									p.Date = queryDate.Date;

									p.Volume = volume;
									p.Open = Double.Parse(open);
									p.High = Double.Parse(row.SelectNodes("th|td")[6].InnerText);
									p.Low = Double.Parse(row.SelectNodes("th|td")[7].InnerText);
									p.Close = Double.Parse(row.SelectNodes("th|td")[8].InnerText);

									stock.AddPrice(p);
								}
							}
						}
					}
				}


			}

			request.Abort();
		}
	}
}
