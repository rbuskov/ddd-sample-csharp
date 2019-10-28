using System.Linq;
using AutoFixture;
using ShippingContext.HandlingAggregate;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.HandlingAggregate
{
    public class HandlingHistoryTests
    {
        private Fixture fixture = new ShippingFixture();
        
        [Fact]
        public void CtorAndValue()
        {
            var events = new ValueList<HandlingEvent>(fixture.CreateMany<HandlingEvent>());
            var sut = new HandlingHistory(events);

            Assert.Equal(events, sut.Events);
        }
        
        [Fact]
        public void MostRecentlyCompletedEvent()
        {
            var events = new ValueList<HandlingEvent>(fixture.CreateMany<HandlingEvent>());
            var sut = new HandlingHistory(events);
            
            Assert.Equal(events.OrderBy(e => e.CompletionTime).Last(), sut.MostRecentlyCompletedEvent);
        }
        
        [Fact]
        public void MostRecentlyCompletedEvent_Empty()
        {
            var events = new ValueList<HandlingEvent>();
            var sut = new HandlingHistory(events);
            
            Assert.Null(sut.MostRecentlyCompletedEvent);
        }
        
        [Fact]
        public void DistinctEventByCompletionTime()
        {
            var uniqueEvents = new ValueList<HandlingEvent>(fixture.CreateMany<HandlingEvent>());
            var duplicateEvents = new ValueList<HandlingEvent>();
            
            duplicateEvents.AddRange(uniqueEvents);
            duplicateEvents.AddRange(uniqueEvents);
            
            var sut = new HandlingHistory(duplicateEvents);
            
            Assert.Equal(uniqueEvents.OrderBy(e => e.CompletionTime), sut.DistinctEventsByCompletionTime);
        }
    }
}