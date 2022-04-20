using System.Collections.Generic;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Settings
{
    public class MockNexusData
    {
        public MockNexusData()
        {
            NexusAddresses = nexusAddresses;
        }
        List<NexusAddresses> nexusAddresses = new List<NexusAddresses>()
        {
           new NexusAddresses{Id = "Alabama", City = "Montgomery", Country = "US", Zip = "36101",State = "AL"},
           new NexusAddresses{Id = "Alaska", City = "Juneau", Country = "US", Zip = "99801",State = "AK"},
           new NexusAddresses{Id = "Arizona", City = "Pheonix", Country = "US", Zip = "85001", State = "AZ"},
           new NexusAddresses{Id = "Arkansas", City = "Little Rock", Country = "US", Zip = "72201", State = "AR" },
           new NexusAddresses{Id = "California", City = "Sacramento", Country = "US", Zip = "94203", State = "CA" },
           new NexusAddresses{Id = "Colorado", City = "Dever", Country = "US", Zip = "80201", State = "CO"},
           new NexusAddresses{Id = "Connecticut", City = "Hartford", Country = "US", Zip = "06101", State = "CT"},
           new NexusAddresses{Id = "Delaware", City = "Dover", Country = "US", Zip = "19901", State = "DE"},
           new NexusAddresses{Id = "Florida", City = "Tallahassee", Country = "US", Zip = "32301", State = "FL"},
           new NexusAddresses{Id = "Georgia", City = "Atlanta", Country = "US", Zip = "30301", State = "GA"},
           new NexusAddresses{Id = "Hawaii", City = "Honolulu", Country = "US", Zip = "96801", State = "HI"},
           new NexusAddresses{Id = "Idaho", City = "Boise", Country = "US", Zip = "83701", State = "ID"},
           new NexusAddresses{Id = "Illinois", City = "Springfield", Country = "US", Zip = "62701", State = "IL"},
           new NexusAddresses{Id = "Indiana", City = "Indianapolis", Country = "US", Zip = "46201", State = "IN"},
           new NexusAddresses{Id = "Iowa", City = "Des Moines", Country = "US", Zip = "50301", State = "IA"},
           new NexusAddresses{Id = "Kansas", City = "Topeka", Country = "US", Zip = "66601", State = "KS"},
           new NexusAddresses{Id = "Kentucky", City = "Frankfort", Country = "US", Zip = "40601", State = "KY"},
           new NexusAddresses{Id = "Louisiana", City = "Baton Rouge", Country = "US", Zip = "70801", State = "LA"},
           new NexusAddresses{Id = "Maine", City = "Augusta", Country = "US", Zip = "04330", State = "ME"},
           new NexusAddresses{Id = "Maryland", City = "Annapolis", Country = "US", Zip = "21401", State = "MD"},
           new NexusAddresses{Id = "Massachusetts", City = "Boston", Country = "US", Zip = "02108", State = "MA"},
           new NexusAddresses{Id = "Michigan", City = "Lansing", Country = "US", Zip = "48901", State = "MI"},
           new NexusAddresses{Id = "Minnesota", City = "St. Paul", Country = "US", Zip = "55101", State = "MN"},
           new NexusAddresses{Id = "Mississippi", City = "Jackson", Country = "US", Zip = "39201", State = "MS"},
           new NexusAddresses{Id = "Missouri", City = "Jefferson City", Country = "US", Zip = "65101", State = "MO"},
           new NexusAddresses{Id = "Montana", City = "Helena", Country = "US", Zip = "59601", State = "MT"},
           new NexusAddresses{Id = "Nebraska", City = "Lincoln", Country = "US", Zip = "68501", State = "NE"},
           new NexusAddresses{Id = "Nevada", City = "Carson City", Country = "US", Zip = "89701", State = "NV"},
           new NexusAddresses{Id = "New Hampshire", City = "Concord", Country = "US", Zip = "03301", State = "NH"},
           new NexusAddresses{Id = "New Jersey", City = "Trenton", Country = "US", Zip = "08601", State = "NJ"},
           new NexusAddresses{Id = "New Mexico", City = "Santa Fe", Country = "US", Zip = "87501", State = "NM"},
           new NexusAddresses{Id = "New York", City = "Albany", Country = "US", Zip = "12201", State = "NY"},
           new NexusAddresses{Id = "North Carolina", City = "Raleigh", Country = "US", Zip = "27601", State = "NC"},
           new NexusAddresses{Id = "North Dakota", City = "Bismark", Country = "US", Zip = "58501", State = "ND"},
           new NexusAddresses{Id = "Ohio", City = "Columbus", Country = "US", Zip = "43201", State = "OH"},
           new NexusAddresses{Id = "Oklahoma", City = "Oklahoma City", Country = "US", Zip = "73101", State = "OK"},
           new NexusAddresses{Id = "Oregon", City = "Salem", Country = "US", Zip = "97301", State = "OR"},
           new NexusAddresses{Id = "Pennsylvania", City = "Harrisburg", Country = "US", Zip = "17101", State = "PA"},
           new NexusAddresses{Id = "Rhode Island", City = "Providence", Country = "US", Zip = "02901", State = "RI"},
           new NexusAddresses{Id = "South Carolina", City = "Columbia", Country = "US", Zip = "29201", State = "SC"},
           new NexusAddresses{Id = "South Dakota", City = "Pierre", Country = "US", Zip = "57501", State = "SD"},
           new NexusAddresses{Id = "Tennessee", City = "Nashville", Country = "US", Zip = "37201", State = "TN"},
           new NexusAddresses{Id = "Texas", City = "Austin", Country = "US", Zip = "73301", State = "TX"},
           new NexusAddresses{Id = "Utah", City = "Salt Lake City", Country = "US", Zip = "84101", State = "UT"},
           new NexusAddresses{Id = "Vermont", City = "Montpelier", Country = "US", Zip = "05601", State = "VT"},
           new NexusAddresses{Id = "Virginia", City = "Richmond", Country = "US", Zip = "23218", State = "VA"},
           new NexusAddresses{Id = "Washington", City = "Olympia", Country = "US", Zip = "98501", State = "WA"},
           new NexusAddresses{Id = "West Virginia", City = "Charleston", Country = "US", Zip = "25301", State = "WV"},
           new NexusAddresses{Id = "Wisconsin", City = "Madison", Country = "US", Zip = "53701", State = "WI"},
           new NexusAddresses{Id = "Wyoming", City = "Cheyenne", Country = "US", Zip = "82001", State = "WY"},
        };
        
        public List<NexusAddresses> NexusAddresses { get; set; }
        
    }
}
