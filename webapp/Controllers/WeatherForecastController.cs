using Microsoft.AspNetCore.Mvc;

using webapp.Models;
using webapp.Services;
namespace webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _forecastService;

    public WeatherForecastController(IWeatherForecastService forecastService)
    {
        _forecastService = forecastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _forecastService.GetNAsync("SELECT * FROM c");
    }
}
