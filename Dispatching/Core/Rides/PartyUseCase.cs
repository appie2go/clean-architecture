using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispatching.Core.Rides
{
    public class PartyUseCase
    {
        private readonly ICabRepository _cabRepository;
        private readonly IDistanceService _distanceService;
        private readonly IMoneyService _moneyService;

        public PartyUseCase(ICabRepository cabRepository, IDistanceService distanceService, IMoneyService moneyService)
        {
            _cabRepository = cabRepository ?? throw new ArgumentNullException(nameof(cabRepository));
            _distanceService = distanceService ?? throw new ArgumentNullException(nameof(distanceService));
            _moneyService = moneyService ?? throw new ArgumentNullException(nameof(moneyService));
        }

        public async Task<Receipt> DriveGroupToLocation(IEnumerable<Passenger> passengers, Location destionation)
        {
            var cab = await _cabRepository.FindAvailableCab();

            var receipts = new List<Receipt>();
            foreach (var passenger in passengers)
            {
                var passengerReceipt = await Drive(cab, passenger.Location);
                receipts.Add(passengerReceipt);
            }

            var destinationReceipt = await Drive(cab, destionation);
            receipts.Add(destinationReceipt);
            
            var receipt = Receipt.Merge(receipts);
            await _moneyService.Charge(passengers.First(), receipt.CalculatePrice());
            
            cab.Disembark();
            return receipt;
        }

        private async Task<Receipt> Drive(Cab cab, Location destination)
        {
            var distance = await _distanceService.GetDistance(cab.Location, destination);
            return cab.Drive(distance, destination);
        }
    }
}