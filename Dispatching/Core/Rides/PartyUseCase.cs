using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatching.Core.Rides
{
    public class PartyUseCase
    {
        private readonly ICabRepository _cabRepository;
        private readonly IDistanceService _distanceService;

        public PartyUseCase(ICabRepository cabRepository, IDistanceService distanceService)
        {
            _cabRepository = cabRepository ?? throw new ArgumentNullException(nameof(cabRepository));
            _distanceService = distanceService ?? throw new ArgumentNullException(nameof(distanceService));
        }

        public async Task<Receipt> DriveGroupToLocation(IEnumerable<Passenger> passengers, Location partyLocation)
        {
            var cab = await _cabRepository.FindAvailableCab();

            var receipts = new List<Receipt>();
            foreach (var passenger in passengers)
            {
                var receipt = await Drive(cab, passenger.Location);
                receipts.Add(receipt);
            }

            var lastReceipt = await Drive(cab, partyLocation);
            receipts.Add(lastReceipt);
            
            cab.Disembark();
            return Receipt.Merge(receipts);
        }

        private async Task<Receipt> Drive(Cab cab, Location destination)
        {
            var distance = await _distanceService.GetDistance(cab.Location, destination);
            return cab.Drive(distance, destination);
        }
    }
}