using System.Threading.Tasks;
using Dispatching.Core;
using Dispatching.Core.Rides;

namespace Dispatching.Infrastructure.Google
{
    public class GoogleMapsService : IDistanceService, ILocationService
    {
        public Task<Mile> GetDistance(Location a, Location b)
        {
            throw new System.NotImplementedException();
        }

        public Task<Location> FindNearestAirport()
        {
            throw new System.NotImplementedException();
        }
    }
}