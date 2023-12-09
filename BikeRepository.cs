using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisas
{
    public class BikeRepository
    {
        private List<Bike> bikes; // = new List<Bike>();

        public BikeRepository()
        {
            bikes = new List<Bike>();
            LoadBikesFromJson();
        }

        public void LoadBikesFromJson()
        {
            bikes = JsonFileHandler.LoadBikesFromJson();
        }

        public void AddBike(Bike bike)
        {
            bikes.Add(bike);
        }

        public void DeleteBike(string bikeId)
        {
            bikes.RemoveAll(bike => bike.BikeId == bikeId);
            JsonFileHandler.SaveBikesToJson(bikes);
        }

        public List<Bike> GetAllBikes()
        {
            return bikes;
        }

        public void UpdateBike(Bike updatedBike)
        {
            var existingBike = bikes.FirstOrDefault(b => b.BikeId == updatedBike.BikeId);
            if (existingBike != null) // 2
            {
                existingBike.Nr = updatedBike.Nr;
                existingBike.Mechanic = updatedBike.Mechanic;

                //First table
                existingBike.DateService = updatedBike.DateService;
                existingBike.Model = updatedBike.Model;
                existingBike.Phone = updatedBike.Phone;
                existingBike.Mileage = updatedBike.Mileage;
                existingBike.BikeId = updatedBike.BikeId; // VIN
                existingBike.MotoH = updatedBike.MotoH;
                existingBike.RegistrationPlate = updatedBike.RegistrationPlate;
                existingBike.ManufactureYear = updatedBike.ManufactureYear;

                //Second table
                existingBike.ManufactureUpdate = updatedBike.ManufactureUpdate ?? "...";
                existingBike.GuaranteeUpdate = updatedBike.GuaranteeUpdate ?? "...";
                existingBike.RR = updatedBike.RR ?? "...";

                //Third table
                existingBike.NonGuaranteeServices = updatedBike.NonGuaranteeServices;

                //Fourth table
                existingBike.NonGuaranteeServicesTime = updatedBike.NonGuaranteeServicesTime;

                //Fifth table
                existingBike.NonGuaranteeServicesPart = updatedBike.NonGuaranteeServicesPart;

                //Sixth table
                existingBike.GuaranteeServices = updatedBike.GuaranteeServices;

                //Seventh table
                existingBike.GuaranteeServicesPart = updatedBike.GuaranteeServicesPart;

                //First check
                existingBike.OverallCondition = updatedBike.OverallCondition ?? "...";
                existingBike.CoolantLevel = updatedBike.CoolantLevel ?? "...";
                existingBike.EngineOilLevel = updatedBike.EngineOilLevel ?? "...";
                existingBike.TyrePressure = updatedBike.TyrePressure ?? "...";
                existingBike.Fasteners = updatedBike.Fasteners ?? "...";
                existingBike.WaterPump = updatedBike.WaterPump ?? "...";

                //Electric check
                existingBike.LowBeam = updatedBike.LowBeam ?? "...";
                existingBike.HighBeam = updatedBike.HighBeam ?? "...";
                existingBike.Blinkers = updatedBike.Blinkers ?? "...";
                existingBike.EmergencyBlinkers = updatedBike.EmergencyBlinkers ?? "...";

                //Additional information
                existingBike.UpdatedDate = updatedBike.UpdatedDate;
                existingBike.IsLocked = updatedBike.IsLocked;
            }
        }

        public Bike? GetBikeById(string bikeId)
        {
            return bikes.FirstOrDefault(b => b.BikeId == bikeId);
        }

    }
}