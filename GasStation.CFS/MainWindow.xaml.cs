using GasStation.Application.Services;
using GasStation.Domain;
using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace GasStation.CFS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetStation_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(StationIdTxb.Text, out var id))
            {
                return;
            }

            if (id < 0 || id > 100)
            {
                MessageBox.Show("id не может быть меньше 1 или больше 99");
                return;
            }

            var client = new HttpClient(new HttpClientHandler() { UseProxy = false })
            {
                BaseAddress = new(Routes.API_URL)
            };

            var response = await client.GetAsync($"getStationInfo?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var address = await response.Content.ReadAsStringAsync();

                response = await client.GetAsync($"getFuelInfo?stationId={id}");

                new StationWindow(new EditGasStationDTO
                {
                    Id = id,
                    Address = address,
                    Fuels = await response.Content.ReadFromJsonAsync<FuelDTO[]>(),
                }).Show();
            }
            else
            {
                response = await client.GetAsync("fuels");

                new StationWindow(new CreateGasStationDTO()
                {
                    Fuels = await response.Content.ReadFromJsonAsync<FuelDTO[]>()
                }).Show();
            }

            Hide();
        }
    }
}
