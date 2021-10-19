using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Wpf_TEMP_Revit.Classes
{
    public class StockData
    {
        public static Stock StockSetData()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=FB&interval=5min&apikey=5X11Y9T9A3LX1HC2";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                dynamic json_data = JsonSerializer.Deserialize<Stock>(client.DownloadString(queryUri));

                return json_data;
            }
        }
    }


    public class Stock
    {
        [JsonPropertyName("Meta Data")]
        public MetaData MetaData { get; set; }       

        [JsonPropertyName("Time Series (5min)")]
        public List<TimeSeries5min> timeSeries5Min { get; set; }
        //public TimeSeries TimeSeries { get; set; }
    }


    public class MetaData
    {
        [JsonPropertyName("1. Information")]
        public string Information { get; set; }
        [JsonPropertyName("2. Symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("3. Last Refreshed")]
        public string LastRefreshed { get; set; }
        [JsonPropertyName("4. Interva")]
        public string Interval { get; set; }
        [JsonPropertyName("5. Output Size")]
        public string OutputSize { get; set; }
        [JsonPropertyName("6. Time Zone")]
        public string TimeZone { get; set; }
    }


    public class TimeSeries5min
    {
        List<string> dataSerii { get; set; }
    }

    public class TimeSeries
    {        
        
        [JsonPropertyName("1. open")]
        public string Open { get; set; }
        [JsonPropertyName("2. high")]
        public string High { get; set; }
        [JsonPropertyName("3. low")]
        public string Low { get; set; }
      
        [JsonPropertyName("  4. close")]
        public string Close { get; set; }
        [JsonPropertyName("5. volume")]
        public string Volume { get; set; }


    }

    
}
