using ShippingContext.Shared;

namespace ShippingContext.CargoAggregate
{
    public class TrackingId : ValueObject<string>
    {
        public TrackingId(string value)
            : base(value)
        {
            Guard.CheckNotEmpty(nameof(value), value);
        }

        public TrackingId()
            : base(string.Empty)
        {}

        public new string Value => base.Value;

        public static readonly TrackingId Empty = new TrackingId();
    }
}