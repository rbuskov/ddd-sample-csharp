using System;
using ShippingContext.CargoAggregate;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;

namespace ShippingContext.HandlingAggregate
{
    // Root of the Handling aggregate
    public class HandlingEvent : ValueObject<(Cargo cargo, DateTimeOffset completionTime, DateTimeOffset registrationTime, HandlingEventType type, Location location, Voyage voyage)>, 
        IDomainEvent
    {
        public HandlingEvent(
            Cargo cargo, 
            DateTimeOffset completionTime, 
            DateTimeOffset registrationTime, 
            HandlingEventType type, 
            Location location, 
            Voyage voyage) 
            : base((cargo, completionTime, registrationTime, type, location, voyage))
        {
            if (Type.ProhibitsVoyage())
                throw new DomainException("Voyage is not allowed with event type " + Type.ToString());
        }
        
        public HandlingEvent(
            Cargo cargo, 
            DateTimeOffset completionTime, 
            DateTimeOffset registrationTime, 
            HandlingEventType type, 
            Location location) 
            : base((cargo, completionTime, registrationTime, type, location, Voyage.Empty))
        {
            if (Type.RequiresVoyage())
                throw new DomainException("Voyage is required with event type " + Type.ToString());
        }
        
        public Cargo Cargo => Value.cargo;
        public DateTimeOffset CompletionTime => Value.completionTime;
        public DateTimeOffset RegistrationTime => Value.registrationTime;
        public HandlingEventType Type => Value.type;
        public Location Location => Value.location;
        public Voyage Voyage => Value.voyage;
    }
}