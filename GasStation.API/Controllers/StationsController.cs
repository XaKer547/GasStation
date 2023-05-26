using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GasStation.API.Controllers
{
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationsController(IStationService service)
        {
            _stationService = service;
        }

        [HttpGet]
        [Route("stations")]
        public async Task<IActionResult> GetStationsFuelPrice([FromQuery] string fuel)
        {
            var stations = await _stationService.GetStationsFuelPriceByType(fuel);

            if (!stations.Any())
                return NotFound();

            return Ok(stations);
        }

        [HttpPost]
        [Route("setStation")]
        public async Task<IActionResult> CreateStation([FromBody] CreateGasStationDTO model)
        {
            await _stationService.CreateStation(model);

            return Ok();
        }

        [HttpPut]
        [Route("setStation")]
        public async Task<IActionResult> SetStation([FromBody] EditGasStationDTO model)
        {
            await _stationService.UpdateStation(model);

            return Ok();
        }


        [HttpGet]
        [Route("getStationInfo")]
        public async Task<IActionResult> GetStationInfo([FromQuery] int id)
        {
            if (id < 0 || id > 100)
                return BadRequest("id может принимать значение от 1 до 99 ");

            var station = await _stationService.GetStationInfoById(id);

            if (station is null)
                return NotFound();

            return Ok(station);
        }
    }
}
