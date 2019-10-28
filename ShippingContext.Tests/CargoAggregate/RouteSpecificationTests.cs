using System;
using AutoFixture;
using ShippingContext.CargoAggregate;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.CargoAggregate
{
    public class RouteSpecificationTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void CtorAndValue()
        {
            var origin = fixture.Create<Location>();
            var destination = fixture.Create<Location>();
            var arrivalDeadline = fixture.Create<DateTimeOffset>();

            var sut = new RouteSpecification(origin, destination, arrivalDeadline);
            
            Assert.Equal(origin, sut.Origin);
            Assert.Equal(destination, sut.Destination);
            Assert.Equal(arrivalDeadline, sut.ArrivalDeadline);
        }

        [Fact]
        public void IsSatisfiedBy_ItinerarySatisfiesSpecification()
        {
            var legs = fixture.CreateMany<Leg>();
            var itinerary = new Itinerary(new ValueList<Leg>(legs));

            var sut = new RouteSpecification(
                itinerary.InitialDepartureLocation,
                itinerary.FinalArrivalLocation,
                itinerary.FinalArrivalDate.AddDays(1));
            
            Assert.True(sut.IsSatisfiedBy(itinerary));
        }
        
        [Fact]
        public void IsSatisfiedBy_DepartureLocationNotSatisfied()
        {
            var legs = fixture.CreateMany<Leg>();
            var itinerary = new Itinerary(new ValueList<Leg>(legs));

            var sut = new RouteSpecification(
                fixture.Create<Location>(),
                itinerary.FinalArrivalLocation,
                itinerary.FinalArrivalDate.AddDays(1));
            
            Assert.False(sut.IsSatisfiedBy(itinerary));
        }
        
        [Fact]
        public void IsSatisfiedBy_ArrivalLocationNotSatisfied()
        {
            var legs = fixture.CreateMany<Leg>();
            var itinerary = new Itinerary(new ValueList<Leg>(legs));

            var sut = new RouteSpecification(
                itinerary.InitialDepartureLocation,
                fixture.Create<Location>(),
                itinerary.FinalArrivalDate.AddDays(1));
            
            Assert.False(sut.IsSatisfiedBy(itinerary));
        }
        
        [Fact]
        public void IsSatisfiedBy_ArrivalDateNotSatisfied()
        {
            var legs = fixture.CreateMany<Leg>();
            var itinerary = new Itinerary(new ValueList<Leg>(legs));

            var sut = new RouteSpecification(
                itinerary.InitialDepartureLocation,
                itinerary.FinalArrivalLocation,
                itinerary.FinalArrivalDate);
            
            Assert.False(sut.IsSatisfiedBy(itinerary));
        }
    }
}