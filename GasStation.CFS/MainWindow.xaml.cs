using GasStation.Application.Services;
using GasStation.Domain.Models.DTOs.GasStationDTO;
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
            HttpsService service = new();

            if (!int.TryParse(StationIdTxb.Text, out var id))
            {
                return;
            }

            if (id < 0 || id > 100)
            {
                MessageBox.Show("");
                return;
            }

            var stationAddress = await service.GetStationInfo(id);

            if (stationAddress is null)
            {
                new StationWindow(new CreateGasStationDTO()
                {
                    Fuels = await service.GetFuels()
                }).ShowDialog();

                Hide();
                return;
            }

            new StationWindow(new EditGasStationDTO
            {
                Id = id,

                Address = stationAddress,

                Fuels = await service.GetFuelInfo(id),
            }).Show();

            Hide();
        }
    }
}
