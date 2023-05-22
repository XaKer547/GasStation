using GasStation.Application.Services;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GasStation.CFS
{
    /// <summary>
    /// Логика взаимодействия для StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        public StationWindow(CreateGasStationDTO model)
        {
            InitializeComponent();

            DataContext = model;
        }

        //private FuelDTO
        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var service = new HttpsService();

            var model = (CreateGasStationDTO)DataContext;

            if (model.IsNew)
                await service.CreateStation(model);
            else
                await service.SetStation(model);
        }
    }
}
