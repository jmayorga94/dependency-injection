using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dependency_injection_demo;

namespace dependency_injection_demo.Api.Services
{
    public interface IWeatherService
    {
        Task<List<WeatherForecast>> GetWeather();
    }
}