namespace ShippingContext.Shared
{
    public abstract class Entity<T>
        where T : notnull
    {
        protected T Id { get; }

        protected Entity(T id)
        {
            Id = id;
        }

        public override bool Equals(object? other)
        {
            return Equals(other as Entity<T>);
        }

        protected virtual bool Equals(Entity<T>? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            
            return ObjectComparer.AreEqual(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string? ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(Entity<T>? left, Entity<T>? right)
        {
            return ObjectComparer.AreEqual(left, right);
        }

        public static bool operator !=(Entity<T>? left, Entity<T>? right)
        {
            return !(left == right);
        }
    }
}

