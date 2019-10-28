using System;
using AutoFixture;
using ShippingContext.LocationAggregate;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.VoyageAggregate
{
    public class CarrierMovementTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void CtorAndValue()
        {
            var departureLocation = fixture.Create<Location>();
            var arrivalLocation = fixture.Create<Location>();
            var departureTime = fixture.Create<DateTimeOffset>();
            var arrivalTime = fixture.Create<DateTimeOffset>();
                
            var sut = new CarrierMovement(departureLocation, arrivalLocation, departureTime, arrivalTime);
            
            Assert.Equal(departureLocation, sut.DepartureLocation);
            Assert.Equal(arrivalLocation, sut.ArrivalLocation);
            Assert.Equal(departureTime, sut.DepartureTime);
            Assert.Equal(arrivalTime, sut.ArrivalTime);
        }

        [Fact]
        public void None()
        {
            Assert.Equal(Location.Unknown, CarrierMovement.None.DepartureLocation);
            Assert.Equal(Location.Unknown, CarrierMovement.None.ArrivalLocation);
            Assert.Equal(DateTimeOffset.MinValue, CarrierMovement.None.DepartureTime);
            Assert.Equal(DateTimeOffset.MinValue, CarrierMovement.None.ArrivalTime);
        }
    }
}