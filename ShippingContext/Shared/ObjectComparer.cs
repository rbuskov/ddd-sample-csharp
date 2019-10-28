namespace ShippingContext.Shared
{
    public static class ObjectComparer
    {
        public static bool AreEqual(object? left, object? right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.GetType() == right.GetType()
                   && left.Equals(right);
        }
    }
}