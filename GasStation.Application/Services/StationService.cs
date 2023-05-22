using GasStation.Application.Database;
using GasStation.Domain.Services;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using Microsoft.EntityFrameworkCore;
using GasStation.Domain.Models;

namespace GasStation.Application.Services
{
    public class StationService : IStationService
    {
        private readonly ApplicationDbContext _context;
        public StationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetStationInfoById(int stationId)
        {
            var a = await _context.Stations.FirstOrDefaultAsync(s => s.Id == stationId);

            return a?.Address;
        }

        public async Task<IEnumerable<GasStationDTO>> GetStationsFuelPriceByType(string fuelType)
        {
            return await _context.Stations
                .Select(s => new GasStationDTO()
                {
                    Id = s.Id,
                    Address = s.Address,
                    Price = s.Fuels.FirstOrDefault(f => f.Type.Name == fuelType).Price
                }).Where(dto => dto.Price != null).ToArrayAsync();
        }

        public async Task CreateStation(CreateGasStationDTO model)
        {
            var fuels = new List<Fuel>();

            foreach (var fuel in model.Fuels)
            {
                var type = await _context.FuelTypes.FirstOrDefaultAsync(s => s.Name == fuel.TypeName);

                if (type is null)
                    return;

                fuels.Add(new()
                {
                    Amount = fuel.Amount,
                    Price = fuel.Price,
                    Type = type,
                });
            }

            var station = new Domain.Models.GasStation()
            {
                Address = model.Address,
                Fuels = fuels
            };

            _context.Stations.Add(station);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStation(CreateGasStationDTO model)
        {
            var station = _context.Stations.FirstOrDefault(s => s.Id == model.Id);

            if (station is null)
                return;

            var fuelList = new List<Fuel>();

            foreach (var item in model.Fuels)
            {
                var type = await _context.FuelTypes.FirstOrDefaultAsync(s => s.Name == item.TypeName);

                var fuel = await _context.Fuels.FirstOrDefaultAsync(f => f.Type == type && f.GasStation == station);

                if (fuel is null)
                    continue;

                fuel.Price = item.Price;
                fuel.Amount = item.Amount;

                fuelList.Add(fuel);
            }

            station.Address = model.Address;

            _context.Stations.Update(station);

            _context.Fuels.UpdateRange(fuelList);

            await _context.SaveChangesAsync();
        }
    }
}