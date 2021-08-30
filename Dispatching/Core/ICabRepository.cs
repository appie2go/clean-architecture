using System.Threading.Tasks;

namespace Dispatching.Core
{
    public interface ICabRepository
    {
        Task<Cab> FindAvailableCab();
        Task Update(Cab cab);
    }
}