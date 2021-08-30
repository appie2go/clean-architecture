using FluentAssertions;
using Xunit;
using static Dispatching.Tests.TestFixtures;

namespace Dispatching.Tests.UnitTests.CabTests
{
    public class TakenTests
    {
        [Fact]
        public void WhenPassengers_ShouldBetaken()
        {
            var cab = Any<Cab>();
            cab.Embark(Any<Passenger>());
            cab.Taken.Should().BeTrue();
        }

        [Fact]
        public void WhenNoPassengers_ShouldNotBeTaken()
        {
            var cab = Any<Cab>();
            cab.Taken.Should().BeFalse();
        }

        [Fact]
        public void WhenPassengersDisembarked_ShouldNotBeTaken()
        {
            var cab = Any<Cab>();
            cab.Embark(Any<Passenger>());
            cab.Disembark();
            cab.Taken.Should().BeFalse();
        }
    }
}