using System;
using System.Linq;
using AutoFixture;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.VoyageAggregate
{
    public class ItineraryTests
    {
        private readonly Fixture fixture = new ShippingFixture();
        private readonly ValueList<Leg> legs = new ValueList<Leg>();
        
        public ItineraryTests()
        {
            legs.AddRange(fixture.CreateMany<Leg>());
        }
        
        [Fact]
        public void CtorAndValue()
        {
            var sut = new Itinerary(legs);
            Assert.Equal(legs, sut.Legs);
        }

        [Fact]
        public void InitialDepartureLocation()
        {
            var sut = new Itinerary(legs);
            Assert.Equal(legs.First().LoadLocation, sut.InitialDepartureLocation);
        }

        [Fact]
        public void InitialDepartureLocation_Unknown()
        {
            var sut = Itinerary.Empty;
            Assert.Equal(Location.Unknown, sut.InitialDepartureLocation);
        }

        [Fact]
        public void FinalArrivalLocation()
        {
            var sut = new Itinerary(legs);            
            Assert.Equal(legs.Last().UnloadLocation, sut.FinalArrivalLocation);
        }

        [Fact]
        public void FinalArrivalLocation_Unknown()
        {
            var sut = Itinerary.Empty;
            Assert.Equal(Location.Unknown, sut.InitialDepartureLocation);
        }

        [Fact]
        public void FinalArrivalDate()
        {
            var sut = new Itinerary(legs);            
            Assert.Equal(legs.Last().UnloadTime, sut.FinalArrivalDate);
        }
        
        [Fact]
        public void FinalArrivalDate_Unknown()
        {
            var sut = Itinerary.Empty;
            Assert.Equal(DateTimeOffset.MaxValue, sut.FinalArrivalDate);
        }
    }
}