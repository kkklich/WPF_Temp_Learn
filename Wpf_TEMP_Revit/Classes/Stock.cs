using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Wpf_TEMP_Revit.Classes
{
    public class Stock
    {
        public async static Task<MetaData> DownloadStockAPI()
        {
            string url = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=FB&interval=5min&apikey=5X11Y9T9A3LX1HC2";

            HttpClient ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<MetaData>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static Dictionary<string, dynamic> StockData()
        {
            //string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo";
            string QUERY_URL = "http://api.nbp.pl/api/exchangerates/rates/A/USD/";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));
                
                return json_data;
            }
        }
        public class MetaData
        {
            public string Information { get; set; }
            public string Symbol { get; set; }
            public DateTime LastRefreshed { get; set; }
            public string Interval { get; set; }
            public string OutputSize { get; set; }
            public string TimeZone { get; set; }

            public List<TimeSeries> TimeSeries { get; set; }
        }


        public class TimeSeries
        {
            public DateTime TimeSeriesTime { get; set; }
        }

    }
}
