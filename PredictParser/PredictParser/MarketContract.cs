using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictParser
{
    public class MarketContract
    {
        public int ID { get; set; }
        public string DateEnd { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string TickerSymbol { get; set; }
        public string Status { get; set; }
        public string LastTradePrice { get; set; }
        public string BestBuyYesCost { get; set; }
        public string BestBuyNoCost { get; set; }
        public string BestSellYesCost { get; set; }
        public string BestSellNoCost { get; set; }
        public string LastClosePrice { get; set; }
    }

    public class MarketData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string TickerSymbol { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public MarketContract[] Contracts { get; set; }
        public string TimeStamp { get; set; }
        public string Status { get; set; }
    }

    public class MarketList
    {
        public MarketData[] Markets { get; set; }
    }
}
