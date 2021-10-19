using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace Wpf_TEMP_Revit
{
    class NBPclass
    {
       

        public async static Task<ObservableCollection<Rates>> LoadDataFromNbp()
        {
            ObservableCollection<Rates> ratesCollection = new ObservableCollection<Rates>();

            DateTime fromDate = new DateTime(2021, 9, 15);
            string fromDateString = fromDate.ToString("yyyy'-'MM'-'dd");
            DateTime todayDate = DateTime.Now;
            string todayDateString = todayDate.ToString("yyyy'-'MM'-'dd");

            string url = "http://api.nbp.pl/api/exchangerates/rates/A/USD/" + fromDateString + "/" + todayDateString + "";

            HttpClient ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.TryAddWithoutValidation("No", "No1");

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Nbp result = await response.Content.ReadAsAsync<Nbp>();
                    ratesCollection = new ObservableCollection<Rates>(result.Rates);
                    return ratesCollection; 
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //Lespza łatwiejsza
        public static Nbp StockDataNbp(DateTime StartDate)
        {
            string fromDateString = StartDate.ToString("yyyy'-'MM'-'dd");
            DateTime todayDate = DateTime.Now;
            string todayDateString = todayDate.ToString("yyyy'-'MM'-'dd");

            string QUERY_URL = "http://api.nbp.pl/api/exchangerates/rates/A/USD/" + fromDateString + "/" + todayDateString + "";

            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                dynamic json_data = JsonSerializer.Deserialize<Nbp>(client.DownloadString(queryUri));                
                return json_data;
            }
        }
    }

    public class Nbp
    {
        [JsonPropertyName("table")]        
        public string Table { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("rates")]
        public List<Rates> Rates { get; set; }

    }

    public class Rates
    {
        [JsonPropertyName("no")]
        public string No1 { get; set; }

        [JsonPropertyName("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("mid")]
        public double Mid { get; set; }
    }


}
