namespace GasStation.Domain.Models.DTOs.GasStationDTO
{
    public class GasStationDTO
    {
        public int Id { get; set; }

        /// <summary>
        /// Географический адрес АЗС
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Цена на выбранный вид топлива
        /// </summary>
        public double Price { get; set; }
    }
}
