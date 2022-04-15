using System.Threading.Tasks;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Services
{
    public class TaxService : ITaxService
    {
        ITaxCollector _taxCollector;
        public TaxService(ITaxCollector taxCollector)
        {
            _taxCollector = taxCollector;
        }

        public async Task<Rates> GetRates(string zipCode)
        {
            return await _taxCollector.GetRates(zipCode);
        }

        public async Task<TaxedOrder> GetTaxes(Order order)
        {
            return await _taxCollector.GetTaxes(order);
        }
    }
}
