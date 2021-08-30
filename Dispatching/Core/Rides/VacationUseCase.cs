using System;
using System.Threading.Tasks;

namespace Dispatching.Core.Rides
{
    public class VacationUseCase
    {
        private readonly ICabRepository _cabRepository;
        private readonly ILocationService _locationService;
        private readonly IDistanceService _distanceService;

        public VacationUseCase(ICabRepository cabRepository,
            ILocationService locationService, 
            IDistanceService distanceService)
        {
            _cabRepository = cabRepository ?? throw new ArgumentNullException(nameof(cabRepository));
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));
            _distanceService = distanceService ?? throw new ArgumentNullException(nameof(distanceService));
        }

        public async Task<Receipt> DrivePassengerToAirport(Passenger passenger)
        {
            var cab = await _cabRepository.FindAvailableCab();
            
            var distanceToPassenger = await _distanceService.GetDistance(cab.Location, passenger.Location);
            cab.Drive(distanceToPassenger, passenger.Location);
            
            var nearestAirport = await _locationService.FindNearestAirport();
            var distanceToAirport = await _distanceService.GetDistance(cab.Location, nearestAirport);
            if (distanceToAirport > Mile.Create(100))
            {
                throw new NotSupportedException("100 mile is the maximum distance a cab drives.");
            }

            cab.Embark(passenger);
            var receipt = cab.Drive(distanceToAirport, nearestAirport);
            
            await _cabRepository.Update(cab);
            
            return receipt;
        }
    }
}