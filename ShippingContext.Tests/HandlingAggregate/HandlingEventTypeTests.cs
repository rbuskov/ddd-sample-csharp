using ShippingContext.HandlingAggregate;
using Xunit;

namespace ShippingContext.Tests.HandlingAggregate
{
    public class HandlingEventTypeTests
    {
        [Theory]
        [InlineData(HandlingEventType.Claim, false)]
        [InlineData(HandlingEventType.Customs, false)]
        [InlineData(HandlingEventType.Receive, false)]
        [InlineData(HandlingEventType.Load, true)]
        [InlineData(HandlingEventType.Unload, true)]
        public void RequiresVoyage(HandlingEventType type, bool requiresVoyage)
        {
            Assert.Equal(requiresVoyage, type.RequiresVoyage());
            Assert.NotEqual(requiresVoyage, type.ProhibitsVoyage());
        }
    }
}