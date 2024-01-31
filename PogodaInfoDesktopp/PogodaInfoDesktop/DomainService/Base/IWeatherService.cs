using PogodaInfoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogodaInfoDesktop.DomainService.Base
{
    internal interface IWeatherService
    {
        List<WeatherForecastEntry> getAllWeathers();
        WeatherForecastEntry getWeatherForTown(string townName);

        List<townWithHumidity> getTownsWithHumidity(List<string> townNames);

        List<townWithTemp> getTownsWithTemp(List<string> townNames);
        List<townWithPressure> getTownsWithPressure(List<string> townNames);

        bool getSiteStatus();
    }
}
