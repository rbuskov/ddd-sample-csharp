using AutoFixture;
using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.LocationAggregate
{
    public class LocationTests
    {
        private Fixture fixture = new ShippingFixture();

        [Fact]
        public void CtorAndProperties()
        {
            var unLocode = new UnLocode("ABCDE");
            var name = fixture.Create<string>();
            
            var sut = new Location(unLocode, name);
            
            Assert.Equal(unLocode, sut.UnLocode);
            Assert.Equal(name, sut.Name);
        }

        [Fact]
        public void Ctor_EmptyName()
        {
            var unLocode = new UnLocode("ABCDE");

            var exception = Assert.Throws<DomainException>(() => new Location(unLocode, string.Empty));
        }
        
        [Fact]
        public void Unknown()
        {
            Assert.Equal(UnLocode.Empty, Location.Unknown.UnLocode);
            Assert.Equal("Unknown location", Location.Unknown.Name);
        }
    }
}