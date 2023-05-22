using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;

namespace GasStation.Domain.Services
{
    public interface IHttpsService
    {
        public Task<string> GetStationInfo(int id);
        public Task SetStation(CreateGasStationDTO model);
        public Task CreateStation(CreateGasStationDTO model);
        public Task<IEnumerable<FuelDTO>> GetFuelInfo(int stationId);
    }
}
