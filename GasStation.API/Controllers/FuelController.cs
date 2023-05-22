using GasStation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasStation.API.Controllers
{
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IFuelService _service;
        public FuelController(IFuelService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("getFuelInfo")]
        public async Task<IActionResult> GetFuelInfo([FromQuery] int stationId)
        {
            var fuels = await _service.GetFuelsFromStationById(stationId);

            if (!fuels.Any())
                return NotFound();

            return Ok(fuels);
        }

        [HttpGet]
        [Route("fuels")]
        public async Task<IActionResult> GetFuels()
        {
            return Ok(await _service.GetFuels());
        }
    }
}
