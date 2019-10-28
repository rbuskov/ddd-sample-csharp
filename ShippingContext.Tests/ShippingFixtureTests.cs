using AutoFixture;
using ShippingContext.CargoAggregate;
using ShippingContext.HandlingAggregate;
using ShippingContext.LocationAggregate;
using Xunit;

namespace ShippingContext.Tests
{
    public class ShippingFixtureTests
    {
        [Fact]
        public void Create()
        {
            var sut = new ShippingFixture();

            var trackingId = sut.Create<TrackingId>();
            var cargo = sut.Create<Cargo>();
            var handlingEvent = sut.Create<HandlingEvent>();
        }

        [Fact]
        public void CreateUnLocode()
        {
            var sut = new ShippingFixture();

            for (int i = 0; i < 23; i++)
            {
                var locode = sut.Create<UnLocode>();
                
                if (i == 0)
                    Assert.Equal("AAAAA", locode.CountryAndLocation);
                if (i == 24)
                    Assert.Equal("ZAAAA", locode.CountryAndLocation);
                if (i == 25)
                    Assert.Equal("ABAAA", locode.CountryAndLocation);
            }
        }
    }
}