using WebAppWeatherForecast.Web.Models.Api;
using AutoMapper;

namespace WebAppWeatherForecast.Web.AutoMapper
{
    public class townWithTemperatureDataProfile : Profile
    {
        public townWithTemperatureDataProfile()
        {
            CreateMap<SynopticDataResponse, townWithTemp>()
                .ForMember(dest => dest.townName,
                    opt => opt.MapFrom(s => s.Stacja))
                .ForMember(dest => dest.temperature,
                    opt => opt.MapFrom(s => s.Temperatura));
        }
    }
}
