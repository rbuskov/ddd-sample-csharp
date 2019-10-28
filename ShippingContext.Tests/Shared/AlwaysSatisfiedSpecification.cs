using ShippingContext.Shared;

namespace ShippingContext.Tests.Shared
{
    public class AlwaysSatisfiedSpecification : ISpecification<object>
    {
        public bool IsSatisfiedBy(object obj)
        {
            return true;
        }
    }
}