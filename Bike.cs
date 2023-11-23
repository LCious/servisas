using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisas
{
    [Serializable]
    public class Bike
    {
        [JsonProperty("BikeId")]
        public string BikeId { get; set; } = "...";

        [JsonProperty("Model")]
        public string Model { get; set; } = "...";

        [JsonProperty("OverallCondition")]
        public string OverallCondition { get; set; } = "...";

        [JsonProperty("CoolantLevel")]
        public string CoolantLevel { get; set; } = "...";

        [JsonProperty("EngineOilLevel")]
        public string EngineOilLevel { get; set; } = "...";//1

        [JsonProperty("TyrePressure")]
        public string TyrePressure { get; set; } = "...";

        [JsonProperty("Fasteners")]
        public string Fasteners { get; set; } = "...";

        [JsonProperty("WaterPump")]
        public string WaterPump { get; set; } = "...";

        //Additional information
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("IsLocked")]
        public bool IsLocked {  get; set; }

        public Bike()
        {
            CreatedDate = DateTime.Now;
            IsLocked = false;
        }
    }
}