using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class OrSpecificationTests
    {
        private NeverSatisfiedSpecification neverSatisfied = new NeverSatisfiedSpecification();
        private AlwaysSatisfiedSpecification alwaysSatisfied = new AlwaysSatisfiedSpecification();

        private object obj = new object(); 
        
        [Fact]
        public void IsSatisfied_ObjectSatisfiesBothSpecs()
        {
            var sut = new OrSpecification<object>(alwaysSatisfied, alwaysSatisfied);

            Assert.True(sut.IsSatisfiedBy(obj));
        }
        
        [Fact]
        public void IsSatisfied_ObjectSatisfiesFirstSpec()
        {
            var sut = new OrSpecification<object>(alwaysSatisfied, neverSatisfied);

            Assert.True(sut.IsSatisfiedBy(obj));
        }

        [Fact]
        public void IsSatisfied_ObjectSatisfiesSecondSpec()
        {
            var sut = new OrSpecification<object>(neverSatisfied, alwaysSatisfied);

            Assert.True(sut.IsSatisfiedBy(obj));
        }

        [Fact]
        public void IsSatisfied_ObjectSatisfiesNeitherSpec()
        {
            var sut = new OrSpecification<object>(neverSatisfied, neverSatisfied);

            Assert.False(sut.IsSatisfiedBy(obj));
        }
    }
}