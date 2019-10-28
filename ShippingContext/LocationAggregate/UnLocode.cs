using System.Text.RegularExpressions;
using ShippingContext.Shared;

namespace ShippingContext.LocationAggregate
{
    public class UnLocode : ValueObject<string>
    {
        public UnLocode(string countryAndLocation) 
            : base(countryAndLocation.ToUpper())
        {
            Guard.Check(nameof(countryAndLocation), countryAndLocation, new Regex("^[a-zA-Z]{2}[a-zA-Z2-9]{3}$"));
        }
        
        public string CountryAndLocation => Value;
        
        public static readonly UnLocode Empty = new UnLocode("XXXXX");
    }
}
