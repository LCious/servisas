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
                //DataContext = loadedBike;
                //load text input
                DateServiceTextBox.Text = bike.DateService;
                ModelTextBox.Text = bike.Model;
                PhoneTextBox.Text = bike.Phone;
                BikeIdTextBox.Text = bike.BikeId;
                MileageTextBox.Text = bike.Mileage;
                MotoHTextBox.Text = bike.MotoH;
                RegistrationPlateTextBox.Text = bike.RegistrationPlate;
                ManufactureYearTextBox.Text = bike.ManufactureYear;
                //show the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Good", "Average", "Bad" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };//3
                TyrePressureComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                FastenersComboBox.ItemsSource = new List<string> { "Normal", "Damaged" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Dry", "Antifreeze", "Oil" };

                LowBeamComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                HighBeamComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                BlinkersComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                EmergencyBlinkersComboBox.ItemsSource = new List<string> { "Working", "Not working" };

                //load saved choices
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;//4
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;

                LowBeamComboBox.SelectedItem = bike.LowBeam;
                HighBeamComboBox.SelectedItem = bike.HighBeam;
                BlinkersComboBox.SelectedItem = bike.Blinkers;
                EmergencyBlinkersComboBox.SelectedItem = bike.EmergencyBlinkers;
                //Third table
                
                //Additional information
                bike.UpdatedDate = DateTime.Now;
            }

            else
            {
                //load text input
                DateServiceTextBox.Text = bike.DateService;
                ModelTextBox.Text = bike.Model;
                BikeIdTextBox.Text = bike.BikeId;
                PhoneTextBox.Text = bike.Phone;
                MileageTextBox.Text = bike.Mileage;
                MotoHTextBox.Text = bike.MotoH;
                RegistrationPlateTextBox.Text = bike.RegistrationPlate;
                ManufactureYearTextBox.Text = bike.ManufactureYear;
                //shows the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Good", "Average", "Bad" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };//3.1
                TyrePressureComboBox.ItemsSource = new List<string> { "Above", "Normal", "Below" };
                FastenersComboBox.ItemsSource = new List<string> { "Normal", "Damaged" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Dry", "Antifreeze", "Oil" };

                LowBeamComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                HighBeamComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                BlinkersComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                EmergencyBlinkersComboBox.ItemsSource = new List<string> { "Working", "Not working" };
                //loads saved choices, do i need this here?
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;//4.1
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;

                LowBeamComboBox.SelectedItem = bike.LowBeam;
                HighBeamComboBox.SelectedItem = bike.HighBeam;
                BlinkersComboBox.SelectedItem = bike.Blinkers;
                EmergencyBlinkersComboBox.SelectedItem = bike.EmergencyBlinkers;
                //Additional information
                bike.CreatedDate = selectedBike.CreatedDate;
                bike.UpdatedDate = selectedBike.UpdatedDate;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //text input
            bike.DateService = DateServiceTextBox.Text;
            bike.Model = ModelTextBox.Text;
            bike.BikeId = BikeIdTextBox.Text;
            bike.Phone = PhoneTextBox.Text;
            bike.Mileage = MileageTextBox.Text;
            bike.MotoH = MotoHTextBox.Text;
            bike.RegistrationPlate = RegistrationPlateTextBox.Text;
            bike.ManufactureYear = ManufactureYearTextBox.Text;

            //combobox input
            bike.OverallCondition = OverallConditionComboBox.SelectedItem?.ToString() ?? "...";
            bike.CoolantLevel = CoolantLevelComboBox.SelectedItem?.ToString() ?? "...";
            bike.EngineOilLevel = EngineOilLevelComboBox.SelectedItem?.ToString() ?? "...";//5
            bike.TyrePressure = TyrePressureComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Fasteners = FastenersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.WaterPump = WaterPumpComboBox?.SelectedItem?.ToString() ?? "...";

            bike.LowBeam = LowBeamComboBox?.SelectedItem?.ToString() ?? "...";
            bike.HighBeam = HighBeamComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Blinkers = BlinkersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.EmergencyBlinkers = EmergencyBlinkersComboBox?.SelectedItem?.ToString() ?? "...";

            bike.UpdatedDate = DateTime.Now;

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

        private void LockButtonClick(object sender, RoutedEventArgs e)
        {
            if (bike != null)
            {
                bike.IsLocked = true;
            }
        }

        private void UnlockButtonClick(object sender, RoutedEventArgs e)
        {
            if (bike != null)
            {
                bike.IsLocked = false;
            }
        }

        private void AddServiceButton_Click(Object sender, RoutedEventArgs e)
        {

            // Create a new service entry
            ServiceEntry newService = new ServiceEntry();
            bike.AddNonGuaranteeService(newService);

            StackPanel servicePanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            // Create textboxes for each property
            TextBox numberTextBox = new TextBox();
            TextBox descriptionTextBox = new TextBox();
            TextBox codeTextBox = new TextBox();
            TextBox priceTextBox = new TextBox();

            // Bind textboxes to ServiceEntry properties
            numberTextBox.SetBinding(TextBox.TextProperty, new Binding("Number") { Source = newService });
            descriptionTextBox.SetBinding(TextBox.TextProperty, new Binding("Description") { Source = newService });
            codeTextBox.SetBinding(TextBox.TextProperty, new Binding("Code") { Source = newService });
            priceTextBox.SetBinding(TextBox.TextProperty, new Binding("Price") { Source = newService });

            // Add textboxes to the panel
/*            NewServiceEntryPanel.Children.Add(numberTextBox);
            NewServiceEntryPanel.Children.Add(descriptionTextBox);
            NewServiceEntryPanel.Children.Add(codeTextBox);
            NewServiceEntryPanel.Children.Add(priceTextBox);

            NewServiceEntryPanel.Children.Add(servicePanel);*/

        }

        private void AddServiceTimeButton_Click(Object sender, RoutedEventArgs e)
        {

            // Create a new service entry
            ServiceEntryTime newService = new ServiceEntryTime();
            bike.AddNonGuaranteeServiceTime(newService);

            StackPanel servicePanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            // Create textboxes for each property
            TextBox numberTextBox = new TextBox();
            TextBox startTextBox = new TextBox();
            TextBox endTextBox = new TextBox();
            TextBox serviceTextBox = new TextBox();

            // Bind textboxes to ServiceEntry properties
            numberTextBox.SetBinding(TextBox.TextProperty, new Binding("Number") { Source = newService });
            startTextBox.SetBinding(TextBox.TextProperty, new Binding("Start") { Source = newService });
            endTextBox.SetBinding(TextBox.TextProperty, new Binding("End") { Source = newService });
            serviceTextBox.SetBinding(TextBox.TextProperty, new Binding("Service") { Source = newService });

            // Add textboxes to the panel
/*            NewServiceEntryPanel.Children.Add(numberTextBox);
            NewServiceEntryPanel.Children.Add(descriptionTextBox);
            NewServiceEntryPanel.Children.Add(codeTextBox);
            NewServiceEntryPanel.Children.Add(priceTextBox);

            NewServiceEntryPanel.Children.Add(servicePanel);*/

        }

    }
}