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
    public class Bike : INotifyPropertyChanged // 1
    {
        [JsonProperty("Nr")]
        public string Nr { get; set; } = "";

        [JsonProperty("Mechanic")]
        public string Mechanic { get; set; } = "";

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
        [JsonProperty("NonGuaranteeServicesPart")]
        public ObservableCollection<ServiceEntryPart> NonGuaranteeServicesPart { get; set; } = new ObservableCollection<ServiceEntryPart>();

        //Sesta lentele, garantiniai remonto darbai / gamykliniai atnaujinimai
        [JsonProperty("GuaranteeServices")]
        public ObservableCollection<ServiceEntryGuarantee> GuaranteeServices { get; set; } = new ObservableCollection<ServiceEntryGuarantee>();

        //Septinta lentele, dalys, kita info
        [JsonProperty("GuaranteeServicesPart")]
        public ObservableCollection<ServiceEntryGuaranteePart> GuaranteeServicesPart { get; set; } = new ObservableCollection<ServiceEntryGuaranteePart>();

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
        public bool IsLocked
        {
            get { return _isLocked; }
            set
            {
                if(_isLocked != value)
                {
                    _isLocked = value;
                    OnPropertyChanged(nameof(IsLocked));
                }
            }
        }
        private bool _isLocked;

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

        public void RemoveNonGuaranteeService (ServiceEntry service)
        {
            NonGuaranteeServices.Remove(service);
        }

        public void AddNonGuaranteeServiceTime (ServiceEntryTime service)
        {
            NonGuaranteeServicesTime.Add(service);
        }

        public void RemoveNonGuaranteeServiceTime (ServiceEntryTime service)
        {
            NonGuaranteeServicesTime.Remove(service);
        }

        public void AddNonGuaranteeServicePart (ServiceEntryPart service)
        {
            NonGuaranteeServicesPart.Add(service);
        }

        public void RemoveNonGuaranteeServicePart (ServiceEntryPart service)
        {
            NonGuaranteeServicesPart.Remove(service);
        }

        public void AddGuaranteeService (ServiceEntryGuarantee service)
        {
            GuaranteeServices.Add(service);
        }

        public void RemoveGuaranteeService (ServiceEntryGuarantee service)
        {
            GuaranteeServices.Remove(service);
        }

        public void AddGuaranteeServicePart (ServiceEntryGuaranteePart service)
        {
            GuaranteeServicesPart.Add(service);
        }

        public void RemoveGuaranteeServicePart (ServiceEntryGuaranteePart service)
        {
            GuaranteeServicesPart.Remove(service);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    //Negarantiniu darbu dalys
    [Serializable]
    public class ServiceEntryPart : INotifyPropertyChanged
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

        private string _part;
        public string Part
        {
            get { return _part; }
            set
            {
                if (_part != value)
                {
                    _part = value;
                    OnPropertyChanged(nameof(Part));
                }
            }
        }

        private string _accNumber;
        public string AccNumber
        {
            get { return _accNumber;  }
            set
            {
                if (_accNumber != value)
                {
                    _accNumber = value;
                    OnPropertyChanged(nameof(AccNumber));
                }
            }
        }

        private string _partNumber;
        public string PartNumber
        {
            get { return _partNumber; }
            set
            {
                if (value != _partNumber)
                {
                    _partNumber = value;
                    OnPropertyChanged(nameof(PartNumber));
                }
            }
        }

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set
            {
                if (value != _price)
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

        public ServiceEntryPart()
        {
            Number = "";
            Part = "";
            AccNumber = "";
            PartNumber = "";
            Quantity = "";
            Price = "";
        }
    }

    //Garantiniai darbai
    [Serializable]
    public class ServiceEntryGuarantee : INotifyPropertyChanged
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                if (value != _number)
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
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                if (value != _time)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ServiceEntryGuarantee()
        {
            Number = "";
            Description = "";
            Time = "";
        }
    }

    //Garantiniu darbu dalys
    [Serializable]
    public class ServiceEntryGuaranteePart : INotifyPropertyChanged
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

        private string _part;
        public string Part
        {
            get { return _part; }
            set
            {
                if (_part != value)
                {
                    _part = value;
                    OnPropertyChanged(nameof(Part));
                }
            }
        }

        private string _accNumber;
        public string AccNumber
        {
            get { return _accNumber; }
            set
            {
                if (_accNumber != value)
                {
                    _accNumber = value;
                    OnPropertyChanged(nameof(AccNumber));
                }
            }
        }

        private string _partNumber;
        public string PartNumber
        {
            get { return _partNumber; }
            set
            {
                if (value != _partNumber)
                {
                    _partNumber = value;
                    OnPropertyChanged(nameof(PartNumber));
                }
            }
        }

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ServiceEntryGuaranteePart()
        {
            Number = "";
            Part = "";
            AccNumber = "";
            PartNumber = "";
            Quantity = "";
        }
    }

}