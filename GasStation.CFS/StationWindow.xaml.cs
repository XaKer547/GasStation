using GasStation.Application.Services;
using GasStation.Domain.Models.DTOs.Abstract;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using System.Windows;

namespace GasStation.CFS
{
    /// <summary>
    /// Логика взаимодействия для StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        private AbstractGasStationDTO _model;
        public StationWindow(AbstractGasStationDTO model)
        {
            InitializeComponent();
            _model = model;

            DataContext = _model;
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (_model is CreateGasStationDTO model)
            {
                await new HttpsService().CreateStation(model);
            }
            else
            {
                await new HttpsService().SetStation((EditGasStationDTO)_model);
            }
        }
    }
}
