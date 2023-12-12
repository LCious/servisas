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
        private const string hash_FilePath = "credentials.json";

        public static void SaveBikesToJson(List<Bike> bikes)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonData = JsonConvert.SerializeObject(bikes, settings);
            File.WriteAllText(FilePath, jsonData);
        }

        public static List<Bike> LoadBikesFromJson()
        {
            if (File.Exists(FilePath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string jsonData = File.ReadAllText(FilePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonConvert.DeserializeObject<List<Bike>>(jsonData, settings) ?? new List<Bike>();
                }

            }
            return new List<Bike>();
        }

        public static void SaveHashToJson(string hash)
        {
            string jsonData = JsonConvert.SerializeObject(hash);
            File.WriteAllText(hash_FilePath, jsonData);
        }

        public static string? LoadHashFromJson()
        {
            if (File.Exists(hash_FilePath))
            {
                string jsonData = File.ReadAllText(hash_FilePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonConvert.DeserializeObject<string>(jsonData);
                }
            }
            return null;
        }
    }
}