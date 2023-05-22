using GasStation.Domain.Models.DTOs.FuelDTO;

namespace GasStation.Domain.Services
{
    public interface IFuelService
    {
        public Task<IEnumerable<FuelDTO>> GetFuelsFromStationById(int id);
        public Task<IEnumerable<FuelDTO>> GetFuels();
    }
}
