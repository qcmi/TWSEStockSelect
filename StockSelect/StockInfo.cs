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

		public void SortPriceListDesc()
		{
			this.price_list = (from p in price_list
							   orderby p.Date descending
							   select p).ToList();
		}

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

        public List<Price> GetPriceListFromDateByBackdays(DateTime date, int backdays)
        {
            List<Price> p_list = (from p in price_list
                                  where p.Date.Date <= date.Date
                                  orderby p.Date descending
                                  select p).Take(backdays).ToList();

            return p_list;
        }

        public double AvgClose(DateTime date, int backdays)
        {

            List<Price> p_list = this.GetPriceListFromDateByBackdays(date, backdays);

            double avgClose = (from p in p_list
                               select p.Close).Average();

            return avgClose;
        }

		public double LastPrice()
		{
			double lastPrice = price_list.OrderByDescending(t => t.Date).First().Close;
			return lastPrice;
		}

        public double Price(DateTime date)
        {
            double? datePrice = (from p in price_list
                                where p.Date == date.Date
                                select p.Close).FirstOrDefault();

            if (datePrice == null)
                return 0;
            else
                return (double)datePrice;
        }

		public bool IsLastPriceMax()
		{
			double maxPrice = price_list.Max(t => t.Close);
			if (this.LastPrice() >= maxPrice)
				return true;
			else
				return false;
		}

        public bool IsPriceMaxFromDateByBackdays(DateTime date, int backdays)
        {
            List<Price> p_list = this.GetPriceListFromDateByBackdays(date, backdays);

            double maxPrice = p_list.Max(t => t.Close);
            if (this.Price(date) >= maxPrice)
                return true;
            else
                return false;
        }

        public bool IsPriceContinuiouslyDown(DateTime date, int backdays)
        {
            List<Price> p_list = this.GetPriceListFromDateByBackdays(date, backdays);

            for (int i = 1; i < p_list.Count; i++)
            {
                // 如果今天股票價格 => 前一天股票價格
                // 表示沒有連續下跌
                if (p_list[i].Close <= p_list[i - 1].Close) 
                    return false;
            }

            return true;
        }

        public double AvgVolume()
		{
			double avgVolume = (from p in price_list
								select p.Volume).Average();

			return avgVolume;
		}

        public double AvgVolume(DateTime date, int backdays)
        {

            List<Price> p_list = this.GetPriceListFromDateByBackdays(date, backdays);

            double avgVolume = (from p in p_list
                               select p.Volume).Average();

            return avgVolume;
        }

        public double LastVolume()
		{
			double lastVolume = price_list.OrderByDescending(t => t.Date).First().Volume;
			return lastVolume;
		}

        public double Volume(DateTime date)
        {
            double? dateVolume = (from p in price_list
                                 where p.Date == date.Date
                                 select p.Volume).FirstOrDefault();

            if (dateVolume == null)
                return 0;
            else
                return (double)dateVolume;
        }

        public bool DataExist(DateTime date)
        {
            Price p = (from pp in price_list
                       where pp.Date.Date == date.Date
                       select pp).FirstOrDefault();

            if (p == null)
                return false;
            else
                return true;
        }
	}

	public class Price
	{
		public DateTime Date { get; set; } 
		public double Close { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public Int64 Volume { get; set; }
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
