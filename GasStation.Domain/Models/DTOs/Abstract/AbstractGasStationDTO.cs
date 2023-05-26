namespace GasStation.Domain.Models.DTOs.Abstract
{
    public abstract class AbstractGasStationDTO
    {
        public string Address { get; set; }
        public IEnumerable<FuelDTO.FuelDTO> Fuels { get; set; }
    }
}
