namespace GasStation.Domain.Models
{
    public class GasStation
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public ICollection<Fuel> Fuels { get; set; }
    }
}
