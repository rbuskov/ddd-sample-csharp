using System;
using AutoFixture;
using ShippingContext.LocationAggregate;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.VoyageAggregate
{
    public class LegTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void CtorAndValue()
        {
            var voyage = fixture.Create<Voyage>();
            var loadLocation = fixture.Create<Location>();
            var unloadLocation = fixture.Create<Location>();
            var loadTime = fixture.Create<DateTimeOffset>();
            var unloadTime = fixture.Create<DateTimeOffset>();
            
            var sut = new Leg(voyage, loadLocation, unloadLocation, loadTime, unloadTime);
            
            Assert.Equal(voyage, sut.Voyage);
            Assert.Equal(loadLocation, sut.LoadLocation);
            Assert.Equal(unloadLocation, sut.UnloadLocation);
            Assert.Equal(loadTime, sut.LoadTime);
            Assert.Equal(unloadTime, sut.UnloadTime);
        }
    }
}