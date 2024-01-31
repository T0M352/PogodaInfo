using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PogodaInfoDesktop.Models
{
    public class townWithTemp
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }
        [JsonPropertyName("temperature")]
        public string temperature { get; set; }

        public string toString()
        {
            return townName + " " + temperature;
        }
    }
}
