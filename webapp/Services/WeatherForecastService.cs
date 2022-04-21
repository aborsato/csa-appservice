using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using webapp.Models;

namespace webapp.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IMongoCollection<WeatherForecast> _forecasts;

    public WeatherForecastService(MongoService mongo, IDatabaseSettings settings)
    {
        var db = mongo.GetClient().GetDatabase(settings.DatabaseName);
        _forecasts = db.GetCollection<WeatherForecast>(settings.ProductCollectionName);
    }

    public Task<List<WeatherForecast>> GetNAsync(int n)
    {
        return _forecasts.Find(product => true).Limit(n).ToListAsync();
    }

}
