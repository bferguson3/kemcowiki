using api.Constants;
using api.Interfaces;
using api.Models;
using Microsoft.Azure.Cosmos;

namespace api.Services
{
    public class DBService : IDBService
    {
        private readonly IApiSettings _settings;
        private readonly CosmosClient _cosmosClient;

        private Database? _database;

        public DBService(
            IApiSettings settings,
            CosmosClient cosmosClient)
        {
            _settings = settings;
            _cosmosClient = cosmosClient;
        }

        public async Task<List<Game>> GetAllGames()
        {
            var container = await GetDbContainer(
                DBConstants.GameContainer,
                DBConstants.GamePartition);

            var queryString = $"SELECT * FROM {DBConstants.GameContainer}";
            var queryDefinition = new QueryDefinition(queryString);

            var results = new List<Game>();

            using (var iterator = container.GetItemQueryIterator<Game>(queryDefinition))
            {
                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        results.Add(item);
                    }
                }
            }
            
            return results;
        }
        
        public async Task<Game?> GetSingleGame(string id)
        {
            var container = await GetDbContainer(
                DBConstants.GameContainer,
                DBConstants.GamePartition);

            var queryString = $"SELECT * FROM {DBConstants.GameContainer} WHERE id={id}";
            var queryDefinition = new QueryDefinition(queryString);

            var results = new List<Game>();

            using (var iterator = container.GetItemQueryIterator<Game>(queryDefinition))
            {
                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        results.Add(item);
                    }
                }
            }
            
            return results.FirstOrDefault();
        }

        private async Task<Container> GetDbContainer(
            string containerName,
            string partitionName)
        {
            _database = _database ?? await _cosmosClient
                .CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);

            var container = await _database.CreateContainerIfNotExistsAsync(
                containerName,
                partitionName);
            
            return container;
        }
    }
}