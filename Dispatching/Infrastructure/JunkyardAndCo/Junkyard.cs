using System.Threading.Tasks;
using Dispatching.Core;
using Dispatching.Core.Maintenance;

namespace Dispatching.Infrastructure.JunkyardAndCo
{
    public class Junkyard : IJunkyardService
    {
        public Task<Dollar> Sell(Cab cab)
        {
            throw new System.NotImplementedException();
        }
    }
}