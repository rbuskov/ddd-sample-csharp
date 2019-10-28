using System;
using System.Linq;
using AutoFixture;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.VoyageAggregate
{
    public class VoyageBuilderTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void Build_NoMovements()
        {
            var voyageNumber = fixture.Create<VoyageNumber>();
            var departureLocation = fixture.Create<Location>();
            
            var sut = new VoyageBuilder(voyageNumber, departureLocation);

            Assert.Throws<DomainException>(() => sut.Build());
        }
        
        [Fact]
        public void Build()
        {
            var voyageNumber = fixture.Create<VoyageNumber>();
            
            var locations = fixture
                .CreateMany<Location>(3)
                .ToList();
            
            var times = fixture
                .CreateMany<DateTimeOffset>(4)
                .ToList();
            
            var sut = new VoyageBuilder(voyageNumber, locations[0]);
            sut.AddMovement(locations[1], times[0], times[1]);
            sut.AddMovement(locations[2], times[2], times[3]);
            
            var voyage = sut.Build();

            Assert.Equal(voyageNumber, voyage.Number);
            Assert.NotNull(voyage.Schedule);

            Assert.Collection(voyage.Schedule.CarrierMovements,
                cm =>
                {
                    Assert.Equal(locations[0], cm.DepartureLocation);
                    Assert.Equal(locations[1], cm.ArrivalLocation);
                    Assert.Equal(times[0], cm.DepartureTime);
                    Assert.Equal(times[1], cm.ArrivalTime);
                },
                cm =>
                {
                    Assert.Equal(locations[1], cm.DepartureLocation);
                    Assert.Equal(locations[2], cm.ArrivalLocation);
                    Assert.Equal(times[2], cm.DepartureTime);
                    Assert.Equal(times[3], cm.ArrivalTime);
                });
        }
    }
}