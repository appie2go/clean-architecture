using System.Threading.Tasks;

namespace Dispatching.Core.Maintenance
{
    public interface IJunkyardService
    {
        Task<Dollar> Sell(Cab cab);
    }
}