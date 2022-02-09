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
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.GameContainer);

            var results = await GetQueryResults<Game>(
                DBConstants.GameContainer,
                DBConstants.GamePartition,
                queryDefinition);
            
            return results;
        }
        
        public async Task<Game?> GetSingleGame(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.GameContainer,
                id);

            var results = await GetQueryResults<Game>(
                DBConstants.GameContainer,
                DBConstants.GamePartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<Game?> AddNewGame(Game newEntry)
        {
            
            var queryDefinition = CreateNewGameQueryDefinition(
                DBConstants.GameContainer,
                newEntry);

            var results = await GetQueryResults<Game>(
                DBConstants.GameContainer,
                DBConstants.GamePartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Developer>> GetAllDevelopers()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.DeveloperContainer);

            var results = await GetQueryResults<Developer>(
                DBConstants.DeveloperContainer,
                DBConstants.DeveloperPartition,
                queryDefinition);
            
            return results;
        }

        public async Task<Developer?> GetSingleDeveloper(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.DeveloperContainer,
                id);

            var results = await GetQueryResults<Developer>(
                DBConstants.DeveloperContainer,
                DBConstants.DeveloperPartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Series>> GetAllSeries()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.SeriesContainer);

            var results = await GetQueryResults<Series>(
                DBConstants.SeriesContainer,
                DBConstants.SeriesPartition,
                queryDefinition);
            
            return results;
        }

        public async Task<Series?> GetSingleSeries(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.SeriesContainer,
                id);

            var results = await GetQueryResults<Series>(
                DBConstants.SeriesContainer,
                DBConstants.SeriesPartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Mechanic>> GetAllMechanics()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.MechanicContainer);

            var results = await GetQueryResults<Mechanic>(
                DBConstants.MechanicContainer,
                DBConstants.MechanicParition,
                queryDefinition);
            
            return results;
        }

        public async Task<Mechanic?> GetSingleMechanic(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.MechanicContainer,
                id);

            var results = await GetQueryResults<Mechanic>(
                DBConstants.MechanicContainer,
                DBConstants.MechanicParition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<OST>> GetAllOSTs()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.OSTContainer);

            var results = await GetQueryResults<OST>(
                DBConstants.OSTContainer,
                DBConstants.OSTPartition,
                queryDefinition);
            
            return results;
        }

        public async Task<OST?> GetSingleOST(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.OSTContainer,
                id);

            var results = await GetQueryResults<OST>(
                DBConstants.OSTContainer,
                DBConstants.OSTPartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Platform>> GetAllPlatforms()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.PlatformContainer);

            var results = await GetQueryResults<Platform>(
                DBConstants.PlatformContainer,
                DBConstants.PlatformPartition,
                queryDefinition);
            
            return results;
        }

        public async Task<Platform?> GetSinglePlatform(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.PlatformContainer,
                id);

            var results = await GetQueryResults<Platform>(
                DBConstants.PlatformContainer,
                DBConstants.PlatformPartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Release>> GetAllReleases()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.ReleaseContainer);

            var results = await GetQueryResults<Release>(
                DBConstants.ReleaseContainer,
                DBConstants.ReleasePartition,
                queryDefinition);
            
            return results;
        }

        public async Task<Release?> GetSingleRelease(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.ReleaseContainer,
                id);

            var results = await GetQueryResults<Release>(
                DBConstants.ReleaseContainer,
                DBConstants.ReleasePartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        public async Task<List<Staff>> GetAllStaff()
        {
            var queryDefinition = GetAllEntityQueryDefinition(
                DBConstants.StaffContainer);

            var results = await GetQueryResults<Staff>(
                DBConstants.StaffContainer,
                DBConstants.StaffPartition,
                queryDefinition);
            
            return results;
        }

        public async Task<Staff?> GetSingleStaff(string id)
        {
            var queryDefinition = GetSingleEntityByIdQueryDefinition(
                DBConstants.StaffContainer,
                id);

            var results = await GetQueryResults<Staff>(
                DBConstants.StaffContainer,
                DBConstants.StaffPartition,
                queryDefinition);

            var result = results.FirstOrDefault();

            return result;
        }

        private QueryDefinition GetAllEntityQueryDefinition(
            string containerName)
        {
            var queryString = $"SELECT * FROM {containerName}";
            var queryDefinition = new QueryDefinition(queryString);

            return queryDefinition;
        }

        private QueryDefinition GetSingleEntityByIdQueryDefinition(
            string containerName,
            string id)
        {
            var queryString = $"SELECT * FROM {containerName} WHERE {containerName}.id='{id}'";
            var queryDefinition = new QueryDefinition(queryString);

            return queryDefinition;
        }
        private QueryDefinition CreateNewGameQueryDefinition(
            string containerName,
            Game newEntry)
        {
            var queryString = $"INSERT INTO {containerName} (id, title, romanizedTitle, releases," +
                $" sharedMechanics, series, averagePlayLength, dataPoints, boxArtURL) " +
                $"VALUES ('{newEntry.Id}', '{newEntry.Title}', '{newEntry.RomanizedTitle}', " +
                $"'{newEntry.Releases}', '{newEntry.SharedMechanics}', '{newEntry.Series}', " +
                $"'{newEntry.AveragePlayLength}', '{newEntry.DataPoints}', '{newEntry.BoxArtURL}');";

            var queryDefinition = new QueryDefinition(queryString);

            return queryDefinition;
        }

        private async Task<List<T>> GetQueryResults<T>(
            string containerName,
            string partitionName,
            QueryDefinition queryDefinition)
        {
            var container = await GetDbContainer(
                containerName,
                partitionName);

            var results = new List<T>();

            using (var iterator = container.GetItemQueryIterator<T>(queryDefinition))
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