using System.Text.Json.Serialization;

namespace WebAppWeatherForecast.Web.Models.Api
{
    public class townWithTemp
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }
        [JsonPropertyName("temperature")]
        public string temperature { get; set; }
    }
}
