using Microsoft.Azure.Cosmos;
using api.Interfaces;
using api.Services;
using api.Models;

namespace api.Services
{
public class DBService : IDbService
{
    public static readonly string EndpointUri = "https://kemcowiki.documents.azure.com:443/";
    public static readonly string PrimaryReadOnlyKey = "sJ8scLbCX0hi5yswpqM1cMjbGQK1Yasg5f4aWVV1TtNza2c22x8CrYsPFo0x20aAqLxucLBZyuG3cF3kMBjN1A==";
    public CosmosClient? cosmosClient;
    public Database database;
    public Container container;
    public string databaseId = "kemcogames";
    public string containerId = "releases";
    public string partitionKey = "/releases";
    public string selectKey = "*";

    public async Task<QueryDefinition> TestQueryAsync()
    {
        QueryDefinition? q = new QueryDefinition("{}");
        try {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryReadOnlyKey);
            await this.CreateDatabaseAsync(databaseId);
            await this.CreateContainerAsync(containerId, partitionKey);
            // additemstocontainerasync if needed

            String queryString = String.Format("SELECT * FROM {0} WHERE {0}.id = \"{1}\"", containerId, selectKey);
            q = await this.QueryItemsAsync(queryString);
            
            return q;

        } catch (CosmosException de) {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        } catch (Exception e) {
            Console.WriteLine("Error: {0}", e);
        }
        return q;
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
 }
}
