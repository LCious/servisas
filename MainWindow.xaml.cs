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
                MessageBox.Show("ID and Model must not be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string bikeId = BikeIdTextBox.Text;
            string model = ModelTextBox.Text;

            Bike newBike = new Bike
            {
                BikeId = bikeId,
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

        private string GetSelectedBikeId()
        {
            if (BikeListBox.SelectedItem != null)
            {
                return BikeListBox.SelectedItem.ToString();
            }
            else
            {
                return string.Empty;
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

                    BikeDetailWindow bikeDetailWindow = new BikeDetailWindow(selectedBike, bikeRepository);
                    //bikeDetailWindow.DataContext = selectedBike;
                    bikeDetailWindow.ShowDialog();

                    RefreshBikeList();
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
                bikes = bikes.Where(bike => bike.BikeId.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                             bike.Model.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                             .ToList();
            }

            RefreshBikeList(bikes);
        }

    }

}