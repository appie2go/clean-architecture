using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dispatching.Core.Maintenance
{
    public class DeprecationUseCase
    {
        private readonly ICabRepository _cabRepository;
        private readonly IJunkyardService _junkyardService;
        private readonly IMoneyService _moneyService;

        public DeprecationUseCase(ICabRepository cabRepository, IJunkyardService junkyardService, IMoneyService moneyService)
        {
            _cabRepository = cabRepository ?? throw new ArgumentNullException(nameof(cabRepository));
            _junkyardService = junkyardService ?? throw new ArgumentNullException(nameof(junkyardService));
            _moneyService = moneyService ?? throw new ArgumentNullException(nameof(moneyService));
        }

        public async Task SellDeprecatedCabs()
        {
            var cabs = await _cabRepository.GetAll();

            var limit = Mile.Create(300000);
            var money = Dollar.None;
            
            foreach (var deprecatedCab in cabs.Where(x => x.Mileage > limit))
            {
                money += await _junkyardService.Sell(deprecatedCab);
            }

            await _moneyService.Deposit(money);
        }
    }
}