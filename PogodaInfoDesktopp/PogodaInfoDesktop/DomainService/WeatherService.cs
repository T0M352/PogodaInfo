using PogodaInfoDesktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PogodaInfoDesktop.DomainService
{
    internal class WeatherService
    {

        private readonly RestClient _restClient;
        private readonly string _baseUrl = Properties.Settings.Default.BaseUrl;
        private readonly string _baseController = Properties.Settings.Default.WeatherController;
        private readonly string _healthController = Properties.Settings.Default.HealthController;
        public WeatherService()
        {
            _restClient = new RestClient(_baseUrl);
        }

        public List<WeatherForecastEntry> getAllWeather()
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/ListOfForecasts", Method.Get);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");

            try
            {
                var result = _restClient.Execute<List<WeatherForecastEntry>>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<List<WeatherForecastEntry>>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public List<string> getTownNames()
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/TownNames", Method.Get);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");
            try
            {
                var result = _restClient.Execute<List<string>>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<List<string>>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public WeatherForecastEntry getWeatherForTown(string townName)
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/FullTownInformation", Method.Get);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");
            request.AddParameter("townName", townName);

            try
            {
                var result = _restClient.Execute<WeatherForecastEntry>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<WeatherForecastEntry>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public List<townWithHumidity> getTownsWithHumidity(List<string> townNames)
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/TownsWithHumidity", Method.Post);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");
            request.AddBody(JsonSerializer.Serialize(townNames));

            try
            {
                var result = _restClient.Execute<List<townWithHumidity>>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<List<townWithHumidity>>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public List<townWithTemp> getTownsWithTemp(List<string> townNames)
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/TownsWithTemperature", Method.Post);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");
            request.AddBody(JsonSerializer.Serialize(townNames));

            try
            {
                var result = _restClient.Execute<List<townWithTemp>>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<List<townWithTemp>>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public List<townWithPressure> getTownsWithPressure(List<string> townNames)
        {
            var request = new RestRequest($"{_baseUrl}{_baseController}/TownsWithPressure", Method.Post);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");
            request.AddBody(JsonSerializer.Serialize(townNames));

            try
            {
                var result = _restClient.Execute<List<townWithPressure>>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<List<townWithPressure>>(result.Content);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public bool getSiteStatus()
        {
            var request = new RestRequest($"{_baseUrl}{_healthController}/checkSiteStatus", Method.Get);
            request.AddHeader("client-token", "2e9cdfa3-1bbb-4419-b0f6-ab9640f2d520");

            try
            {
                var result = _restClient.Execute<bool>(request);
                if (result.IsSuccessful && result.Content != null)
                {
                    return JsonSerializer.Deserialize<bool>(result.Content);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }


    }
}
