using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class AndSpecificationTests
    {
        private NeverSatisfiedSpecification neverSatisfied = new NeverSatisfiedSpecification();
        private AlwaysSatisfiedSpecification alwaysSatisfied = new AlwaysSatisfiedSpecification();

        private object obj = new object(); 
        
        [Fact]
        public void IsSatisfied_ObjectSatisfiesBothSpecs()
        {
            var sut = new AndSpecification<object>(alwaysSatisfied, alwaysSatisfied);

            Assert.True(sut.IsSatisfiedBy(obj));
        }
        
        [Fact]
        public void IsSatisfied_ObjectSatisfiesFirstSpec()
        {
            var sut = new AndSpecification<object>(alwaysSatisfied, neverSatisfied);

            Assert.False(sut.IsSatisfiedBy(obj));
        }

        [Fact]
        public void IsSatisfied_ObjectSatisfiesSecondSpec()
        {
            var sut = new AndSpecification<object>(neverSatisfied, alwaysSatisfied);

            Assert.False(sut.IsSatisfiedBy(obj));
        }

        [Fact]
        public void IsSatisfied_ObjectSatisfiesNeitherSpec()
        {
            var sut = new AndSpecification<object>(neverSatisfied, neverSatisfied);

            Assert.False(sut.IsSatisfiedBy(obj));
        }
    }
}