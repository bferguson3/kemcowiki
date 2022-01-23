using Microsoft.Azure.Cosmos;
using api.Interfaces;
using api.Services;
using api.Models;

public class DBService
{
    public static readonly string EndpointUri = "https://kemcowiki.documents.azure.com:443/";
    public static readonly string PrimaryReadOnlyKey = "sJ8scLbCX0hi5yswpqM1cMjbGQK1Yasg5f4aWVV1TtNza2c22x8CrYsPFo0x20aAqLxucLBZyuG3cF3kMBjN1A==";
    public CosmosClient? cosmosClient;
    public Database database;
    public Container container;
    public string databaseId = "kemcogames";
    public string containerId = "releases";
    public string partitionKey = "/releases";

    public async Task GetStartedDemoAsync()
    {
        try {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryReadOnlyKey);
            await this.CreateDatabaseAsync(databaseId);
            await this.CreateContainerAsync(containerId, partitionKey);
            // additemstocontainerasync if needed

            QueryDefinition q = await this.QueryItemsAsync("SELECT * FROM c");

            PrintQuery(q);

        } catch (CosmosException de) {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        } catch (Exception e) {
            Console.WriteLine("Error: {0}", e);
        }

    }

    private async Task CreateDatabaseAsync(string databaseName)
    {
        this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
        Console.WriteLine("Created Database: {0}\n", this.database.Id);
    }

    private async Task CreateContainerAsync(string containerName, string partitionName)
    {
        this.container = await this.database.CreateContainerIfNotExistsAsync(containerName, partitionName);
        Console.WriteLine("Created Container: {0}\n", this.container.Id);
    }

    private async Task<QueryDefinition> QueryItemsAsync(string sqlQueryText)
    {
        Console.WriteLine("Running query: {0}\n", sqlQueryText);

        return new QueryDefinition(sqlQueryText);
    }

    private async Task PrintQuery(QueryDefinition queryDefinition)
    {
        /* Only for debugging 
        FeedIterator<Game> queryResultSetIterator = this.container.GetItemQueryIterator<Game>(queryDefinition);
        List<Game> games = new List<Game>();
        while (queryResultSetIterator.HasMoreResults)
        {
            FeedResponse<Game> currentResultSet = await queryResultSetIterator.ReadNextAsync();
            foreach (Game Game in currentResultSet)
            {
                games.Add(Game);
                Console.WriteLine("\tFound game {0}\n", Game.Id);
            }
        }
        */
        int modelType = 0;
        switch(modelType)
        {
            case 0:
                Console.WriteLine("Query type: Releases");
                FeedIterator<Release> queryResultSetIterator = this.container.GetItemQueryIterator<Release>(queryDefinition);
                List<Release> objects = new List<Release>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<Release> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (Release r in currentResultSet)
                    {
                        objects.Add(r);
                        Console.WriteLine("Found release Id: {0}\nRomanizedName: {1}\n\n", r.Id, r.RomanizedName);
                    }
                }
                break;
        }
    }
}

