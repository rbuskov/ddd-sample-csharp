using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class NotSpecificationTests
    {
        private NeverSatisfiedSpecification neverSatisfied = new NeverSatisfiedSpecification();
        private AlwaysSatisfiedSpecification alwaysSatisfied = new AlwaysSatisfiedSpecification();

        private object obj = new object(); 
        
        [Fact]
        public void IsSatisfied_ObjectSatisfiesSpec()
        {
            var sut = new NotSpecification<object>(alwaysSatisfied);

            Assert.False(sut.IsSatisfiedBy(obj));
        }
        
        [Fact]
        public void IsSatisfied_ObjectDoesNotSatisfySpec()
        {
            var sut = new NotSpecification<object>(neverSatisfied);

            Assert.True(sut.IsSatisfiedBy(obj));
        }
    }
}