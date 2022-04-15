using TaxCalculatorApp.Models;
using Realms;
using System.Collections.Generic;

namespace TaxCalculatorApp.Services
{
    public interface IDbService
    {
        bool SaveOrder(OrderAmount order);
        bool SaveLocation(Location location);
        bool SaveTaxedOrder(TaxedOrder order);
        OrderAmount GetOrder();
        Location GetLocation();
        TaxedOrder GetTaxedOrder();
    }
}
