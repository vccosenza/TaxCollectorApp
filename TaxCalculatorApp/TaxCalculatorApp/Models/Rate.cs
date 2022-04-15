namespace TaxCalculatorApp.Models
{
    public class Rate
    {
        public string City { get; set; }
        public decimal City_Rate { get; set; }
        public string Combined_District_Rate { get; set; }
        public string Combined_Rate { get; set; }
        public string Country { get; set; }
        public decimal Country_Rate { get; set; }
        public string County { get; set; }
        public decimal County_Rate { get; set; }
        public bool Freight_Taxable { get; set; }
        public string State { get; set; }
        public decimal State_Rate { get; set; }
        public string Zip { get; set; }
    }

    public class Rates
    {
        public Rate Rate { get; set; }
    }
}
