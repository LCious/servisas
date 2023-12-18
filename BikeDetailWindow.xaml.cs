using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using System.Windows.Xps.Packaging;
//using System.Windows.Xps;
//using PdfSharp.Pdf;
//using System.Reflection.Metadata;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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
                PlateLightsComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BrakeLightsComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                WinchRopeComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                OtherSwitchesComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BatteryConnectionComboBox.ItemsSource = new List<string> { "Priveržti", "Atsipalaidavę" };
                BatteryVoltageComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                IdleChargingComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                RPMChargingComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };

                GearCheckComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                IdleCylinder1ComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                IdleCylinder2ComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                FanComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                TwoWDComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                FourWDComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                FourWDBlockComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };

                HingesComboBox.ItemsSource = new List<string> { "Tinkami naudoti", "Netinkami" };
                SteeringCrossComboBox.ItemsSource = new List<string> { "Tinkama naudoti", "Netinkama" };
                DriveShaftComboBox.ItemsSource = new List<string> { "Tinkamas naudoti", "Netinkamas" };
                RubbersComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                SteeringMovementComboBox.ItemsSource = new List<string> { "Nekliba", "Kliba" };
                DriveShaftCrossComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                NutsComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                WheelCheckComboBox.ItemsSource = new List<string> { "Laisvumo nėra", "Laisvumas yra" };

                BrakePadsComboBox.ItemsSource = new List<string> { "Tinkamos", "Netinkamos" };
                BrakeDiscsComboBox.ItemsSource = new List<string> { "Tinkami", "Netinkami" };
                BrakeFluidComboBox.ItemsSource = new List<string> { "Norma", "Mažiau normos" };
                BrakeHoseComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                ParkingBrakeComboBox.ItemsSource = new List<string> { "Tinkami naudoti", "Netinkami" };
                BrakeSystemComboBox.ItemsSource = new List<string> { "Sandari", "Nesandari" };

                DifferentialPRComboBox.ItemsSource = new List<string> { "Pakeista", "Patikrinta" };
                DifferentialGALComboBox.ItemsSource = new List<string> { "Pakeista", "Patikrinta" };
                LiquidsComboBox.ItemsSource = new List<string> { "Nesisunkia", "Rasoja", "Prasisunkia" };
                OilFilterComboBox.ItemsSource = new List<string> { "Pakeistas", "Nepakeistas" };
                OilChangeComboBox.ItemsSource = new List<string> { "Pakeista", "Nepakeista" };
                AirFilterComboBox.ItemsSource = new List<string> { "Keitimas", "Išvalymas" };
                VariatoriusSkyriusComboBox.ItemsSource = new List<string> { "Išvalytas", "Pakeistas" };
                VariatoriausRieboksliaiComboBox.ItemsSource = new List<string> { "Neleidžia", "Prasisunkia tepalas" };
                VariatoriausPriverzimasComboBox.ItemsSource = new List<string> { "Priveržtas", "Atsipalaidavęs" };
                VariatoriausLekstesComboBox.ItemsSource = new List<string> { "Tvarkingos", "Netinkamos" };
                FuelHoseComboBox.ItemsSource = new List<string> { "Tvarkingos", "Pažeistos" };
                FuelFilterComboBox.ItemsSource = new List<string> { "Tinkamas", "Pakeistas" };
                ExhaustComboBox.ItemsSource = new List<string> { "Tinkamos", "Pakeistos" };
                ExhaustHeatComboBox.ItemsSource = new List<string> { "Tinkamos", "Pakeistos" };

                //load saved choices
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;

                LowBeamComboBox.SelectedItem = bike.LowBeam;
                HighBeamComboBox.SelectedItem = bike.HighBeam;
                BlinkersComboBox.SelectedItem = bike.Blinkers;
                EmergencyBlinkersComboBox.SelectedItem = bike.EmergencyBlinkers;
                PlateLightsComboBox.SelectedItem = bike.PlateLights;
                BrakeLightsComboBox.SelectedItem = bike.BrakeLights;
                WinchRopeComboBox.SelectedItem = bike.WinchRope;
                OtherSwitchesComboBox.SelectedItem = bike.OtherSwitches;
                BatteryConnectionComboBox.SelectedItem = bike.BatteryConnection;
                BatteryVoltageComboBox.SelectedItem = bike.BatteryVoltage;
                IdleChargingComboBox.SelectedItem = bike.IdleCharging;
                RPMChargingComboBox.SelectedItem = bike.RPMCharging;

                GearCheckComboBox.SelectedItem = bike.GearCheck;
                IdleCylinder1ComboBox.SelectedItem = bike.IdleCylinder1;
                IdleCylinder2ComboBox.SelectedItem = bike.IdleCylinder2;
                FanComboBox.SelectedItem = bike.Fan;
                TwoWDComboBox.SelectedItem = bike.TwoWD;
                FourWDComboBox.SelectedItem = bike.FourWD;
                FourWDBlockComboBox.SelectedItem = bike.FourWDBlock;
                TestDriveCommentsTextBox.Text = bike.TestDriveComments;

                HingesComboBox.SelectedItem = bike.Hinges;
                SteeringCrossComboBox.SelectedItem = bike.SteeringCross;
                DriveShaftComboBox.SelectedItem = bike.DriveShaft;
                RubbersComboBox.SelectedItem = bike.Rubbers;
                SteeringMovementComboBox.SelectedItem = bike.SteeringMovement;
                DriveShaftCrossComboBox.SelectedItem = bike.DriveShaftCross;
                NutsComboBox.SelectedItem = bike.Nuts;
                WheelCheckComboBox.SelectedItem = bike.WheelCheck;

                BrakePadsComboBox.SelectedItem = bike.BrakePads;
                BrakeDiscsComboBox.SelectedItem = bike.BrakeDiscs;
                BrakeFluidComboBox.SelectedItem = bike.BrakeFluid;
                BrakeHoseComboBox.SelectedItem = bike.BrakeHose;
                ParkingBrakeComboBox.SelectedItem = bike.ParkingBrake;
                BrakeSystemComboBox.SelectedItem = bike.BrakeSystem;

                DifferentialPRComboBox.SelectedItem = bike.DifferentialPR;
                DifferentialGALComboBox.SelectedItem = bike.DifferentialGAL;
                LiquidsComboBox.SelectedItem = bike.Liquids;
                OilFilterComboBox.SelectedItem = bike.OilFilter;
                OilChangeComboBox.SelectedItem = bike.OilChange;
                AirFilterComboBox.SelectedItem = bike.AirFilter;
                VariatoriusSkyriusComboBox.SelectedItem = bike.VariatoriausSkyrius;
                VariatoriausRieboksliaiComboBox.SelectedItem = bike.VariatoriausRieboksliai;
                VariatoriausPriverzimasComboBox.SelectedItem = bike.VariatoriausPriverzimas;
                VariatoriausLekstesComboBox.SelectedItem = bike.VariatoriausLekstes;
                FuelHoseComboBox.SelectedItem = bike.FuelHose;
                FuelFilterComboBox.SelectedItem = bike.FuelFilter;
                ExhaustComboBox.SelectedItem = bike.Exhaust;
                ExhaustHeatComboBox.SelectedItem = bike.ExhaustHeat;

                //Additional information
                bike.UpdatedDate = DateTime.Now;
            }

            else
            {
                NrTextBox.Text = bike.Nr;
                MechanicTextBox.Text = bike.Mechanic;

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
                PlateLightsComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BrakeLightsComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                WinchRopeComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                OtherSwitchesComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                BatteryConnectionComboBox.ItemsSource = new List<string> { "Priveržti", "Atsipalaidavę" };
                BatteryVoltageComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                IdleChargingComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                RPMChargingComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };

                GearCheckComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                IdleCylinder1ComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                IdleCylinder2ComboBox.ItemsSource = new List<string> { "Atitinka", "Neatitinka" };
                FanComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                TwoWDComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                FourWDComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };
                FourWDBlockComboBox.ItemsSource = new List<string> { "Veikia", "Neveikia" };

                HingesComboBox.ItemsSource = new List<string> { "Tinkami naudoti", "Netinkami" };
                SteeringCrossComboBox.ItemsSource = new List<string> { "Tinkama naudoti", "Netinkama" };
                DriveShaftComboBox.ItemsSource = new List<string> { "Tinkamas naudoti", "Netinkamas" };
                RubbersComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                SteeringMovementComboBox.ItemsSource = new List<string> { "Nekliba", "Kliba" };
                DriveShaftCrossComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                NutsComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                WheelCheckComboBox.ItemsSource = new List<string> { "Laisvumo nėra", "Laisvumas yra" };

                BrakePadsComboBox.ItemsSource = new List<string> { "Tinkamos", "Netinkamos" };
                BrakeDiscsComboBox.ItemsSource = new List<string> { "Tinkami", "Netinkami" };
                BrakeFluidComboBox.ItemsSource = new List<string> { "Norma", "Mažiau normos" };
                BrakeHoseComboBox.ItemsSource = new List<string> { "Tinkamos naudoti", "Netinkamos" };
                ParkingBrakeComboBox.ItemsSource = new List<string> { "Tinkami naudoti", "Netinkami" };
                BrakeSystemComboBox.ItemsSource = new List<string> { "Sandari", "Nesandari" };

                DifferentialPRComboBox.ItemsSource = new List<string> { "Pakeista", "Patikrinta" };
                DifferentialGALComboBox.ItemsSource = new List<string> { "Pakeista", "Patikrinta" };
                LiquidsComboBox.ItemsSource = new List<string> { "Nesisunkia", "Rasoja", "Prasisunkia" };
                OilFilterComboBox.ItemsSource = new List<string> { "Pakeistas", "Nepakeistas" };
                OilChangeComboBox.ItemsSource = new List<string> { "Pakeista", "Nepakeista" };
                AirFilterComboBox.ItemsSource = new List<string> { "Keitimas", "Išvalymas" };
                VariatoriusSkyriusComboBox.ItemsSource = new List<string> { "Išvalytas", "Pakeistas" };
                VariatoriausRieboksliaiComboBox.ItemsSource = new List<string> { "Neleidžia", "Prasisunkia tepalas" };
                VariatoriausPriverzimasComboBox.ItemsSource = new List<string> { "Priveržtas", "Atsipalaidavęs" };
                VariatoriausLekstesComboBox.ItemsSource = new List<string> { "Tvarkingos", "Netinkamos" };
                FuelHoseComboBox.ItemsSource = new List<string> { "Tvarkingos", "Pažeistos" };
                FuelFilterComboBox.ItemsSource = new List<string> { "Tinkamas", "Pakeistas" };
                ExhaustComboBox.ItemsSource = new List<string> { "Tinkamos", "Pakeistos" };
                ExhaustHeatComboBox.ItemsSource = new List<string> { "Tinkamos", "Pakeistos" };

                //loads saved choices, do i need this here?
                OverallConditionComboBox.SelectedItem = bike.OverallCondition;
                CoolantLevelComboBox.SelectedItem = bike.CoolantLevel;
                EngineOilLevelComboBox.SelectedItem = bike.EngineOilLevel;
                TyrePressureComboBox.SelectedItem = bike.TyrePressure;
                FastenersComboBox.SelectedItem = bike.Fasteners;
                WaterPumpComboBox.SelectedItem = bike.WaterPump;

                LowBeamComboBox.SelectedItem = bike.LowBeam;
                HighBeamComboBox.SelectedItem = bike.HighBeam;
                BlinkersComboBox.SelectedItem = bike.Blinkers;
                EmergencyBlinkersComboBox.SelectedItem = bike.EmergencyBlinkers;
                PlateLightsComboBox.SelectedItem = bike.PlateLights;
                BrakeLightsComboBox.SelectedItem = bike.BrakeLights;
                WinchRopeComboBox.SelectedItem = bike.WinchRope;
                OtherSwitchesComboBox.SelectedItem = bike.OtherSwitches;
                BatteryConnectionComboBox.SelectedItem = bike.BatteryConnection;
                BatteryVoltageComboBox.SelectedItem = bike.BatteryVoltage;
                IdleChargingComboBox.SelectedItem = bike.IdleCharging;
                RPMChargingComboBox.SelectedItem = bike.RPMCharging;

                GearCheckComboBox.SelectedItem = bike.GearCheck;
                IdleCylinder1ComboBox.SelectedItem = bike.IdleCylinder1;
                IdleCylinder2ComboBox.SelectedItem = bike.IdleCylinder2;
                FanComboBox.SelectedItem = bike.Fan;
                TwoWDComboBox.SelectedItem = bike.TwoWD;
                FourWDComboBox.SelectedItem = bike.FourWD;
                FourWDBlockComboBox.SelectedItem = bike.FourWDBlock;
                TestDriveCommentsTextBox.Text = bike.TestDriveComments;

                HingesComboBox.SelectedItem = bike.Hinges;
                SteeringCrossComboBox.SelectedItem = bike.SteeringCross;
                DriveShaftComboBox.SelectedItem = bike.DriveShaft;
                RubbersComboBox.SelectedItem = bike.Rubbers;
                SteeringMovementComboBox.SelectedItem = bike.SteeringMovement;
                DriveShaftCrossComboBox.SelectedItem = bike.DriveShaftCross;
                NutsComboBox.SelectedItem = bike.Nuts;
                WheelCheckComboBox.SelectedItem = bike.WheelCheck;

                BrakePadsComboBox.SelectedItem = bike.BrakePads;
                BrakeDiscsComboBox.SelectedItem = bike.BrakeDiscs;
                BrakeFluidComboBox.SelectedItem = bike.BrakeFluid;
                BrakeHoseComboBox.SelectedItem = bike.BrakeHose;
                ParkingBrakeComboBox.SelectedItem = bike.ParkingBrake;
                BrakeSystemComboBox.SelectedItem = bike.BrakeSystem;

                DifferentialPRComboBox.SelectedItem = bike.DifferentialPR;
                DifferentialGALComboBox.SelectedItem = bike.DifferentialGAL;
                LiquidsComboBox.SelectedItem = bike.Liquids;
                OilFilterComboBox.SelectedItem = bike.OilFilter;
                OilChangeComboBox.SelectedItem = bike.OilChange;
                AirFilterComboBox.SelectedItem = bike.AirFilter;
                VariatoriusSkyriusComboBox.SelectedItem = bike.VariatoriausSkyrius;
                VariatoriausRieboksliaiComboBox.SelectedItem = bike.VariatoriausRieboksliai;
                VariatoriausPriverzimasComboBox.SelectedItem = bike.VariatoriausPriverzimas;
                VariatoriausLekstesComboBox.SelectedItem = bike.VariatoriausLekstes;
                FuelHoseComboBox.SelectedItem = bike.FuelHose;
                FuelFilterComboBox.SelectedItem = bike.FuelFilter;
                ExhaustComboBox.SelectedItem = bike.Exhaust;
                ExhaustHeatComboBox.SelectedItem = bike.ExhaustHeat;

                bike.CreatedDate = selectedBike.CreatedDate;
                bike.UpdatedDate = selectedBike.UpdatedDate;
            }

        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            string pdfFilePath = "123.pdf";

            try
            {
                var writer = new PdfWriter($"{bike.BikeId}.pdf");
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                document.Add(new iText.Layout.Element.Paragraph("Hello World!"));
                document.Close();

                /*              using (FileStream fs = new(pdfFilePath, FileMode.Create))
                              {
                                  using (PdfWriter writer = new(fs))
                                  {
                                      using (PdfDocument pdf = new(writer))
                                      {
                                          Document document = new(pdf);

                                          // Add bike information to the PDF
                                          document.Add(new iText.Layout.Element.Paragraph("Bike ID: 123"));
                                          document.Add(new iText.Layout.Element.Paragraph("Model: Mountain Bike"));
                                          document.Add(new iText.Layout.Element.Paragraph("Date of Service: 2023-01-01"));

                                        //document.Add(new iText.Layout.Element.Paragraph($"Bike ID: {bike.BikeId}"));
                                        //document.Add(new iText.Layout.Element.Paragraph($"Model: {bike.Model}"));
                                        //document.Add(new iText.Layout.Element.Paragraph($"Date of Service: {bike.DateService}"));

                                          document.Close();
                                      }
                                  }
                              }*/

                MessageBox.Show("Exported to PDF successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n{ex.StackTrace}\n Bike ID: {bike.BikeId}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bike.Nr = NrTextBox.Text;
            bike.Mechanic = MechanicTextBox.Text;

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

            bike.OverallCondition = OverallConditionComboBox.SelectedItem?.ToString() ?? "...";
            bike.CoolantLevel = CoolantLevelComboBox.SelectedItem?.ToString() ?? "...";
            bike.EngineOilLevel = EngineOilLevelComboBox.SelectedItem?.ToString() ?? "...";
            bike.TyrePressure = TyrePressureComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Fasteners = FastenersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.WaterPump = WaterPumpComboBox?.SelectedItem?.ToString() ?? "...";

            bike.LowBeam = LowBeamComboBox?.SelectedItem?.ToString() ?? "...";
            bike.HighBeam = HighBeamComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Blinkers = BlinkersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.EmergencyBlinkers = EmergencyBlinkersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.PlateLights = PlateLightsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BrakeLights = BrakeLightsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.WinchRope = WinchRopeComboBox?.SelectedItem?.ToString() ?? "...";
            bike.OtherSwitches = OtherSwitchesComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BatteryConnection = BatteryConnectionComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BatteryVoltage = BatteryVoltageComboBox?.SelectedItem?.ToString() ?? "...";
            bike.IdleCharging = IdleChargingComboBox?.SelectedItem?.ToString() ?? "...";
            bike.RPMCharging = RPMChargingComboBox?.SelectedItem?.ToString() ?? "...";

            bike.GearCheck = GearCheckComboBox?.SelectedItem?.ToString() ?? "...";
            bike.IdleCylinder1 = IdleCylinder1ComboBox?.SelectedItem?.ToString() ?? "...";
            bike.IdleCylinder2 = IdleCylinder2ComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Fan = FanComboBox?.SelectedItem?.ToString() ?? "...";
            bike.TwoWD = TwoWDComboBox?.SelectedItem?.ToString() ?? "...";
            bike.FourWD = FourWDComboBox?.SelectedItem?.ToString() ?? "...";
            bike.FourWDBlock = FourWDBlockComboBox?.SelectedItem?.ToString() ?? "...";
            bike.TestDriveComments = TestDriveCommentsTextBox.Text;

            bike.Hinges = HingesComboBox?.SelectedItem?.ToString() ?? "...";
            bike.SteeringCross = SteeringCrossComboBox?.SelectedItem?.ToString() ?? "...";
            bike.DriveShaft = DriveShaftComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Rubbers = RubbersComboBox?.SelectedItem?.ToString() ?? "...";
            bike.SteeringMovement = SteeringMovementComboBox?.SelectedItem?.ToString() ?? "...";
            bike.DriveShaftCross = DriveShaftCrossComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Nuts = NutsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.WheelCheck = WheelCheckComboBox?.SelectedItem?.ToString() ?? "...";

            bike.BrakePads = BrakePadsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BrakeDiscs = BrakeDiscsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BrakeFluid = BrakeFluidComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BrakeHose = BrakeHoseComboBox?.SelectedItem?.ToString() ?? "...";
            bike.ParkingBrake = ParkingBrakeComboBox?.SelectedItem?.ToString() ?? "...";
            bike.BrakeSystem = BrakeSystemComboBox?.SelectedItem?.ToString() ?? "...";

            bike.DifferentialPR = DifferentialPRComboBox?.SelectedItem?.ToString() ?? "...";
            bike.DifferentialGAL = DifferentialGALComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Liquids = LiquidsComboBox?.SelectedItem?.ToString() ?? "...";
            bike.OilFilter = OilFilterComboBox?.SelectedItem?.ToString() ?? "...";
            bike.OilChange = OilChangeComboBox?.SelectedItem?.ToString() ?? "...";
            bike.AirFilter = AirFilterComboBox?.SelectedItem?.ToString() ?? "...";
            bike.VariatoriausSkyrius = VariatoriusSkyriusComboBox?.SelectedItem?.ToString() ?? "...";
            bike.VariatoriausRieboksliai = VariatoriausRieboksliaiComboBox?.SelectedItem?.ToString() ?? "...";
            bike.VariatoriausPriverzimas = VariatoriausPriverzimasComboBox?.SelectedItem?.ToString() ?? "...";
            bike.VariatoriausLekstes = VariatoriausLekstesComboBox?.SelectedItem?.ToString() ?? "...";
            bike.FuelHose = FuelHoseComboBox?.SelectedItem?.ToString() ?? "...";
            bike.FuelFilter = FuelFilterComboBox?.SelectedItem?.ToString() ?? "...";
            bike.Exhaust = ExhaustComboBox?.SelectedItem?.ToString() ?? "...";
            bike.ExhaustHeat = ExhaustHeatComboBox?.SelectedItem?.ToString() ?? "...";

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