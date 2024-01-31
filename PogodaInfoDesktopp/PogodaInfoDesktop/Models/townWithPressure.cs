using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PogodaInfoDesktop.Models
{
    public class townWithPressure
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }
        [JsonPropertyName("pressure")]
        public string pressure { get; set; }

        public string toString()
        {
            return townName + " " + pressure;
        }
    }
}
