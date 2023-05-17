namespace GasStation.Domain.Models
{
    public class Fuel
    {
        public int Id { get; set; }
        public FuelType Type { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public ICollection<GasStation> GasStations { get; set; }
    }
}