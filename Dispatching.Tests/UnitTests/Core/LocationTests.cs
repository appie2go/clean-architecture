using System;
using Dispatching.Core;
using FluentAssertions;
using Xunit;
using static Dispatching.Tests.TestDataGenerator;

namespace Dispatching.Tests.UnitTests.Core
{
    public class LocationTests
    {
        [Fact]
        public void WhenLatitudeSmallerThanMinusNinety_ShouldThrowArgumentException()
        {
            var @long = -90 - Any<decimal>();
            var lat = Any<decimal>();

            Action act = () => Location.Create(@long, lat);

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void WhenLatitudeBiggerThanNinety_ShouldThrowArgumentException()
        {
            var @long = 90 + Any<decimal>();
            var lat = Any<decimal>();

            Action act = () => Location.Create(@long, lat);

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void WhenLatitudeSmallerThanMinusHundredAndEighty_ShouldThrowArgumentException()
        {
            var @long = Any<decimal>();
            var lat = -180 - Any<decimal>();

            Action act = () => Location.Create(@long, lat);

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void WhenLatitudeBiggerThanHundredAndEighty_ShouldThrowArgumentException()
        {
            var @long = Any<decimal>();
            var lat = 180 + Any<decimal>();

            Action act = () => Location.Create(@long, lat);

            act.Should().Throw<ArgumentException>();
        }
        
        [Fact]
        public void WhenValidLongLat_ShouldCreateObject()
        {
            var @long = Any<decimal>() % 180;
            var lat = Any<decimal>() % 90;
            
            var actual = Location.Create(@long, lat);

            actual.Latitude.Should().Be(lat);
            actual.Longitude.Should().Be(@long);
        }
    }
}