using Dispatching.Core;
using Dispatching.Core.Maintenance;
using Dispatching.Core.Rides;
using Dispatching.Infrastructure.Database;
using Dispatching.Infrastructure.Google;
using Dispatching.Infrastructure.JunkyardAndCo;
using Dispatching.Infrastructure.WesternUnion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dispatching
{
    public static class Dependencies
    {
        public static IServiceCollection UseDispatching(this IServiceCollection serviceCollection, string connectionString)
        {
            return serviceCollection
                .AddDbContext<DispatchingDbContext>()
                .AddTransient(_ => CreateDispatchingDbContext(connectionString))
                .AddTransient<PartyUseCase>()
                .AddTransient<VacationUseCase>()
                .AddTransient<DeprecationUseCase>()
                .AddTransient<ICabRepository, CabRepository>()
                .AddTransient<IJunkyardService, JunkyardService>()
                .AddTransient<IMoneyService, WesternUnionService>()
                .AddTransient<IDistanceService, GoogleMapsService>()
                .AddTransient<ILocationService, GoogleMapsService>();
        }
        
        private static DispatchingDbContext CreateDispatchingDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DispatchingDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new DispatchingDbContext(optionsBuilder.Options);
        }
    }
}