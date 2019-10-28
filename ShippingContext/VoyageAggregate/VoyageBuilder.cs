using System;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class VoyageBuilder
    {
        private readonly ValueList<CarrierMovement> carrierMovements = new ValueList<CarrierMovement>();
        private readonly VoyageNumber voyageNumber;
        private Location departureLocation;

        public VoyageBuilder(VoyageNumber voyageNumber, Location departureLocation) {
            this.voyageNumber = voyageNumber;
            this.departureLocation = departureLocation;
        }

        public VoyageBuilder AddMovement(Location arrivalLocation, DateTimeOffset departureTime, DateTimeOffset arrivalTime) {
            carrierMovements.Add(new CarrierMovement(departureLocation, arrivalLocation, departureTime, arrivalTime));
            // Next departure location is the same as this arrival location
            this.departureLocation = arrivalLocation;
            return this;
        }

        public Voyage Build() {
            return new Voyage(voyageNumber, new Schedule(carrierMovements));
        }
    }
}