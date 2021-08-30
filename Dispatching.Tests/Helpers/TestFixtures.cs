using AutoFixture;

namespace Dispatching.Tests.Helpers
{
    public static class TestFixtures
    {
        public static T Any<T>()
        {
            var fixture = new Fixture();
            return fixture.Create<T>();
        }
    }
}