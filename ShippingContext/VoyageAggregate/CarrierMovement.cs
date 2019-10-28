using System;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class CarrierMovement : ValueObject<(Location departureLocation, Location arrivalLocation, DateTimeOffset departureTime, DateTimeOffset arrivalTime)>
    {
        public CarrierMovement(
            Location departureLocation, 
            Location arrivalLocation, 
            DateTimeOffset departureTime, 
            DateTimeOffset arrivalTime) 
            : base((departureLocation, arrivalLocation, departureTime, arrivalTime))
        {
        }

        public Location DepartureLocation => Value.departureLocation;
        public Location ArrivalLocation => Value.arrivalLocation;
        public DateTimeOffset DepartureTime => Value.departureTime;
        public DateTimeOffset ArrivalTime => Value.arrivalTime;

        public static readonly CarrierMovement None = new CarrierMovement(Location.Unknown, Location.Unknown, DateTimeOffset.MinValue, DateTimeOffset.MinValue);
    }
}