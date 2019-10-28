using System.Collections.ObjectModel;
using ShippingContext.Shared;

namespace ShippingContext.VoyageAggregate
{
    public class Schedule : ValueObject<IValueList<CarrierMovement>>
    {
        public Schedule(IValueList<CarrierMovement> carrierMovements) : base(carrierMovements)
        {
            Guard.CheckNotEmpty(nameof(carrierMovements), carrierMovements);
        }
        
        public Schedule()
            : base(new ValueList<CarrierMovement>())
        {}

        public ReadOnlyCollection<CarrierMovement> CarrierMovements => new ReadOnlyCollection<CarrierMovement>(Value);

        public static readonly Schedule Empty = new Schedule();
    }
}