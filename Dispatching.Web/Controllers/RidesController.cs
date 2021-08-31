using System.Threading.Tasks;
using Dispatching.Core.Rides;
using Microsoft.AspNetCore.Mvc;

namespace Dispatching.Web.Controllers
{
    public class RidesController : ControllerBase
    {
        [HttpPost]
        [Route("rides/airport")]
        public async Task<IActionResult> CreateRide([FromServices] VacationUseCase useCase, Models.Location request)
        {
            var passenger = Passenger.Create(request.Long, request.Lat);
            var receipt = await useCase.DrivePassengerToAirport(passenger);
            
            return Ok(new Models.Location
            {
                Long = receipt.Destination.Longitude,
                Lat = receipt.Destination.Latitude
            });
        }
    }
}