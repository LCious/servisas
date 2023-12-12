using Microsoft.VisualBasic;
using servisas;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace servisas
{

    public partial class MainWindow : Window
    {
        private BikeRepository bikeRepository;

        public MainWindow()
        {
            InitializeComponent();
            bikeRepository = new BikeRepository();
            bikeRepository.LoadBikesFromJson();
            RefreshBikeList();
        }

        private void AddBikeButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(BikeIdTextBox.Text) || string.IsNullOrEmpty(ModelTextBox.Text))
            {
                MessageBox.Show("Įveskite VIN kodą ir modelį prieš kurdami keturratį.", "Klaida", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string bikeId = BikeIdTextBox.Text;
            string model = ModelTextBox.Text;

            Bike newBike = new Bike
            {
                BikeId = bikeId, // VIN
                Model = model,
                OverallCondition = "...",
                CoolantLevel = "...",
                EngineOilLevel = "...",//7
                TyrePressure = "...",
                Fasteners = "...",
                WaterPump = "...",
            };

            bikeRepository.AddBike(newBike);
            RefreshBikeList();

        }

        private void RefreshBikeList(List<Bike>? bikes = null)
        {
            BikeListBox.Items.Clear();
            bikes ??= bikeRepository.GetAllBikes();

            foreach (var bike in bikes)
            {
                BikeListBox.Items.Add(bike.BikeId);
            }
        }

        private void BikeListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (BikeListBox.SelectedItem != null)
            {
                try
                {
                    string selectedBikeId = BikeListBox.SelectedItem.ToString();
                    Bike selectedBike = bikeRepository.GetBikeById(selectedBikeId);

                    if (selectedBike.IsLocked == false)
                    {
                        BikeDetailWindow bikeDetailWindow = new BikeDetailWindow(selectedBike, bikeRepository);
                        bikeDetailWindow.ShowDialog();

                        RefreshBikeList();
                    }
                    else
                    {
                        PasswordInput passwordInput = new PasswordInput();
                        passwordInput.ShowDialog();

                        string userInput = passwordInput.EnteredPassword;
                        string userInput_hash = ComputeSha256Hash(userInput);
                        string? password_hash = JsonFileHandler.LoadHashFromJson();

                        if (userInput_hash == password_hash)
                        {
                            BikeDetailWindow bikeDetailWindow = new BikeDetailWindow(selectedBike, bikeRepository);
                            bikeDetailWindow.ShowDialog();

                            RefreshBikeList();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(userInput_hash) && passwordInput.OKButtonClicked) MessageBox.Show("Neteisingas slaptažodis..");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim();
            SearchBikes(searchTerm);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            RefreshBikeList();
        }

        private void SearchBikes(string searchTerm)
        {
            List<Bike> bikes = bikeRepository.GetAllBikes();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                bikes = bikes.Where(bike => bike.BikeId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || bike.Model.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            RefreshBikeList(bikes);
        }



        static string ComputeSha256Hash(string string_to_hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(string_to_hash));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

    }

}