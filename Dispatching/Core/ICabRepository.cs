using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatching.Core
{
    public interface ICabRepository
    {
        Task<Cab> FindAvailableCab();
        Task<IEnumerable<Cab>> GetAll();
        Task Update(Cab cab);
    }
}