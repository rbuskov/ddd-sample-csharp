using System.Linq;
using AutoFixture;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;
using Xunit;

namespace ShippingContext.Tests.VoyageAggregate
{
    public class ScheduleTests
    {
        private Fixture fixture = new ShippingFixture();

        [Fact]
        public void Empty()
        {
            Assert.Empty(Schedule.Empty.CarrierMovements);
        }

        [Fact]
        public void CtorAndValue()
        {
            var movement = fixture.Create<CarrierMovement>();
            var movementList = new ValueList<CarrierMovement> { movement };
            
            var sut = new Schedule(movementList);
            
            Assert.Equal(movement, sut.CarrierMovements.SingleOrDefault());
        }
        
        [Fact]
        public void Ctor_InvalidValue()
        {
            var movementList = new ValueList<CarrierMovement>();
            
            Assert.Throws<DomainException>(() =>new Schedule(movementList));
        }
    }
}