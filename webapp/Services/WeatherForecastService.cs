using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using webapp.Models;

namespace webapp.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private Container _container;

    public WeatherForecastService(
        CosmosClient dbClient,
        string databaseName,
        string containerName)
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<WeatherForecast>> GetNAsync(string queryString)
    {
        var query = this._container.GetItemQueryIterator<WeatherForecast>(new QueryDefinition(queryString));
        List<WeatherForecast> results = new List<WeatherForecast>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response.ToList());
        }

        return results;
    }

}
