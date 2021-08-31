using Dispatching.Core;
using Dispatching.Core.Rides;
using Microsoft.EntityFrameworkCore;

namespace Dispatching.Infrastructure.Database
{
    public class DispatchingDbContext : DbContext
    {
        public DispatchingDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Cab> Cabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cab>(
                e =>
                {
                    e.HasKey("_id");
                    e.Property("_cabSize");
                    e.Property(x => x.Location).HasConversion(x => x.ToString(), x => Location.Parse(x));
                    e.Ignore(x => x.Passengers);
                });
        }
    }


}