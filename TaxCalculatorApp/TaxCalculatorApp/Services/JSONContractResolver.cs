using Newtonsoft.Json.Serialization;

namespace TaxCalculatorApp.Services
{
    public class JSONContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
