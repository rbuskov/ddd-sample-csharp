using System.Collections.Generic;

namespace ShippingContext.CargoAggregate
{
    public interface CargoRepository
    {
        Cargo Find(TrackingId trackingId);
        IList<Cargo> FindAll();

        void Store(Cargo cargo);

        TrackingId NextTrackingId();
    }
}
