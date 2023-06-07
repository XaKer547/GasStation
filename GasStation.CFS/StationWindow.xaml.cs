using GasStation.Application.Server;
using GasStation.Domain;
using GasStation.Domain.Models.DTOs.Abstract;
using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Models.DTOs.GasStationDTO;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Net.Sockets;
using System.Text;

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

            StartServers();

            DataContext = _model;
        }

        private async void StartServers()
        {
            int id = ((EditGasStationDTO)_model).Id;

            if (id == 0)
                return;

            var HttpServer = new HttpServer(Routes.STATION_URL + id + "/");

            var TcpServer = new TcpServer(IPAddress.Parse("127.0.0.1"), 10200 + id);

            await HttpServer.Start(new()
            {
                {"POST", Ae },
                {"GET", Ae },
                {"PUT", Ae },
            });


            await TcpServer.Start(Ae);
        }

        public static void Ae()
        {
            throw new NotImplementedException();
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient(new HttpClientHandler() { UseProxy = false })
            {
                BaseAddress = new(Routes.API_URL)
            };

            var tcp = new TcpClient();

            tcp.Connect(IPAddress.Parse("127.0.0.1"), 10212);

            var buffer = new byte[1024];

            var a = Encoding.UTF8.GetBytes("Есус реален");

            //https://metanit.com/sharp/net/3.4.php
            tcp.Client.BeginSend(a)

            //var response = await client.PostAsJsonAsync(Routes.STATION_URL + 12 + "/", new FuelDTO() { Amount = 12 });

            //var b = await _serverService.StartTCPServer(IPAddress.Parse("127.0.0.1"), 102XX);

            //if (_model is CreateGasStationDTO model)
            //{
            //    await client.PostAsJsonAsync("setStation", model);

            //}
            //else
            //{
            //    await client.PutAsJsonAsync("setStation", _model);
            //}
        }
    }
}
