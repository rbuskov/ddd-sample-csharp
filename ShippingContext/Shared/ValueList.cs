using System.Collections.Generic;
using System.Linq;

namespace ShippingContext.Shared
{
    public class ValueList<T> : List<T>, IValueList<T>
        where T : notnull
    {
        public ValueList()
        {}
        
        public ValueList(IEnumerable<T> collection)
            : base(collection)
        {}
        
        public override bool Equals(object? other)
        {
            return GetType() == other?.GetType() 
                   &&Equals(other as ValueList<T>);
        }

        protected bool Equals(ValueList<T>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return this.SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ValueList<T>? left, ValueList<T>? right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueList<T>? left, ValueList<T>? right)
        {
            return !(left == right);
        }
    }
}