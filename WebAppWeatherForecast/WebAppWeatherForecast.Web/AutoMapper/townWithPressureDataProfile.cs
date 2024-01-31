using WebAppWeatherForecast.Web.Models.Api;
using AutoMapper;

namespace WebAppWeatherForecast.Web.AutoMapper
{
    public class townWithPressureDataProfile : Profile
    {

        public townWithPressureDataProfile()
        {
            CreateMap<SynopticDataResponse, townWithPressure>()
                .ForMember(dest => dest.townName,
                    opt => opt.MapFrom(s => s.Stacja))
                .ForMember(dest => dest.pressure,
                    opt => opt.MapFrom(s => s.Cisnienie));
        }
    }
}
