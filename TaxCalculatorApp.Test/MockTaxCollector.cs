using System.Threading.Tasks;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using TaxCalculatorApp.Test;
using Xamarin.Forms;

[assembly: Dependency(typeof(MockTaxCollector))]
namespace TaxCalculatorApp.Test
{
    public class MockTaxCollector : ITaxCollector
    {
        public async Task<Rates> GetRates(string zipCode)
        {
            Rates rate = new Rates();
            return rate;
        }

        public async Task<TaxedOrder> GetTaxes(Order order)
        {
            TaxedOrder taxedOrder = new TaxedOrder();
            return taxedOrder;
        }
    }
}
