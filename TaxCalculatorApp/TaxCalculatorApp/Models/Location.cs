using Realms;

namespace TaxCalculatorApp.Models
{
    public class Location : RealmObject
    {
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class NexusAddresses : RealmObject
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }   
        public string City { get; set; }
        public string Street { get; set; }
    }
}
