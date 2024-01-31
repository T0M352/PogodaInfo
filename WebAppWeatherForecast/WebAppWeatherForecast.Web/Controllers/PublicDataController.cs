using AutoMapper;
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
    public class PublicDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITownService _townService;
        private readonly ITranslatorService _translatorService;
        private readonly IMapper _mapper;


        public PublicDataController(IConfiguration configuration, ITownService townService, ITranslatorService translatorService, IMapper mapper)
        {
            _configuration = configuration;
            _townService = townService;
            _translatorService = translatorService;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult<List<SynopticDataResponse>> ListOfForecasts()
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            var resultingList = _townService.getAllWeather();

            if (resultingList == null)
                return NotFound();

            return resultingList;
        }

        [HttpGet]
        public ActionResult<List<string>> TownNames()
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            var resultingList = _townService.GetTownsList();

            if (resultingList == null)
                return NotFound();

            return resultingList;
        }




        [HttpGet]
        public ActionResult<SynopticDataResponse> FullTownInformation(string townName)
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(townName))
            {
                return BadRequest();
            }

            var normalizedName = _translatorService.ToSimplePolish(townName);


            var dataResponse = _townService.GetTownData(normalizedName);

            if (dataResponse == null)
                return NotFound();

            return dataResponse;
        }



        [HttpPost] //zmien na post
        public ActionResult<List<townWithHumidity>> TownsWithHumidity([FromBody] List<string> towns)//([FromHeader] string[] towns)
        {


            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }
            

            List < townWithHumidity > resultList = new List<townWithHumidity>();

            List<SynopticDataResponse> dataResponse = _townService.getAllWeather();

            if (dataResponse == null)
                return NotFound();

            foreach (var item in dataResponse)
            {
                if (towns.Contains(item.Stacja))
                {
                    resultList.Add(_mapper.Map<townWithHumidity>(item));
                }
            }


            return resultList;
        }

        [HttpPost]
        public ActionResult<List<townWithTemp>> TownsWithTemperature([FromBody] List<string> towns)
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            List<townWithTemp> resultList = new List<townWithTemp>();

            List<SynopticDataResponse> dataResponse = _townService.getAllWeather();

            if (dataResponse == null)
                return NotFound();

            foreach (var item in dataResponse)
            {
                if (towns.Contains(item.Stacja))
                {
                    resultList.Add(_mapper.Map<townWithTemp>(item));
                }
            }

            return resultList;
        }

        [HttpPost]
        public ActionResult<List<townWithPressure>> TownsWithPressure([FromBody] List<string> towns)
        {
            if (!SecurityCheck(Request.Headers))
            {
                return Unauthorized();
            }

            List<townWithPressure> resultList = new List<townWithPressure>();

            List<SynopticDataResponse> dataResponse = _townService.getAllWeather();

            if (dataResponse == null)
                return NotFound();

            foreach (var item in dataResponse)
            {
                if (towns.Contains(item.Stacja))
                {
                    resultList.Add(_mapper.Map<townWithPressure>(item));
                }
            }

            return resultList;
        }



        private bool SecurityCheck(IHeaderDictionary requestHeaders)
        {
            if( requestHeaders.TryGetValue("client-token",out var token))
            {
                var tokenValue = token.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(tokenValue))
                    return false;

                var localToken = _configuration.GetValue<string>("ClientToken");
                if (string.IsNullOrWhiteSpace(localToken))
                    return false;

                if( tokenValue == localToken )
                    return true;
            }

            return false;
        }
    }
}
