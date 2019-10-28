using AutoFixture;
using ShippingContext.CargoAggregate;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.CargoAggregate
{
    public class TrackingIdTests
    {
        private Fixture fixture = new ShippingFixture();

        [Fact]
        public void CtorAndValueProperty()
        {
            var value = fixture.Create<string>();
            var sut = new TrackingId(value);

            Assert.Equal(value, sut.Value);
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal(string.Empty, TrackingId.Empty.Value);
        }

        [Fact]
        public void Ctor_EmptyValue()
        {
            Assert.Throws<DomainException>(() => new TrackingId(string.Empty));
        }
    }
}