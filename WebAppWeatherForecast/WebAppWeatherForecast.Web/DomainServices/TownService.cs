using RestSharp;
using System.Diagnostics;
using System.Text.Json;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices;

public class TownService: ITownService
{
    private readonly RestClient _restClient;
    private readonly string _baseUrl;

    public TownService(IConfiguration configuration)
    {
        _baseUrl = configuration.GetValue<string>("PublicDataUrl");
        if( string.IsNullOrWhiteSpace(_baseUrl))
        {
            throw new ArgumentNullException();
        }
        _restClient = new RestClient(_baseUrl);
    }




    public List<string> GetTownsList()
    {
        var request = new RestRequest($"/synop", Method.Get);

        try
        {
            var result = _restClient.Execute<List<SynopticDataResponse>>(request);
            if (result.IsSuccessful && result.Content != null)
            {
                var listOfForecast = JsonSerializer.Deserialize<List<SynopticDataResponse>>(result.Content);
                if (listOfForecast == null)
                    return null;

                var listOfTownNames = new List<string>();
                foreach (var item in listOfForecast)
                {
                    listOfTownNames.Add(item.Stacja);
                }

                return listOfTownNames;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return null;
    }

    public List<SynopticDataResponse> getAllWeather()
    {
        var request = new RestRequest($"/synop", Method.Get);

        try
        {
            var result = _restClient.Execute<List<SynopticDataResponse>>(request);
            if (result.IsSuccessful && result.Content != null)
            {
                var listOfForecast = JsonSerializer.Deserialize<List<SynopticDataResponse>>(result.Content);
                if (listOfForecast == null)
                    return null;

                return listOfForecast;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return null;
    }


    public SynopticDataResponse GetTownData(string normalizedName)
    {
        var request = new RestRequest($"/synop/station/{normalizedName}", Method.Get);

        try
        {
            var result = _restClient.Execute<SynopticDataResponse>(request);
            if (result.IsSuccessful && result.Content != null)
            {
                var townInformation = JsonSerializer.Deserialize<SynopticDataResponse>(result.Content);
                if (townInformation == null)
                    return null;

                return townInformation;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return null;
    }
}