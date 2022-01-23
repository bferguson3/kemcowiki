using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace api.Services
{
    public class DataService : IDataService
    {
        private readonly IApiSettings _settings;
        private readonly CosmosClient _cosmosClient;

        private Database? _database;

        public DataService(
            IApiSettings settings,
            CosmosClient cosmosClient)
        {
            _settings = settings;
            _cosmosClient = cosmosClient;
        }

        private async Task<Container> GetDbContainer<T>()
            where T: IDataModel
        {
            _database = _database ?? await _cosmosClient
                .CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);

            var entityType = typeof(T);

            var container = await _database.CreateContainerIfNotExistsAsync(
                entityType.Name.ToContainerName(),
                entityType.Name.ToPartitionName());
            
            return container;
        }

        public async Task<List<T>> GetAll<T>()
            where T: IDataModel
        {
            var container = await GetDbContainer<T>();

            var query = container.GetItemLinqQueryable<T>();
            var iterator = query.ToFeedIterator();

            var results = new List<T>();

            while (iterator.HasMoreResults)
            {
                foreach (var item in await iterator.ReadNextAsync())
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public async Task<T?> GetSingle<T>(string id)
            where T: IDataModel
        {

            var container = await GetDbContainer<T>();

            var query = container.GetItemLinqQueryable<T>();
            
            //this does not work
            var iterator = query
                .Where(q => q.Id == id)
                .ToFeedIterator();

            T? result = default(T);

            if (iterator.HasMoreResults)
            {
                result = (await iterator.ReadNextAsync()).FirstOrDefault();
            }

            return result;
        }
    }
}