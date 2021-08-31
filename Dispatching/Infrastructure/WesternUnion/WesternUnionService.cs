using System.Threading.Tasks;
using Dispatching.Core;
using Dispatching.Core.Rides;

namespace Dispatching.Infrastructure.WesternUnion
{
    public class WesternUnionService : IMoneyService
    {
        public Task Charge(Passenger passenger, Dollar amount)
        {
            throw new System.NotImplementedException();
        }

        public Task Deposit(Dollar dollar)
        {
            throw new System.NotImplementedException();
        }
    }
}