using FluentAssertions;
using Xunit;
using static Dispatching.Tests.TestFixtures;

namespace Dispatching.Tests.UnitTests.CabTests
{
    public class PassengerTest
    {
        [Fact]
        public void WhenPassengerEmbarks_PassengerShouldBeVisible()
        {
            var passenger = Any<Passenger>();
            
            var cab = Any<Cab>();
            cab.Embark(passenger);
            
            cab.Passengers.Should().Contain(passenger);
        }

        [Fact]
        public void PassengerListShouldBeEmpty()
        {
            var cab = Any<Cab>();
            cab.Passengers.Should().BeEmpty();
        }
    }
}