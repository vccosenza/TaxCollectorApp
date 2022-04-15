using System.Threading.Tasks;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Services
{
    public interface ITaxService
    {
        Task<Rates> GetRates(string zipCode);
        Task<TaxedOrder> GetTaxes(Order order);
    }
}
