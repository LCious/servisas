using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace servisas
{
    [Serializable]
    public class Bike // 1
    {
        //Pirma lentele, bendra informacija
        [JsonProperty("DateService")]
        public string DateService { get; set; } = "";

        [JsonProperty("Model")]
        public string Model { get; set; } = "";

        [JsonProperty("Phone")]
        public string Phone { get; set; } = "";

        [JsonProperty("Mileage")]
        public string Mileage { get; set; } = "";

        [JsonProperty("MotoH")]
        public string MotoH { get; set; } = "";

        [JsonProperty("BikeId")]
        public string BikeId { get; set; } = ""; //VIN

        [JsonProperty("RegistrationPlate")]
        public string RegistrationPlate { get; set; } = "";

        [JsonProperty("ManufactureYear")]
        public string ManufactureYear { get; set; } = "";

        //Antra lentele, taip/ne
        [JsonProperty("ManufactureUpdate")]
        public string ManufactureUpdate { get; set; } = "";

        [JsonProperty("GuaranteeUpdate")]
        public string GuaranteeUpdate { get; set; } = "";

        [JsonProperty("RR")]
        public string RR { get; set; } = "";

        //Trecia lentele, negarantiniai remonto darbai
        [JsonProperty("NonGuaranteeServices")]
        public ObservableCollection<ServiceEntry> NonGuaranteeServices { get; set; } = new ObservableCollection<ServiceEntry>();

        //Ketvirta lentele, negarantiniu darbu laikai
        [JsonProperty("NonGuaranteeServicesTime")]
        public ObservableCollection<ServiceEntryTime> NonGuaranteeServicesTime { get; set; } = new ObservableCollection<ServiceEntryTime>();

        //Penkta lentele, dalys, kaina, kita info

        //Sesta lentele, garantiniai remonto darbai / gamykliniai atnaujinimai

        //Septinta lentele, dalys, kita info

        //Pradinis patikrinimas
        [JsonProperty("OverallCondition")]
        public string OverallCondition { get; set; } = "";

        [JsonProperty("CoolantLevel")]
        public string CoolantLevel { get; set; } = "";

        [JsonProperty("EngineOilLevel")]
        public string EngineOilLevel { get; set; } = "";

        [JsonProperty("TyrePressure")]
        public string TyrePressure { get; set; } = "";

        [JsonProperty("Fasteners")]
        public string Fasteners { get; set; } = "";

        [JsonProperty("WaterPump")]
        public string WaterPump { get; set; } = "";

        //Elektros, jungikliu patikra
        [JsonProperty("LowBeam")]
        public string LowBeam { get; set; } = "";

        [JsonProperty("HighBeam")]
        public string HighBeam { get; set; } = "";

        [JsonProperty("Blinkers")]
        public string Blinkers { get; set; } = "";

        [JsonProperty("EmergencyBlinkers")]
        public string EmergencyBlinkers { get; set; } = "";


        //Additional information
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("IsLocked")]
        public bool IsLocked {  get; set; }

        //Constructor
        public Bike()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            IsLocked = false;
        }

        //Additional functions
        public void AddNonGuaranteeService (ServiceEntry service)
        {
            NonGuaranteeServices.Add(service);
        }

        public void AddNonGuaranteeServiceTime(ServiceEntryTime service)
        {
            NonGuaranteeServicesTime.Add(service);
        }

    }

    // Darbu klases

    //Negarantiniai darbai
    [Serializable]
    public class ServiceEntry : INotifyPropertyChanged
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged(nameof(Code));
                }
            }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ServiceEntry()
        {
            Number = "";
            Description = "";
            Code = "";
            Price = "";
        }

    }

    //Negarantiniu darbu laikai
    [Serializable]
    public class ServiceEntryTime : INotifyPropertyChanged
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }

        private string _start;
        public string Start
        {
            get { return _start; }
            set
            {
                if (_start != value)
                {
                    _start = value;
                    OnPropertyChanged(nameof(Start));
                }
            }
        }

        private string _end;
        public string End
        {
            get { return _end; }
            set
            {
                if (_end != value)
                {
                    _end = value;
                    OnPropertyChanged(nameof(End));
                }
            }
        }

        private string _service;
        public string Service
        {
            get { return _service; }
            set
            {
                if (_service != value)
                {
                    _service = value;
                    OnPropertyChanged(nameof(Service));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ServiceEntryTime()
        {
            Number = "";
            Start = "";
            End = "";
            Service = "";
        }
    }
}