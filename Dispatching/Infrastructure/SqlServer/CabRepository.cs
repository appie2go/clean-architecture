using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dispatching.Core;
using Microsoft.EntityFrameworkCore;

namespace Dispatching.Infrastructure.SqlServer
{
    public class CabRepository : ICabRepository
    {
        private readonly DispatchingDbContext _dbContext;

        public CabRepository(DispatchingDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Cab> FindAvailableCab() => await _dbContext.Cabs.Where(x => !x.Taken).FirstOrDefaultAsync();

        public async Task<IEnumerable<Cab>> GetAll() => await _dbContext.Cabs.ToArrayAsync();

        public async Task Update(Cab cab) => await _dbContext.SaveChangesAsync();
    }
}