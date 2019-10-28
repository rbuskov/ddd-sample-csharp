using System;
using AutoFixture;
using ShippingContext.CargoAggregate;
using ShippingContext.HandlingAggregate;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.HandlingAggregate
{
    public class HandlingEventTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void CtorAndValue_WithVoyage()
        {
            var cargo = fixture.Create<Cargo>();
            var completionTime = fixture.Create<DateTimeOffset>();
            var registrationTime = fixture.Create<DateTimeOffset>();
            var handlingEventType = HandlingEventType.Load;
            var location = fixture.Create<Location>();
            var voyage = fixture.Create<Voyage>();
            
            var sut = new HandlingEvent(cargo, completionTime, registrationTime, handlingEventType, location, voyage);
            
            Assert.Equal(cargo, sut.Cargo);
            Assert.Equal(completionTime, sut.CompletionTime);
            Assert.Equal(registrationTime, sut.RegistrationTime);
            Assert.Equal(handlingEventType, sut.Type);
            Assert.Equal(location, sut.Location);
            Assert.Equal(voyage, sut.Voyage);
        }
        
        [Fact]
        public void CtorAndValue_WithoutVoyage()
        {
            var cargo = fixture.Create<Cargo>();
            var completionTime = fixture.Create<DateTimeOffset>();
            var registrationTime = fixture.Create<DateTimeOffset>();
            var handlingEventType = HandlingEventType.Claim;
            var location = fixture.Create<Location>();
            
            var sut = new HandlingEvent(cargo, completionTime, registrationTime, handlingEventType, location);
            
            Assert.Equal(cargo, sut.Cargo);
            Assert.Equal(completionTime, sut.CompletionTime);
            Assert.Equal(registrationTime, sut.RegistrationTime);
            Assert.Equal(handlingEventType, sut.Type);
            Assert.Equal(location, sut.Location);
            Assert.Equal(Voyage.Empty, sut.Voyage);
        }

        [Theory]
        [InlineData(HandlingEventType.Load)]
        [InlineData(HandlingEventType.Unload)]
        public void Ctor_RequiredVoyageNotSupplied(HandlingEventType type)
        {
                var cargo = fixture.Create<Cargo>();
                var completionTime = fixture.Create<DateTimeOffset>();
                var registrationTime = fixture.Create<DateTimeOffset>();
                var location = fixture.Create<Location>();
            
                Assert.Throws<DomainException>(() => new HandlingEvent(cargo, completionTime, registrationTime, type, location));
        }
        
        [Theory]
        [InlineData(HandlingEventType.Claim)]
        [InlineData(HandlingEventType.Customs)]
        [InlineData(HandlingEventType.Receive)]
        public void Ctor_ProhibitedVoyageSupplied(HandlingEventType type)
        {
            var cargo = fixture.Create<Cargo>();
            var completionTime = fixture.Create<DateTimeOffset>();
            var registrationTime = fixture.Create<DateTimeOffset>();
            var location = fixture.Create<Location>();
            var voyage = fixture.Create<Voyage>();

            Assert.Throws<DomainException>(() => new HandlingEvent(cargo, completionTime, registrationTime, type, location, voyage));
        }
    }
}