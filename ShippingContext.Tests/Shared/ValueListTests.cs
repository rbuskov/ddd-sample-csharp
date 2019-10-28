using System.Collections.Generic;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class ValueListTests
    {
        [Fact]
        public void Equals_ListAndOtherType()
        {
            var a = new ValueList<string>();
            var b = new List<object>();

            Assert.False(a.Equals(b));
        }
        
        [Fact]
        public void Equals_ListAndDerivedType()
        {
            var a = new ValueList<string>();
            var b = new StringValueList();

            Assert.False(a.Equals(b));
            Assert.False(b.Equals(a));
        }
        
        [Fact]
        public void Equals_ListAndNull()
        {
            var a = new ValueList<string>();
            var b = default(ValueList<string>);

            Assert.False(a.Equals(b));
            Assert.False(a == b);
            Assert.False(b == a);
            Assert.True(a != b);
            Assert.True(b != a);
        }
        
        [Fact]
        public void Equals_NullAndList()
        {
            var a = default(ValueList<string>);
            var b = new ValueList<string>();

            Assert.False(a == b);
            Assert.False(b == a);
            Assert.True(a != b);
            Assert.True(b != a);
        }

        [Fact]
        public void Equals_ListsWithDifferentValues()
        {
            var a = new ValueList<string> {"a"};
            var b = new ValueList<string> {"b"};

            Assert.False(a.Equals(b));
            Assert.False(a == b);
            Assert.False(b == a);
            Assert.True(a != b);
            Assert.True(b != a);
        }

        [Fact]
        public void Equals_ListsWithDifferentNumberOfValues()
        {
            var a = new ValueList<string> {"a"};
            var b = new ValueList<string> {"a, a"};

            Assert.False(a.Equals(b));
            Assert.False(a == b);
            Assert.False(b == a);
            Assert.True(a != b);
            Assert.True(b != a);
        }
        
        [Fact]
        public void Equals_ListsWithSameValues()
        {
            var a = new ValueList<string> {"a"};
            var b = new ValueList<string> {"a"};

            Assert.True(a.Equals(b));
            Assert.True(a.Equals(b));
            Assert.True(a == b);
            Assert.True(b == a);
            Assert.False(a != b);
            Assert.False(b != a);
        }
        
        [Fact]
        public void Equals_NullAndNull()
        {
            var a = default(ValueList<string>);
            var b = default(ValueList<string>);

            Assert.True(a == b);
            Assert.True(b == a);
            Assert.False(a != b);
            Assert.False(b != a);
        }

        public class StringValueList : ValueList<string>
        {}
    }
}