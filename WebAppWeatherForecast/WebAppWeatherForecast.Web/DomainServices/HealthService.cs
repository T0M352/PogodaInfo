using RestSharp;
using System.Diagnostics;
using WebAppWeatherForecast.Web.DomainServices.Base;

namespace WebAppWeatherForecast.Web.DomainServices
{
    public class HealthService : IHealthService
    {
        private readonly RestClient _restClient;
        private readonly string _baseUrl;

        public HealthService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("BaseUrl");
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new ArgumentNullException();
            }
            _restClient = new RestClient(_baseUrl);
        }


        public bool CheckForRespond() 
        {
            var request = new RestRequest("/apiinfo", Method.Get);

            try
            {
                var response = _restClient.Execute(request);
                if (response.IsSuccessful)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }

        public bool CheckSiteStatus()
        {
            var request = new RestRequest("", Method.Get);

            try
            {
                var response = _restClient.Execute(request);
                if (response.IsSuccessful)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return false;
        }
    }
}
