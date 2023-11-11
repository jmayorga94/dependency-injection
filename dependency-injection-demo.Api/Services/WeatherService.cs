using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_injection_demo.Api.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<List<WeatherForecast>> GetWeather()
        {
          var weather =  new WeatherForecast()
          {
            DateTime = DateTime.now
          }
          var weatherList = new List<WeatherForecast>()
          {
           
          }
           return Task.FromResult()
        }

    }
}