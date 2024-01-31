using WebAppWeatherForecast.Web.Models.Api;
using AutoMapper;

namespace WebAppWeatherForecast.Web.AutoMapper
{
    public class townWithHumidityDataProfile : Profile
    {
        public townWithHumidityDataProfile()
        {
            CreateMap<SynopticDataResponse, townWithHumidity>()
                .ForMember(dest => dest.townName,
                    opt => opt.MapFrom(s => s.Stacja))
                .ForMember(dest => dest.humidity,
                    opt => opt.MapFrom(s => s.WilgotnoscWzgledna));
        }
    }
}
