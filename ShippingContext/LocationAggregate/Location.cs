using ShippingContext.Shared;

namespace ShippingContext.LocationAggregate
{
    // Root of the Location aggregate
    public class Location : Entity<UnLocode>
    {
        public Location(UnLocode unLocode, string name)
            : base(unLocode)
        {
            Guard.CheckNotEmpty(nameof(name), name);

            Name = name;
        }

        public UnLocode UnLocode => base.Id;
        public string Name { get; }

        public static readonly Location Unknown = new Location(UnLocode.Empty, "Unknown location");
    }
}
