using GasStation.Domain.Models.DTOs.GasStationDTO;

namespace GasStation.Domain.Services
{
    public interface IStationService
    {
        /// <summary>
        /// Возвращает список станций АЗС, на которых поддерживается данный вид топлива.
        /// </summary>
        /// <param name="fuelType">выбранный вид топлива</param>
        /// <returns></returns>
        public Task<IEnumerable<GasStationDTO>> GetStationsFuelPriceByType(string fuelType);

        public Task CreateStation(CreateGasStationDTO model);
        
        public Task UpdateStation(EditGasStationDTO model);

        /// <summary>
        /// Возвращает информацию, хранимую в базе о данной АЗС
        /// </summary>
        /// <param name="stationId">идентификатор АЗС</param>
        /// <returns>Адрес АЗС</returns>
        public Task<string> GetStationInfoById(int stationId);
    }
}
