using FluentAssertions;
using Xunit;
using static Dispatching.Tests.TestFixtures;

namespace Dispatching.Tests.UnitTests.CabTests
{
    public class LocationTests
    {
        [Fact]
        public void ShouldSetLocation()
        {
            var location = Any<Location>();
            var cab = Any<Cab>();
            
            cab.SetLocation(location);

            cab.Location.Should().Be(location);
        }
    }
}