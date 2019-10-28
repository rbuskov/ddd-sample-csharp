using System.Collections.Generic;

namespace ShippingContext.LocationAggregate
{
    public interface ILocationRepository
    {
        Location find(UnLocode unLocode);
        
        IList<Location> findAll();
    }
}