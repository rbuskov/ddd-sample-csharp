using ShippingContext.Shared;

namespace ShippingContext.Tests.Shared
{
    public class NeverSatisfiedSpecification : ISpecification<object>
    {
        public bool IsSatisfiedBy(object obj)
        {
            return false;
        }
    }
}