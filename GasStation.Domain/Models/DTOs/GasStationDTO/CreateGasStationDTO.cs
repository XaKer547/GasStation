using System.ComponentModel.DataAnnotations;

namespace GasStation.Domain.Models.DTOs.GasStationDTO
{
    public class CreateGasStationDTO
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public IEnumerable<FuelDTO.FuelDTO> Fuels { get; set; }
    }
}
