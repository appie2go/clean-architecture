using System.Threading.Tasks;

namespace Dispatching.Core.Rides
{
    public interface ILocationService
    {
        Task<Location> FindNearestAirport();
    }
}