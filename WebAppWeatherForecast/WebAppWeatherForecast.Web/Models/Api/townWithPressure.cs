using System.Text.Json.Serialization;

namespace WebAppWeatherForecast.Web.Models.Api
{
    public class townWithPressure
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }
        [JsonPropertyName("pressure")]
        public string pressure { get; set; }
    }
}
