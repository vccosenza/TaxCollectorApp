using Realms;
using System.Collections.Generic;

namespace TaxCalculatorApp.Models
{
    public class Order 
    {
        public decimal Amount { get; set; }
        public decimal Shipping { get; set; }
        public string To_Country { get; set; }
        public string To_Zip { get; set; }
        public string From_Zip { get; set; }
        public string From_Country { get; set; }
        public string From_State { get; set; }
        public string To_State { get; set; }
        public IList<NexusAddresses> Nexus_Addresses { get; set; } 
    }
    public class OrderAmount : RealmObject
    {
        public decimal Amount { get; set; }
        public decimal Shipping { get; set; }
    }
    public class TaxedOrder : RealmObject
    {
        public decimal Order_Total_Amount { get; set; }
        public decimal Shipping { get; set; }
        public decimal Taxable_Amount { get; set; }
        public decimal Amount_To_Collect { get; set; }
        public decimal Rate { get; set; }
        public bool Has_Nexus { get; set; }
    }

    public class Taxes
    {
        public TaxedOrder Tax { get; set; }
    }
}
