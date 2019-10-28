using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class VoyageNumber : ValueObject<string>
    {
        public string Number => Value;
                
        public VoyageNumber(string number) : base(number)
        {}
        
        public static readonly VoyageNumber Empty = new VoyageNumber("");
    }
}