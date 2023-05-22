using System.ComponentModel.DataAnnotations;

namespace GasStation.Domain.Models.DTOs.GasStationDTO
{
    public class CreateGasStationDTO
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public IEnumerable<FuelDTO.FuelDTO> Fuels { get; set; }


        public bool IsNew { get; set; } = false;
    }
}
