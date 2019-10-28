using AutoFixture;
using ShippingContext.CargoAggregate;
using Xunit;

namespace ShippingContext.Tests.CargoAggregate
{
    public class CargoTests
    {
        private Fixture fixture = new ShippingFixture();

        [Fact]
        public void CtorAndValue()
        {
            var trackingId = fixture.Create<TrackingId>();
            
            var sut = new Cargo(trackingId);
            
            Assert.Equal(trackingId, sut.TrackingId);
        }
    }
}