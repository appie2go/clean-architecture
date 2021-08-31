using System.Threading.Tasks;
using Dispatching.Core.Rides;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Web.Controllers
{
    public class RidesController : ControllerBase
    {
        [HttpPost]
        [Route("rides/airport")]
        public async Task<IActionResult> CreateRide([FromServices] VacationUseCase useCase, Location request)
        {
            var passenger = Passenger.Create(request.Longitude, request.Latitude);
            var receipt = await useCase.DrivePassengerToAirport(passenger);
            var response = Location.Create(receipt.Destination.Longitude, receipt.Destination.Latitude);
            
            return Ok(response);
        }
    }
}