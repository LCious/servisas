using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace servisas
{
    public class JsonFileHandler
    {
        private const string FilePath = "bikes.json";

        public static void SaveBikesToJson(List<Bike> bikes)
        {
            string jsonData = JsonConvert.SerializeObject(bikes);
            File.WriteAllText(FilePath, jsonData);
        }

        public static List<Bike> LoadBikesFromJson()
        {
            if(File.Exists(FilePath))
            {
                string jsonData = File.ReadAllText(FilePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonConvert.DeserializeObject<List<Bike>>(jsonData) ?? new List<Bike>();
                }
                
            }
            return new List<Bike>();
        }
    }
}
