using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TaxCalculatorApp.Settings;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(TaxCollector))]
namespace TaxCalculatorApp.Services
{
    public class TaxCollector : ITaxCollector
    {
        HttpClient taxCollectorClient;

        public TaxCollector()
        {
            taxCollectorClient = new HttpClient();
            taxCollectorClient.DefaultRequestHeaders.Accept.Clear();
            taxCollectorClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.APPLICATION_JSON));
            taxCollectorClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.BEARER, Constants.AKI_KEY);
            taxCollectorClient.BaseAddress = new Uri(Constants.BASE_ADDRESS);
        }

        public async Task<Rates> GetRates(string zipCode)
        {
            HttpResponseMessage response = await taxCollectorClient.GetAsync(new Uri(Constants.BASE_ADDRESS + "rates/" + zipCode));
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                Rates rates = JsonConvert.DeserializeObject<Rates>(responseData);
                return rates;
            }
            else
            {
                throw new Exception(Constants.APIERROR);
            }
        }
        public async Task<TaxedOrder> GetTaxes(Order order)
        {
            TaxedOrder taxOrder = null;
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new JSONContractResolver();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(order, settings));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(Constants.APPLICATION_JSON);
            HttpResponseMessage response = await taxCollectorClient.PostAsync(new Uri(Constants.BASE_ADDRESS + "taxes"), content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                Taxes taxObj = JsonConvert.DeserializeObject<Taxes>(responseData);
                if (taxObj != null)
                {
                    taxOrder = taxObj.Tax;
                }
                return taxOrder;
            }
            else
            {
                throw new Exception(Constants.APIERROR);
            }
        }
    }
}
