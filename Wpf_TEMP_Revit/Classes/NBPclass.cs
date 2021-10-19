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

namespace Wpf_TEMP_Revit
{
    class NBPclass
    {
        //public async static Task<Nbp> LoadDataFromNbp()
        //{
        //    DateTime fromDate = new DateTime(2021, 09, 28);
        //    string fromDateString = fromDate.ToString("yyyy'-'MM'-'dd");
        //    DateTime todayDate = DateTime.Now;
        //    string todayDateString = todayDate.ToString("yyyy'-'MM'-'dd");

        //    string url = "http://api.nbp.pl/api/exchangerates/rates/A/USD/"+ fromDateString + "/" + todayDateString + "";


        //    HttpClient ApiClient = new HttpClient();
        //    ApiClient.DefaultRequestHeaders.Accept.Clear();
        //    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    using (HttpResponseMessage response=await ApiClient.GetAsync(url))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            //Nbp result = await response.Content.ReadAdsAsync<Nbp>();
        //            Nbp result = await response.Content.ReadAsAsync<Nbp>();
        //            return result;

        //        }else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}

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
    }

    public class Nbp
    {
        [JsonPropertyName("Table")]
        public string Table { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Rates")]
        public List<Rates> Rates{ get; set; }

    }

    public class Rates
    {
        [JsonPropertyName("No")]
        public string No1 { get; set; }

        [JsonPropertyName("EffectiveDatee")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("Mid")]
        public double Mid { get; set; }
    }


}
