using System.Threading.Tasks;

namespace Dispatching.Core.Rides.Vacation
{
    public interface IDistanceService
    {
        Task<Mile> GetDistance(Location a, Location b);
    }
}