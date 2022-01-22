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
    public string containerId = "container1";

    public async Task GetStartedDemoAsync()
    {
        try {
            Console.WriteLine("bish");
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryReadOnlyKey);
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
            // additemstocontainerasync if needed
            await this.QueryItemsAsync();
        } catch (CosmosException de) {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        } catch (Exception e) {
            Console.WriteLine("Error: {0}", e);
        }

    }

    private async Task CreateDatabaseAsync()
    {
        // Create a new database
        this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
        Console.WriteLine("Created Database: {0}\n", this.database.Id);
    }

    private async Task CreateContainerAsync()
    {
        // Create a new container
        //FIXME : Don't know what the argument here is for
        this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/games");
        Console.WriteLine("Created Container: {0}\n", this.container.Id);
    }

    private async Task QueryItemsAsync()
    {
        // test query
        var sqlQueryText = "SELECT * FROM c";
        Console.WriteLine("Running query: {0}\n", sqlQueryText);

        QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
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
    }
}

