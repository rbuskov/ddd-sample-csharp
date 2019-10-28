namespace ShippingContext.HandlingAggregate
{
    public static class HandlingEventTypeMethods
    {
        public static bool RequiresVoyage(this HandlingEventType type)
        {
            return type == HandlingEventType.Load || type == HandlingEventType.Unload;
        }
        
        public static bool ProhibitsVoyage(this HandlingEventType type)
        {
            return !RequiresVoyage(type);
        }
    }
}