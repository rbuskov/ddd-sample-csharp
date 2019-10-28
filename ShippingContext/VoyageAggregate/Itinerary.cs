using System;
using System.Collections.ObjectModel;
using System.Linq;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class Itinerary : ValueObject<IValueList<Leg>>
    {
        public Itinerary(IValueList<Leg> legs) : base(legs)
        {
            // check not empty
        }
        
        private Itinerary()
            : base(new ValueList<Leg>())
        {}

        public ReadOnlyCollection<Leg> Legs => new ReadOnlyCollection<Leg>(Value);

        public Location InitialDepartureLocation 
            => Legs.Any()
                ? Legs.First().LoadLocation
                : Location.Unknown;

        public Location FinalArrivalLocation
            => Legs.Any()
                ? Legs.Last().UnloadLocation
                : Location.Unknown;

        public DateTimeOffset FinalArrivalDate
            => Legs.Any()
                ? Legs.Last().UnloadTime
                : DateTimeOffset.MaxValue;
        
//        public boolean isExpected(final HandlingEvent event) {
//            if (legs.isEmpty()) {
//                return true;
//            }
//
//            if (event.type() == HandlingEvent.Type.RECEIVE) {
//                //Check that the first leg's origin is the event's location
//                final Leg leg = legs.get(0);
//                return (leg.loadLocation().equals(event.location()));
//            }
//
//            if (event.type() == HandlingEvent.Type.LOAD) {
//                //Check that the there is one leg with same load location and voyage
//                for (Leg leg : legs) {
//                    if (leg.loadLocation().sameIdentityAs(event.location()) &&
//                    leg.voyage().sameIdentityAs(event.voyage()))
//                    return true;
//                }
//                return false;
//            }
//
//            if (event.type() == HandlingEvent.Type.UNLOAD) {
//                //Check that the there is one leg with same unload location and voyage
//                for (Leg leg : legs) {
//                    if (leg.unloadLocation().equals(event.location()) &&
//                    leg.voyage().equals(event.voyage()))
//                    return true;
//                }
//                return false;
//            }
//
//            if (event.type() == HandlingEvent.Type.CLAIM) {
//                //Check that the last leg's destination is from the event's location
//                final Leg leg = lastLeg();
//                return (leg.unloadLocation().equals(event.location()));
//            }
//
//            //HandlingEvent.Type.CUSTOMS;
//            return true;
//        }

        public static readonly Itinerary Empty = new Itinerary();
    }
}