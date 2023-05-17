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

        //он сам создает id или его прям указывают?
        public async Task<bool> CreateStation(CreateGasStationDTO model)
        {
            var fuels = new List<Fuel>();

            foreach (var fuel in model.Fuels)
            {
                var type = await _context.FuelTypes.FirstOrDefaultAsync(s => s.Name == fuel.TypeName);

                if (type is null)
                    return false;

                fuels.Add(new()
                {
                    Amount = fuel.Amount,
                    Price = fuel.Price,
                    Type = type,
                });
            }

            _context.Stations.Add(new Domain.Models.GasStation()
            {
                Address = model.Address,
                Fuels = fuels
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
