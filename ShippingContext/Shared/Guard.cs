using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShippingContext.Shared
{
    public static class Guard
    {
        public static void Check(string propertyName, string value, Regex expression)
        {
            if (!expression.IsMatch(value))
                throw new DomainException($"Property '{ propertyName }' with value '{ value }' does not match the expression '{ expression.ToString() }'.");
        }

        public static void CheckNotEmpty(string propertyName, string value)
        {
            if (value == String.Empty)
                throw new DomainException($"Property '{ propertyName }' cannot be empty.");
        }

        public static void CheckNotEmpty<T>(string propertyName, T value, T empty) 
            where T : notnull
        {
            if (value.Equals(empty))
                throw new DomainException($"Property '{ propertyName }' cannot be empty.");
        }
        
        public static void CheckNotEmpty<T>(string propertyName, IEnumerable<T> enumerable) 
        {
            if (!enumerable.Any())
                throw new DomainException($"The enumerable '{ propertyName }' cannot be empty.");
        }

    }
}