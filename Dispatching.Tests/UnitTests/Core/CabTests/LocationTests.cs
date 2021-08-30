using Dispatching.Core;
using Dispatching.Core.Rides;
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
            var distance = Any<Mile>();
            var location = Any<Location>();
            
            var cab = Any<Cab>();
            
            cab.Drive(distance, location);

            cab.Location.Should().Be(location);
        }
    }
}