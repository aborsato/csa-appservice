using System.Threading.Tasks;
using System.Collections.Generic;
using webapp.Models;

namespace webapp.Services
{
    public interface IWeatherForecastService
    {
        public Task<List<WeatherForecast>> GetNAsync(string queryString);
    }
}