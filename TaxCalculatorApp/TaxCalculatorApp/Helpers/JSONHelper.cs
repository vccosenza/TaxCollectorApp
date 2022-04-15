using Newtonsoft.Json.Serialization;

namespace TaxCalculatorApp.Helpers
{
    public class JSONHelper : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
