using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHealthService _healthService;

        public HealthController(IConfiguration configuration, IHealthService healthService)
        {
            _configuration = configuration;
            _healthService = healthService;
        }

        [HttpGet]
        public ActionResult<bool> checkForRespond()
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            bool status = _healthService.CheckForRespond();
            return status;
        }

        [HttpGet]
        public ActionResult<bool> checkSiteStatus()
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }
            bool status = _healthService.CheckSiteStatus();
            return status;
        }


        private bool SecurityCheck(IHeaderDictionary requestHeaders)
        {
            if (requestHeaders.TryGetValue("client-token", out var token))
            {
                var tokenValue = token.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(tokenValue))
                    return false;

                var localToken = _configuration.GetValue<string>("ClientToken");
                if (string.IsNullOrWhiteSpace(localToken))
                    return false;

                if (tokenValue == localToken)
                    return true;
            }

            return false;
        }
    }
}
