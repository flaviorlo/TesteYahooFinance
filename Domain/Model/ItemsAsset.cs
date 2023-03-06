using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ItemsAsset
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public string firstTradeDate { get; set; }
        public string regularMarketTime { get; set; }
        public string gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public string regularMarketPrice { get; set; }
        public string chartPreviousClose { get; set; }
        public string priceHint { get; set; }       
        public currencyGranularity currencyGranularity { get; set; }
        public string dataGranularity { get; set; }
        public string range { get; set; }
        public List<string> validRanges { get; set; }
    }

    public class currencyGranularity
    {
        public pre pre { get; set; }
        public regular regular { get; set; }
        public post post { get; set; }

    }
    public class pre
    {
        public string timezone { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string gmtoffset { get; set; }
    }

    public class regular
    {
        public string timezone { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string gmtoffset { get; set; }
    }

    public class post
    {
        public string timezone { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string gmtoffset { get; set; }
    }
  
    



}
