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

        // these two things in the constructor are injected via the setup in the Program class
        public DataService(
            IApiSettings settings,
            CosmosClient cosmosClient)
        {
            _settings = settings;
            _cosmosClient = cosmosClient;
        }

        // The <T> here tells the compiler that this is a generic method and expects a model type to be 
        //  passed in when this gets called, the where clause here dictates that the type must be a 
        //  IDataModel
        private async Task<Container> GetDbContainer<T>()
            where T: IDataModel
        {
            _database = _database ?? await _cosmosClient
                .CreateDatabaseIfNotExistsAsync(_settings.DatabaseName);

            var entityType = typeof(T);

            // this creates a container based on the name of the class passed in to the <T>
            var container = await _database.CreateContainerIfNotExistsAsync(
                entityType.Name.ToContainerName(),
                entityType.Name.ToPartitionName());
            
            return container;
        }

        // The <T> here tells the compiler that this is a generic method and expects a model type to be 
        //  passed in when this gets called, the where clause here dictates that the type must be a 
        //  IDataModel
        public async Task<List<T>> GetAll<T>()
            where T: IDataModel
        {
            // we pass the <T> type down to these other methods
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

        // The <T> here tells the compiler that this is a generic method and expects a model type to be 
        //  passed in when this gets called, the where clause here dictates that the type must be a 
        //  IDataModel
        public async Task<T?> GetSingle<T>(string id)
            where T: IDataModel
        {
            // we pass the <T> type down to these other methods
            var container = await GetDbContainer<T>();

            var query = container.GetItemLinqQueryable<T>();

            // this takes the query and filters by the Id property
            using (var iterator = query
                .Where(q => q.Id == id)
                .ToFeedIterator())
            {
                var results = new List<T>();

                // because of the way the azure container works, we have to iterate through
                // the items returned even if we only expect one
                while (iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        results.Add(item);
                    }
                    
                }

                // select just the first result or return null if there are none
                var result =  results.FirstOrDefault();

                return result;
            }
        }
    }
}