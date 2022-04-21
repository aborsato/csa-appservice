using MongoDB.Driver;
using webapp.Models;


// USE THIS INSTEAD:
// https://github.com/Azure-Samples/cosmos-dotnet-core-todo-app/tree/main/src
//
//

namespace webapp.Services;
public class MongoService
{
    private static MongoClient _client;

    public MongoService(IDatabaseSettings settings)
    {
        _client = new MongoClient(settings.MongoConnectionString);
    }

    public MongoClient GetClient()
    {
        return _client;
    }
}
