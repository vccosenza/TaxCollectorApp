using System.Threading.Tasks;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Services
{
    public interface ITaxCollector
    {
        Task<Rates> GetRates(string zipCode);
        Task<TaxedOrder> GetTaxes(Order order);
    }
}
