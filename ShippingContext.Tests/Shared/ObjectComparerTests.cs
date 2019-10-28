using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class ObjectComparerTests
    {
        [Fact]
        public void AreEqual_NullValues()
        {
            Assert.True(ObjectComparer.AreEqual(null, null));
        }
        
        [Fact]
        public void AreEqual_NullAndValue()
        {
            Assert.False(ObjectComparer.AreEqual(null, ""));
            Assert.False(ObjectComparer.AreEqual("", null));
        }

        [Fact]
        public void AreEqual_DifferentValues()
        {
            Assert.False(ObjectComparer.AreEqual("a", "b"));
        }
        
        [Fact]
        public void AreEqual_SameValues()
        {
            Assert.True(ObjectComparer.AreEqual("a", "a"));
        }
    }
}