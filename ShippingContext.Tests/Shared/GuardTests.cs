using System.Text.RegularExpressions;
using AutoFixture;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class GuardTests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void Check_RegexWithValidString()
        {
            Guard.Check("", "abc", new Regex("[a-z]"));
            
            Assert.True(true);
        }
        
        [Fact]
        public void Check_RegexWithInvalidString()
        {
            string propertyName = fixture.Create<string>();
            string value = fixture.Create<int>().ToString();
            string pattern = "[a-z]";
            
            var exception = Assert.Throws<DomainException>(() => Guard.Check(propertyName, value, new Regex(pattern)));

            Assert.Contains(propertyName, exception.Message);
            Assert.Contains(value, exception.Message);
            Assert.Contains(pattern, exception.Message);
        }

        // ...
    }
}