using servisas;
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
        }

        private void AddBikeButton_Click(object sender, RoutedEventArgs e)
        {
            string bikeId = BikeIdTextBox.Text;
            string model = ModelTextBox.Text;

            Bike newBike = new Bike
            {
                BikeId = bikeId,
                Model = model,
                OverallCondition = "...",
                CoolantLevel = "..."
            };

            bikeRepository.AddBike(newBike);
            RefreshBikeList();
        }

        private void DeleteBikeButton_Click(Object sender, RoutedEventArgs e)
        {
            string selectedBikeId = GetSelectedBikeId();
            
            if(!string.IsNullOrEmpty(selectedBikeId))
            {
                MessageBoxResult result = MessageBox.Show($"Delete bike {selectedBikeId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if(result == MessageBoxResult.Yes)
                {
                    bikeRepository.DeleteBike(selectedBikeId);
                    RefreshBikeList();
                }
            }
            else
            {
                MessageBox.Show("Select bike to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void RefreshBikeList()
        {
            BikeListBox.Items.Clear();
            List<Bike> bikes = bikeRepository.GetAllBikes();
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

    }

}
