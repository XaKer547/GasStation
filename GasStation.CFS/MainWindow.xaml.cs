using GasStation.Application.Services;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using GasStation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            var model = new CreateGasStationDTO()
            {
                Id = id
            };

            var stationAddress = await service.GetStationInfo(id);

            if (stationAddress is null)
            {
                model.Fuels = await service.GetFuels();
                new StationWindow(model).Show();

                Hide();
                return;
            }

            model.Address = stationAddress;

            model.Fuels = await service.GetFuelInfo(id);

            model.IsNew = false;
            new StationWindow(model).Show();

            Hide();
        }
    }
}
