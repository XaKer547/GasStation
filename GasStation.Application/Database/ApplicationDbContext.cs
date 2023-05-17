using GasStation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GasStation.Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CardOwner> Owners { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }


        public DbSet<Domain.Models.GasStation> Stations { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }


        public DbSet<CameraLoad> Cameras { get; set; }
    }
}
