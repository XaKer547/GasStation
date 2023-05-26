using GasStation.Domain.View;
using System.Collections.Generic;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GasStation.Camera
{
    /// <summary>
    /// Логика взаимодействия для UndefinedSituationWindow.xaml
    /// </summary>
    public partial class UndefinedSituationWindow : Window
    {
        public RegistrationMarkViewModel ViewModel { get; set; } = new();

        public UndefinedSituationWindow(List<byte[]> bytes)
        {
            InitializeComponent();

            ViewModel.AvaibleImages = bytes;

            DataContext = ViewModel;
            SystemSounds.Hand.Play();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(CarNumberTxb))
            {
                MessageBox.Show("Введите номер полностью");
                return;
            }

            if (Validation.GetHasError(CarRegionTxb))
            {
                MessageBox.Show("Укажите регион полностью");
                return;
            }

            CarNumberBoxPanel.Visibility = Visibility.Collapsed;
            CarImagePanel.Visibility = Visibility.Visible;
        }

        private void CarNumberTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (CarNumberTxb.Text.Length is 0 or > 3)
            {
                e.Handled = !Regex.IsMatch(e.Text, @"[A-Za-z]");
            }
            else
            {
                e.Handled = !Regex.IsMatch(e.Text, @"\d");
            }
        }

        private void CarRegionTxb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.CorrectImage is null)
            {
                MessageBox.Show("Пожалуйста выберите изображение");
                return;
            }

            //отправляй в бд
        }
    }
}
