using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StockSelect
{
	public class StockInfo
	{	
		List<Price> price_list = new List<Price>();
		public string Name { get; set; }
		public string Code { get; set; }
		public List<Price> GetPrice { get { return price_list;} }

		public void AddPrice(Price p)
		{
			this.price_list.Add(p);
		}

		public double AvgClose()
		{
			double avgClose = (from p in price_list
							   select p.Close).Average();

			return avgClose;  
		}

		public double LastPrice()
		{
			double lastPrice = price_list.OrderByDescending(t => t.Date).First().Close;
			return lastPrice;
		}

		public bool IsLastPriceMax()
		{
			double maxPrice = price_list.Max(t => t.Close);
			if (this.LastPrice() >= maxPrice)
				return true;
			else
				return false;
		}

		public double AvgVolume()
		{
			double avgVolume = (from p in price_list
								select p.Volume).Average();

			return avgVolume;
		}

		public double LastVolume()
		{
			double lastVolume = price_list.OrderByDescending(t => t.Date).First().Volume;
			return lastVolume;
		}
	}

	public class Price
	{
		public DateTime Date { get; set; } 
		public double Close { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public int Volume { get; set; }
	}

	public class StockView
	{
        [DisplayName("#")]
        public int FlowNo { get; set; }

        [DisplayName("股票名稱")]
		public string Name { get; set; }

		[DisplayName("股票代碼")]
		public string Code { get; set; }
	}
}
