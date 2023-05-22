using GasStation.Application.Database;
using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace GasStation.Application.Services
{
    public class FuelService : IFuelService
    {
        private readonly ApplicationDbContext _context;
        public FuelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FuelDTO>> GetFuels()
        {
            return await _context.Fuels.Select(f => new FuelDTO()
            {
                Amount = 0,
                Price = 0,
                TypeName = f.Type.Name,
            }).Distinct().ToArrayAsync();
        }

        public async Task<IEnumerable<FuelDTO>> GetFuelsFromStationById(int id)
        {
            return await _context.Fuels.Where(f => f.GasStation.Id == id).Select(f => new FuelDTO()
            {
                Amount = f.Amount,
                Price = f.Price,
                TypeName = f.Type.Name,
            }).ToArrayAsync();
        }
    }
}
