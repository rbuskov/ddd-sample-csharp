using ShippingContext.LocationAggregate;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.LocationAggregate
{
    public class UnLocodeTests
    {
        [Theory]
        [InlineData("ABCDE")]
        [InlineData("AB2DE")]
        [InlineData("ABC2E")]
        [InlineData("ABCD2")]
        [InlineData("ABC99")]
        public void Ctor_ValidCountryAndLocation(string countryAndLocation)
        {
            new UnLocode(countryAndLocation);

            Assert.True(true);
        }
        
        [Theory]
        [InlineData("2BCDE")]
        [InlineData("A2CDE")]
        [InlineData("ABC1E")]
        [InlineData("ABCD")]
        [InlineData("ABCDEF")]
        public void Ctor_InvalidCountryAndLocation(string countryAndLocation)
        {
            Assert.Throws<DomainException>(() => new UnLocode(countryAndLocation));
        }
        
        [Fact]
        public void CountryAndLocation()
        {
            var id = "ABCDE";           
            var sut = new UnLocode(id);
            
            Assert.Equal(id.ToUpper() , sut.CountryAndLocation);
        }
        
        [Fact]
        public void CountryAndLocation_LowerCase()
        {
            var id = "abcde";           
            var sut = new UnLocode(id);
            
            Assert.Equal(id.ToUpper() , sut.CountryAndLocation);
        }

        [Fact]
        public void Empty()
        {
            Assert.Equal("XXXXX", UnLocode.Empty.CountryAndLocation);
        }
    }
}
