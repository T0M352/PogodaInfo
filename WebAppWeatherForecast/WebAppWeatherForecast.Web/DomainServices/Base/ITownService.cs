using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices.Base;

public interface ITownService
{
    List<string> GetTownsList();
    SynopticDataResponse GetTownData(string normalizedName);

    List<SynopticDataResponse> getAllWeather();

    
}