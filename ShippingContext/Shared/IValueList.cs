using System.Collections.Generic;

namespace ShippingContext.Shared
{
    public interface IValueList<T> : IList<T>, IValueObject
        where T : notnull
    {}
}