using Dispatching.Core;
using FluentAssertions;
using Xunit;
using static Dispatching.Tests.TestDataGenerator;

namespace Dispatching.Tests.UnitTests.Core.CabTests
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