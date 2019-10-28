using System;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using ShippingContext.VoyageAggregate;

namespace ShippingContext.CargoAggregate
{
    public class RouteSpecification 
        : ValueObject<(Location origin, Location destination, DateTimeOffset arrivalDeadline)>,
          ISpecification<Itinerary>
    {
        public RouteSpecification(Location origin, Location destination, DateTimeOffset arrivalDeadline)
            : base((origin, destination, arrivalDeadline))
        {}

        public Location Origin => Value.origin;
        public Location Destination => Value.destination;
        public DateTimeOffset ArrivalDeadline => Value.arrivalDeadline;

        public bool IsSatisfiedBy(Itinerary itinerary)
        {
            return itinerary != null 
                && Origin == itinerary.InitialDepartureLocation 
                && Destination == itinerary.FinalArrivalLocation 
                && ArrivalDeadline > itinerary.FinalArrivalDate;
        }
    }
}