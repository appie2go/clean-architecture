using System;

namespace Dispatching.Core.Maintenance
{
    public class DeprecationUseCase
    {
        private readonly ICabRepository _cabRepository;
        private readonly IJunkyardService _junkyardService;

        public DeprecationUseCase(ICabRepository cabRepository, IJunkyardService junkyardService)
        {
            _cabRepository = cabRepository ?? throw new ArgumentNullException(nameof(cabRepository));
            _junkyardService = junkyardService ?? throw new ArgumentNullException(nameof(junkyardService));
        }
        
        
    }
}