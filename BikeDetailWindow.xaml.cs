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

            //text input
            BikeIdTextBox.Text = bike.BikeId;
            ModelTextBox.Text = bike.Model;
            //combobox input
            OverallConditionComboBox.ItemsSource = new List<string> { "Good", "Average", "Bad" };
            CoolantLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
            // TODO: this part does not work:
            // [
            OverallConditionComboBox.SelectedItem = bike.OverallCondition;
            CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
            // ]
            // DataContext = bike;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //text input
            bike.BikeId = BikeIdTextBox.Text;
            bike.Model = ModelTextBox.Text;
            //combobox input
            bike.OverallCondition = OverallConditionComboBox.SelectedItem?.ToString() ?? "...";
            bike.CoolantLevel = CoolantLevelComboBox.SelectedItem?.ToString() ?? "...";

            bikeRepository.UpdateBike(bike);
            this.Close();
        }

    }
}
