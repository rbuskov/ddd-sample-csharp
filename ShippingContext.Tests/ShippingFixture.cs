using System;
using System.Linq;
using System.Text;
using System.Threading;
using AutoFixture;
using AutoFixture.Dsl;
using ShippingContext.CargoAggregate;
using ShippingContext.HandlingAggregate;
using ShippingContext.LocationAggregate;
using ShippingContext.VoyageAggregate;

namespace ShippingContext.Tests
{
    public class ShippingFixture : Fixture
    {
        private readonly UnLocodeFactory unLocodeFactory;
        private readonly HandlingEventFactory handlingEventFactory;

        public ShippingFixture()
        {
            unLocodeFactory = new UnLocodeFactory(this);
            handlingEventFactory = new HandlingEventFactory(this);
            
            this.Register<HandlingEvent>(() => handlingEventFactory.Create());
            this.Register<UnLocode>(() => unLocodeFactory.Create());
        }
    }

    public class HandlingEventFactory
    {
        private readonly ShippingFixture fixture;

        public HandlingEventFactory(ShippingFixture fixture)
        {
            this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }
        public HandlingEvent Create()
        {
            var cargo = fixture.Create<Cargo>();
            var registrationTime = fixture.Create<DateTimeOffset>();
            var completionTime = fixture.Create<DateTimeOffset>();
            var handlingEventType = fixture.Create<HandlingEventType>();
            var location = fixture.Create<Location>();

            if (handlingEventType.ProhibitsVoyage())
                return fixture.Build<HandlingEvent>()
                    .FromFactory(() =>
                        new HandlingEvent(cargo, registrationTime, completionTime, handlingEventType, location))
                    .Create();

            var voyage = fixture.Create<Voyage>();

            return fixture.Build<HandlingEvent>()
                .FromFactory(() => new HandlingEvent(cargo, registrationTime, completionTime, handlingEventType, location, voyage))
                .Create();
        }
    }

    public class UnLocodeFactory
    {
        private readonly ShippingFixture fixture;
        private int counter;

        public UnLocodeFactory(ShippingFixture fixture)
        {
            this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }
        
        public UnLocode Create()
        {
            var remainder = counter++;

            var countryAndLocation = new StringBuilder(5)
                .Append(GetChar(ref remainder))
                .Append(GetChar(ref remainder))
                .Append(GetChar(ref remainder))
                .Append(GetChar(ref remainder))
                .Append(GetChar(ref remainder))
                .ToString();
            
            return new UnLocode(countryAndLocation);
        }
        
        private char GetChar(ref int remainder)
        {
            var index = (remainder <= 0) ? 0 : remainder % 25;

            remainder = remainder / 25;

            return alpha[index];
        }

        private static readonly char[] alpha = Enumerable
            .Range('A', 25)
            .Select(a => (char) a)
            .ToArray();
    }
}