using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PogodaInfoDesktop.Models
{
    public class townWithHumidity
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }

        [JsonPropertyName("humidity")]
        public string humidity { get; set; }
        public string toString()
        {
            return townName + " " + humidity;
        }
    }
}
