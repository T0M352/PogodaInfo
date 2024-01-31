using System.Text.Json.Serialization;

namespace WebAppWeatherForecast.Web.Models.Api
{
    public class townWithHumidity
    {
        [JsonPropertyName("townName")]
        public string townName { get; set; }

        [JsonPropertyName("humidity")]
        public string humidity { get; set; }
    }
}
