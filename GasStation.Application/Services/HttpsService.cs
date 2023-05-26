using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GasStation.Application.Services
{
    public class HttpsService : IHttpsService
    {
        private readonly HttpClient _client = new(new HttpClientHandler()
        {
            UseProxy = false
        })
        {
            BaseAddress = new Uri("https://localhost:7146/")
        };

        public async Task<IEnumerable<FuelDTO>> GetFuelInfo(int stationId)
        {
            var response = await _client.GetAsync($"getFuelInfo?stationId={stationId}");

            var fuels = JsonConvert.DeserializeObject<IEnumerable<FuelDTO>>(await response.Content.ReadAsStringAsync());

            return fuels;
        }

        public async Task<IEnumerable<FuelDTO>> GetFuels()
        {
            var response = await _client.GetAsync($"fuels");

            var fuels = JsonConvert.DeserializeObject<IEnumerable<FuelDTO>>(await response.Content.ReadAsStringAsync());

            return fuels;
        }

        public async Task<string> GetStationInfo(int id)
        {
            var response = await _client.GetAsync($"getStationInfo?id={id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task SetStation(EditGasStationDTO model)
        {
            var result = await _client.PutAsJsonAsync("setStation", model);
        }

        public async Task CreateStation(CreateGasStationDTO model)
        {
            await _client.PostAsJsonAsync("setStation", model);
        }
    }
}