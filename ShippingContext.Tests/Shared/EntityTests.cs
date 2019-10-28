using AutoFixture;
using ShippingContext.Shared;
using Xunit;

namespace ShippingContext.Tests.Shared
{
    public class EntityTests
    {
        Fixture fixture = new Fixture();
        
        [Fact]
        public void Ctor_SetsId()
        {
            var id = fixture.Create<string>();
            var number = fixture.Create<int>();
            
            var sut = new TestEntity(id, number);
            
            Assert.Equal(id, sut.Id);
        }

        [Fact]
        public void Equals_SameId()
        {
            var id = fixture.Create<string>();
            
            var sut = new TestEntity(id, fixture.Create<int>());
            var other = new TestEntity(id, fixture.Create<int>());
            
            Assert.True(sut.Equals(other));
        }
        
        [Fact]
        public void Equals_DifferentIds()
        {
            var number = fixture.Create<int>();
            
            var sut = new TestEntity(fixture.Create<string>(), number);
            var other = new TestEntity(fixture.Create<string>(), number);
            
            Assert.False(sut.Equals(other));
        }
        
        [Fact]
        public void EqualityOperators_NullAndNull()
        {
            var left =  default(TestEntity);
            var right =  default(TestEntity);

            Assert.True(left == right);
            Assert.False(left != right);
        }

        [Fact]
        public void EqualityOperator_NullAndValue()
        {
            var left = default(TestEntity);
            var right = new TestEntity(fixture.Create<string>());

            Assert.False(left == right);
            Assert.True(left != right);
        }

        [Fact]
        public void EqualityOperators_ValueAndNull()
        {
            var left = new TestEntity(fixture.Create<string>());
            var right = default(TestEntity);

            Assert.False(left == right);
            Assert.True(left != right);
        }

        [Fact]
        public void EqualityOperators_DifferentIds()
        {
            var left = new TestEntity(fixture.Create<string>());
            var right = new TestEntity(fixture.Create<string>());
            
            Assert.False(left == right);
            Assert.True(left != right);
        }

        [Fact]
        public void EqualityOperators_SameIds()
        {
            var id = fixture.Create<string>();
            
            var left = new TestEntity(id);
            var right = new TestEntity(id);
            
            Assert.True(left == right);
            Assert.False(left != right);
        }

        [Fact]
        public void GetHashCode_Id()
        {
            var id = fixture.Create<string>();
            var sut = new TestEntity(id);
            
            Assert.Equal(id.GetHashCode(), sut.GetHashCode());
        }
        
        [Fact]
        public void GetString_Id()
        {
            var id = fixture.Create<string>();
            var sut = new TestEntity(id);
            
            Assert.Equal(id.ToString(), sut.ToString());
        }
    }

    public class TestEntity : Entity<string>
    {
        public TestEntity(string id, int number = 0)
            : base(id)
        {
            Number = number;
        }

        public new string Id => base.Id;
        
        public int Number { get; set; }
    }
}