using System;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class Leg : ValueObject<(Voyage voyage, Location loadLocation, Location unloadLocation, DateTimeOffset loadTime, DateTimeOffset unloadTime)>
    {
        public Leg(
            Voyage voyage, 
            Location loadLocation, 
            Location unloadLocation, 
            DateTimeOffset loadTime, 
            DateTimeOffset unloadTime) 
            : base((voyage, loadLocation, unloadLocation, loadTime, unloadTime))
        {
            // todo: guard clauses
        }

        public Voyage Voyage => Value.voyage;
        public Location LoadLocation => Value.loadLocation;
        public Location UnloadLocation => Value.unloadLocation;
        public DateTimeOffset LoadTime => Value.loadTime;
        public DateTimeOffset UnloadTime => Value.unloadTime;
    }
}