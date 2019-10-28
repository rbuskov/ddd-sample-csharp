using System.Collections.ObjectModel;
using System.Linq;
using ShippingContext.Shared;

namespace ShippingContext.HandlingAggregate
{
    public class HandlingHistory : ValueObject<IValueList<HandlingEvent>>
    {
        public HandlingHistory(IValueList<HandlingEvent> events)
            : base(events)
        {
        }

        public ReadOnlyCollection<HandlingEvent> Events =>new ReadOnlyCollection<HandlingEvent>(Value);

        public ReadOnlyCollection<HandlingEvent> DistinctEventsByCompletionTime =>
            new ReadOnlyCollection<HandlingEvent>(Events.Distinct()
                .OrderBy(e => e.CompletionTime)
                .ToList());

        public HandlingEvent? MostRecentlyCompletedEvent =>
            Value.Any()
                ? DistinctEventsByCompletionTime.Last()
                : null;
    }
}