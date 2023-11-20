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
            if (existingBike != null)
            {
                existingBike.Model = updatedBike.Model;
                existingBike.OverallCondition = updatedBike.OverallCondition ?? "...";
                existingBike.CoolantLevel = updatedBike.CoolantLevel ?? "...";
                existingBike.EngineOilLevel = updatedBike.EngineOilLevel ?? "...";//2
                existingBike.TyrePressure = updatedBike.TyrePressure ?? "...";
                existingBike.Fasteners = updatedBike.Fasteners ?? "...";
                existingBike.WaterPump = updatedBike.WaterPump ?? "...";
            }
        }

        public Bike? GetBikeById(string bikeId)
        {
            return bikes.FirstOrDefault(b => b.BikeId == bikeId);
        }

    }
}