namespace WebAppWeatherForecast.Web.DomainServices.Base
{
    public interface IHealthService
    {
        bool CheckForRespond();

        bool CheckSiteStatus();
    }
}
