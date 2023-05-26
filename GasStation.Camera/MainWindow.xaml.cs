using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GasStation.Camera
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

        private void Success_Click(object sender, RoutedEventArgs e)
        {
            _dialog.Multiselect = false;

            if (_dialog.ShowDialog() == false)
            {
                return;
            }

            var file = _dialog.FileName;
        }


        private readonly OpenFileDialog _dialog = new()
        {
            Filter = @"Изображения|*.PNG;*.BMP;*.JPG;*.GIF"
        };

        private async void Failure_Click(object sender, RoutedEventArgs e)
        {
            _dialog.Multiselect = true;

            if (_dialog.ShowDialog() == false)
            {
                return;
            }

            if (_dialog.FileNames.Length > 3)
            {
                MessageBox.Show("Вы выбрали слишком много файлов, мы выберем первые 3");
            }

            if (_dialog.FileNames.Length < 3)
            {
                MessageBox.Show("Вы выбрали недостаточно файлов(");
            }

            var i = 0;

            List<byte[]> data = new();

            foreach (var file in _dialog.FileNames)
            {
                if (i == 3)
                    break;

                data.Add(await File.ReadAllBytesAsync(file));

                i++;
            }

            new UndefinedSituationWindow(data).ShowDialog();
        }
    }
}
