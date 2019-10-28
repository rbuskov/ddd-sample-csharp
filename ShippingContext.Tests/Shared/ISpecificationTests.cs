using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class ISpecificationTests
    {
        private readonly ISpecification<object> neverSatisfied = new NeverSatisfiedSpecification();
        private readonly  ISpecification<object> alwaysSatisfied = new AlwaysSatisfiedSpecification();
        
        private object obj = new object();

        [Fact]
        public void AndSpecification_BothSatisfied()
        {
            Assert.True(alwaysSatisfied.And(alwaysSatisfied).IsSatisfiedBy(obj));
        }
        
        [Fact]
        public void AndSpecification_SutSatisfied()
        {
            Assert.False(alwaysSatisfied.And(neverSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void AndSpecification_OtherSatisfied()
        {
            Assert.False(neverSatisfied.And(alwaysSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void AndSpecification_NeitherSatisfied()
        {
            Assert.False(neverSatisfied.And(neverSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void OrSpecification_BothSatisfied()
        {
            Assert.True(alwaysSatisfied.Or(alwaysSatisfied).IsSatisfiedBy(obj));
        }
        
        [Fact]
        public void OrSpecification_SutSatisfied()
        {
            Assert.True(alwaysSatisfied.Or(neverSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void OrSpecification_OtherSatisfied()
        {
            Assert.True(neverSatisfied.Or(alwaysSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void OrSpecification_NeitherSatisfied()
        {
            Assert.False(neverSatisfied.Or(neverSatisfied).IsSatisfiedBy(obj));
        }

        [Fact]
        public void NotSpecification_NotSatisfied()
        {
            Assert.True(neverSatisfied.Not().IsSatisfiedBy(obj));
        }

        [Fact]
        public void NotSpecification_Satisfied()
        {
            Assert.False(alwaysSatisfied.Not().IsSatisfiedBy(obj));
        }
    }
}