using System.Threading.Tasks;
using Dispatching.Core.Maintenance;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : ControllerBase
    {
        [HttpDelete]
        [Route("cars/deprecated")]
        public async Task<IActionResult> SellDeprecatedCars([FromServices] DeprecationUseCase useCase)
        {
            await useCase.SellDeprecatedCabs();
            return NoContent();
        }
    }
}