using System.Threading.Tasks;
using Dispatching.Core.Rides;

namespace Dispatching.Core
{
    public interface IMoneyService
    {
        Task Charge(Passenger passenger, Dollar amount);

        Task Deposit(Dollar dollar);
    }
}