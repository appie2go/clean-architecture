using AutoFixture;

namespace Dispatching.Tests
{
    public static class TestFixtures
    {
        public static T Any<T>()
        {
            var fixture = new Fixture();
            fixture.Customize<Location>(x => x.FromFactory(() => Location.Create(fixture.Create<decimal>() % 180m, fixture.Create<decimal>() % 90m)));

            return fixture.Create<T>();
        }
    }
}