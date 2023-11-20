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

namespace servisas
{

    public partial class BikeDetailWindow : Window
    {
        private Bike bike;
        private BikeRepository bikeRepository;

        public BikeDetailWindow(Bike selectedBike, BikeRepository repository)
        {
            InitializeComponent();

            bike = selectedBike;
            bikeRepository = repository;

            DataContext = bike;

            List<Bike> bikes = JsonFileHandler.LoadBikesFromJson();
            Bike loadedBike = bikes.FirstOrDefault(b => b.BikeId == selectedBike.BikeId);

            if (loadedBike != null)
            {
                bike = loadedBike;
                //load text input
                BikeIdTextBox.Text = bike.BikeId;
                ModelTextBox.Text = bike.Model;
                //show the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Good", "Average", "Bad" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };//3
                TyrePressureComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                FastenersComboBox.ItemsSource = new List<string> { "Normal", "Damaged" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Dry", "Antifreeze", "Oil" };
                //load saved choices
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;//4
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;
            }

            else
            {
                //load text input
                BikeIdTextBox.Text = bike.BikeId;
                ModelTextBox.Text = bike.Model;
                //shows the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Good", "Average", "Bad" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };//3.1
                TyrePressureComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                FastenersComboBox.ItemsSource = new List<string> { "Normal", "Damaged" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Dry", "Antifreeze", "Oil" };
                //loads saved choices, do i need this here?
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;//4.1
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //text input
            bike.BikeId = BikeIdTextBox.Text;
            bike.Model = ModelTextBox.Text;
            //combobox input
            bike.OverallCondition = OverallConditionComboBox.SelectedItem?.ToString() ?? "...";
            bike.CoolantLevel = CoolantLevelComboBox.SelectedItem?.ToString() ?? "...";
            bike.EngineOilLevel = EngineOilLevelComboBox.SelectedItem?.ToString() ?? "...";//5
            bike.TyrePressure = TyrePressureComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Fasteners = FastenersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.WaterPump = WaterPumpComboBox?.SelectedItem?.ToString() ?? "...";

            bikeRepository.UpdateBike(bike);
            JsonFileHandler.SaveBikesToJson(bikeRepository.GetAllBikes());
            this.Close();
        }

        private void DeleteBikeButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike != null)
            {
                MessageBoxResult result = MessageBox.Show($"Delete bike {bike.BikeId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    bikeRepository.DeleteBike(bike.BikeId);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Unable to delete bike.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}