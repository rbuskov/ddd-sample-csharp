using System;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    // Root of the Voyage aggregate
    public class Voyage : Entity<VoyageNumber>
    {
        public VoyageNumber Number => Id;
        public  Schedule Schedule { get; }

        public Voyage(VoyageNumber id, Schedule schedule) : base(id)
        {
            Schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
        }
        
        public static readonly Voyage Empty = new Voyage(VoyageNumber.Empty, Schedule.Empty);
        
//        /**
//   * Builder pattern is used for incremental construction
//   * of a Voyage aggregate. This serves as an aggregate factory. 
//   */
//        public static final class Builder {
//
//            private final List<CarrierMovement> carrierMovements = new ArrayList<CarrierMovement>();
//            private final VoyageNumber voyageNumber;
//            private Location departureLocation;
//
//            public Builder(final VoyageNumber voyageNumber, final Location departureLocation) {
//                Validate.notNull(voyageNumber, "Voyage number is required");
//                Validate.notNull(departureLocation, "Departure location is required");
//
//                this.voyageNumber = voyageNumber;
//                this.departureLocation = departureLocation;
//            }
//
//            public Builder addMovement(Location arrivalLocation, Date departureTime, Date arrivalTime) {
//                carrierMovements.add(new CarrierMovement(departureLocation, arrivalLocation, departureTime, arrivalTime));
//                // Next departure location is the same as this arrival location
//                this.departureLocation = arrivalLocation;
//                return this;
//            }
//
//            public Voyage build() {
//                return new Voyage(voyageNumber, new Schedule(carrierMovements));
//            }
//
//        }
    }
}