using System;

namespace ShippingContext.CargoAggregate
{
    // Root of the Cargo aggregate
    public class Cargo
    {
        public Cargo(TrackingId trackingId)
        {
            TrackingId = trackingId;
        }

        public RouteSpecification? RouteSpecification { get; private set; }

        public TrackingId TrackingId { get; }

        public void SpecifyNewRoute(RouteSpecification routeSpecification)
        {
            RouteSpecification = routeSpecification ?? throw new ArgumentNullException(nameof(routeSpecification));

            // Handling consistency within the Cargo aggregate synchronously
            //this.delivery = delivery.updateOnRouting(this.routeSpecification, this.itinerary);
        }
        
        public static readonly Cargo Empty = new Cargo(TrackingId.Empty);
    }
}