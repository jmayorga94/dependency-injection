using System.Net;
using dependency_injection_demo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace dependency_injection_demo.Api.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;
    private readonly FeaturesConfiguration _config;
    

    public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger, IOptionsSnapshot<FeaturesConfiguration> options)
    {
        _weatherService = weatherService;
        _logger = logger;
        _config = options.Value;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(WeatherForecast),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetWeather()
    {
        bool isWeatherForecastEnable = _config.EnableWeatherForeCast;

        if(isWeatherForecastEnable)
        {
            try 
            {
                var result = await _weatherService.GetWeather();

                if(result==null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,new WeatherForecast());
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,"WHOOPS");

            }
        }
       else
       {
          return StatusCode(StatusCodes.Status500InternalServerError,"Looks like weather forecast is not enabled, please activate it!!");
       }      
    }
}
