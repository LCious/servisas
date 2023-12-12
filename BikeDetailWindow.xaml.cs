using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                DataContext = loadedBike;

                NrTextBox.Text = bike.Nr;
                MechanicTextBox.Text = bike.Mechanic;

                //load text input
                DateServiceTextBox.Text = bike.DateService;
                ModelTextBox.Text = bike.Model;
                PhoneTextBox.Text = bike.Phone;
                BikeIdTextBox.Text = bike.BikeId;
                MileageTextBox.Text = bike.Mileage;
                MotoHTextBox.Text = bike.MotoH;
                RegistrationPlateTextBox.Text = bike.RegistrationPlate;
                ManufactureYearTextBox.Text = bike.ManufactureYear;

                ManufactureUpdateTextBox.Text = bike.ManufactureUpdate;
                GuaranteeUpdateTextBox.Text = bike.GuaranteeUpdate;
                RRTextBox.Text = bike.RR;

                //show the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Gera", "Apgadinta" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                TyrePressureComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                FastenersComboBox.ItemsSource = new List<string> { "Geri", "Apgadinti" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Sausa", "Antifrizas", "Tepalas" };

                LowBeamComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                HighBeamComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BlinkersComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                EmergencyBlinkersComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };

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
                NrTextBox.Text = bike.Nr;
                MechanicTextBox.Text = bike.Mechanic;

                //load text input
                DateServiceTextBox.Text = bike.DateService;
                ModelTextBox.Text = bike.Model;
                BikeIdTextBox.Text = bike.BikeId;
                PhoneTextBox.Text = bike.Phone;
                MileageTextBox.Text = bike.Mileage;
                MotoHTextBox.Text = bike.MotoH;
                RegistrationPlateTextBox.Text = bike.RegistrationPlate;
                ManufactureYearTextBox.Text = bike.ManufactureYear;

                ManufactureUpdateTextBox.Text = bike.ManufactureUpdate;
                GuaranteeUpdateTextBox.Text = bike.GuaranteeUpdate;
                RRTextBox.Text = bike.RR;

                //shows the choices
                OverallConditionComboBox.ItemsSource = new List<string> { "Gera", "Apgadinta" };
                CoolantLevelComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                EngineOilLevelComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                TyrePressureComboBox.ItemsSource = new List<string> { "Norma", "Žemiau normos", "Aukščiau normos" };
                FastenersComboBox.ItemsSource = new List<string> { "Geri", "Apgadinti" };
                WaterPumpComboBox.ItemsSource = new List<string> { "Sausa", "Antifrizas", "Tepalas" };

                LowBeamComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                HighBeamComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BlinkersComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                EmergencyBlinkersComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };

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
            bike.Nr = NrTextBox.Text;
            bike.Mechanic = MechanicTextBox.Text;

            //text input
            bike.DateService = DateServiceTextBox.Text;
            bike.Model = ModelTextBox.Text;
            bike.BikeId = BikeIdTextBox.Text;
            bike.Phone = PhoneTextBox.Text;
            bike.Mileage = MileageTextBox.Text;
            bike.MotoH = MotoHTextBox.Text;
            bike.RegistrationPlate = RegistrationPlateTextBox.Text;
            bike.ManufactureYear = ManufactureYearTextBox.Text;

            bike.ManufactureUpdate = ManufactureUpdateTextBox.Text;
            bike.GuaranteeUpdate = GuaranteeUpdateTextBox.Text;
            bike.RR = RRTextBox.Text;

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
                MessageBoxResult result = MessageBox.Show($"Ar tikrai norite ištrinti keturratį {bike.BikeId}?", "Patvirtinimas", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    bikeRepository.DeleteBike(bike.BikeId);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Keturratis neištrintas..", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        }

        private void RemoveNonGuaranteeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike.NonGuaranteeServices.Count > 0)
            {
                ServiceEntry lastService = bike.NonGuaranteeServices.Last();
                bike.RemoveNonGuaranteeService(lastService);
            }
            else
            {
                MessageBox.Show("Tuščia..");
            }
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

        }

        private void RemoveNonGuaranteeServiceTimeButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike.NonGuaranteeServicesTime.Count > 0)
            {
                ServiceEntryTime lastService = bike.NonGuaranteeServicesTime.Last();
                bike.RemoveNonGuaranteeServiceTime(lastService);
            }
            else
            {
                MessageBox.Show("Tuščia..");
            }
        }

        private void AddServicePartButton_Click(Object sender, RoutedEventArgs e)
        {
            ServiceEntryPart newService = new ServiceEntryPart();
            bike.AddNonGuaranteeServicePart(newService);

            StackPanel servicePanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            TextBox numberTextBox = new TextBox();
            TextBox partTextBox = new TextBox();
            TextBox accNumberTextBox = new TextBox();
            TextBox partNumberTextBox = new TextBox();
            TextBox quantityTextBox = new TextBox();
            TextBox priceTextBox = new TextBox();

            numberTextBox.SetBinding(TextBox.TextProperty, new Binding("Number") { Source = newService });
            partTextBox.SetBinding(TextBox.TextProperty, new Binding("Part") { Source= newService });
            accNumberTextBox.SetBinding(TextBox.TextProperty, new Binding("AccNumber") { Source = newService });
            partNumberTextBox.SetBinding(TextBox.TextProperty, new Binding("PartNumber") { Source = newService });
            quantityTextBox.SetBinding(TextBox.TextProperty, new Binding("Quantity") { Source = newService });
            priceTextBox.SetBinding(TextBox.TextProperty, new Binding("Price") { Source = newService });
        }

        private void RemoveServicePartButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike.NonGuaranteeServicesPart.Count > 0)
            {
                ServiceEntryPart lastService = bike.NonGuaranteeServicesPart.Last();
                bike.RemoveNonGuaranteeServicePart(lastService);
            }
            else
            {
                MessageBox.Show("Tuščia..");
            }
        }

        private void AddGuaranteeServiceButton_Click(Object sender, RoutedEventArgs e)
        {
            ServiceEntryGuarantee newService = new ServiceEntryGuarantee();
            bike.AddGuaranteeService(newService);

            StackPanel servicePanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            TextBox numberTextBox = new TextBox();
            TextBox descriptionTextBox = new TextBox();
            TextBox timeTextBox = new TextBox();


            numberTextBox.SetBinding(TextBox.TextProperty, new Binding("Number") { Source = newService });
            descriptionTextBox.SetBinding(TextBox.TextProperty, new Binding("Description") { Source = newService });
            timeTextBox.SetBinding(TextBox.TextProperty, new Binding("Time") { Source = newService });
        }

        private void RemoveGuaranteeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike.GuaranteeServices.Count > 0)
            {
                ServiceEntryGuarantee lastService = bike.GuaranteeServices.Last();
                bike.RemoveGuaranteeService(lastService);
            }
            else
            {
                MessageBox.Show("Tuščia..");
            }
        }

        private void AddGuaranteeServicePartButton_Click(Object sender, RoutedEventArgs e)
        {
            ServiceEntryGuaranteePart newService = new ServiceEntryGuaranteePart();
            bike.AddGuaranteeServicePart(newService);

            StackPanel servicePanel = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            TextBox numberTextBox = new TextBox();
            TextBox partTextBox = new TextBox();
            TextBox accNumberTextBox = new TextBox();
            TextBox partNumberTextBox = new TextBox();
            TextBox quantityTextBox = new TextBox();

            numberTextBox.SetBinding(TextBox.TextProperty, new Binding("Number") { Source = newService });
            partTextBox.SetBinding(TextBox.TextProperty, new Binding("Part") { Source = newService });
            accNumberTextBox.SetBinding(TextBox.TextProperty, new Binding("AccNumber") { Source = newService });
            partNumberTextBox.SetBinding(TextBox.TextProperty, new Binding("PartNumber") { Source = newService });
            quantityTextBox.SetBinding(TextBox.TextProperty, new Binding("Quantity") { Source = newService });
        }

        private void RemoveGuaranteeServicePartButton_Click(object sender, RoutedEventArgs e)
        {
            if (bike.GuaranteeServicesPart.Count > 0)
            {
                ServiceEntryGuaranteePart lastService = bike.GuaranteeServicesPart.Last();
                bike.RemoveGuaranteeServicePart(lastService);
            }
            else
            {
                MessageBox.Show("Tuščia..");
            }
        }

    }
}