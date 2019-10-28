using AutoFixture;
using ShippingContext.Shared;
using Xunit;

#pragma warning disable CS1718

namespace ShippingContext.Tests.Shared
{
    public class ValueObjectTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Value_Initialized()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.Equal(i, sut.Value);
        }

        [Fact]
        public void Equals_Self()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);
            
            Assert.True(sut.Equals(sut));
        }
        
        [Fact]
        public void Equals_SameValue()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);
            var other = new Int32ValueObject(i);
            
            Assert.True(sut.Equals(other));
        }
        
        [Fact]
        public void Equals_OtherValue()
        {
            var i = fixture.Create<int>();
            var j = fixture.Create<int>();
            
            var sut = new Int32ValueObject(i);
            var other = new Int32ValueObject(j);
            
            Assert.False(sut.Equals(other));
        }

        [Fact]
        public void Equals_Null()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);
            
            Assert.False(sut.Equals(null));
        }
        
        [Fact]
        public void Equals_DerivedValueObject()
        {
            var obj = fixture.Create<object>();

            var a = new BaseValueObject(obj);
            var b = new DerivedValueObject(obj);
            
            Assert.False(a.Equals(b));
            Assert.False(b.Equals(a));
        }

        [Fact]
        public void Equals_DerivedIdWithSameValue()
        {
            var baseId = fixture.Create<BaseId>();
            var derivedId = fixture.Create<DerivedId>();

            var a = new BaseIdValueObject(baseId);
            var b = new BaseIdValueObject(derivedId);
            
            Assert.False(a.Equals(b));
            Assert.False(b.Equals(a));
        }
        

        [Fact]
        public void EqualityOperator_Self()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.True(sut == sut);
        }
        
        [Fact]
        public void EqualityOperator_SameValue()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);
            var other = new Int32ValueObject(i);

            Assert.True(sut == other);
        }

        [Fact]
        public void EqualityOperator_OtherValue()
        {
            var i = fixture.Create<int>();
            var j = fixture.Create<int>();
            var sut = new Int32ValueObject(i);
            var other = new Int32ValueObject(j);

            Assert.False(sut == other);
        }

        [Fact]
        public void EqualityOperator_NullRightValue()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.False(sut == null);
        }

        [Fact]
        public void EqualityOperator_NullLeftValue()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.False(null == sut);
        }

        [Fact]
        public void ToString_Value()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.Equal(i.ToString(), sut.ToString());
        }

        [Fact]
        public void GetHashcode_Value()
        {
            var i = fixture.Create<int>();
            var sut = new Int32ValueObject(i);

            Assert.Equal(i.GetHashCode(), sut.GetHashCode());
        }
    }
    public class Int32ValueObject : ValueObject<int>
    {
        public Int32ValueObject(int value) 
            : base(value)
        {}

        public new int Value => base.Value;
    }
    
    public class BaseValueObject : ValueObject<object>
    {
        public BaseValueObject(object obj) 
            : base(obj)
        {}
    }
    
    public class DerivedValueObject : BaseValueObject
    {
        public DerivedValueObject(object obj) 
            : base(obj)
        {}
    }

    public class BaseId : object
    {
        public override bool Equals(object? obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    
    public class DerivedId : BaseId
    {}

    public class BaseIdValueObject : ValueObject<BaseId>
    {
        public BaseIdValueObject(BaseId id)
           : base(id)
        {}
    }
}

#pragma warning restore CS1718
