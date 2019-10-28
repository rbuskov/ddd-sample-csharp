namespace ShippingContext.Shared
{
    public abstract class ValueObject<T> : IValueObject
         where T : notnull
    {
        protected ValueObject(T value)
        {
            Value = value;
        }

        protected T Value { get; }

        public override bool Equals(object? other)
        {
            return other?.GetType() == GetType() 
                   && Equals(other as ValueObject<T>);
        }

        protected bool Equals(ValueObject<T>? other)
        {
            return other != null 
                   && ObjectComparer.AreEqual(Value, other.Value);
        }

        public override int GetHashCode() 
        {
            return Value.GetHashCode();
        }

        public override string? ToString()
        {
            return Value.ToString();
        }

        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
        {
            return ObjectComparer.AreEqual(left, right);
        }
        
        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
        {
            return !(left == right);
        }
    }
}