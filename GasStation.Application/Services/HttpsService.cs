using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Models.Helpers;
using GasStation.Domain.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GasStation.Application.Services
{
    public class HttpsService : IHttpsService
    {
        public async Task<IEnumerable<FuelDTO>> GetFuelInfo(int stationId)
        {
            var client = HttpHelper.Instance();

            var response = await client.GetAsync($"getFuelInfo?stationId={stationId}");

            var fuels = JsonConvert.DeserializeObject<IEnumerable<FuelDTO>>(await response.Content.ReadAsStringAsync());

            return fuels;
        }


        public async Task<IEnumerable<FuelDTO>> GetFuels()
        {
            var client = HttpHelper.Instance();

            var response = await client.GetAsync($"fuels");

            var fuels = JsonConvert.DeserializeObject<IEnumerable<FuelDTO>>(await response.Content.ReadAsStringAsync());

            return fuels;
        }


        public async Task<string> GetStationInfo(int id)
        {
            var client = HttpHelper.Instance();

            var response = await client.GetAsync($"getStationInfo?id={id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task SetStation(CreateGasStationDTO model)
        {
            var client = HttpHelper.Instance();

            HttpResponseMessage response;

            var result = await client.PutAsJsonAsync("setStation", model);
        }

        public async Task CreateStation(CreateGasStationDTO model)
        {
            var client = HttpHelper.Instance();

            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(model);

            await client.PostAsJsonAsync("setStation", json);
        }
    }
}