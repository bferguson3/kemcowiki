using api.Interfaces;
using api.Services;
using api.Models;
using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;

public class Program
{
    private static readonly string EndpointUri = "https://kemcowiki.documents.azure.com:443/";
    private static readonly string PrimaryReadOnlyKey = "sJ8scLbCX0hi5yswpqM1cMjbGQK1Yasg5f4aWVV1TtNza2c22x8CrYsPFo0x20aAqLxucLBZyuG3cF3kMBjN1A==";
    private CosmosClient cosmosClient;
    private Database database;
    private Container container;
    private string databaseId = "kemcogames";
    private string containerId = "container1";
    
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IGameService, GameService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        //////// CosmosDB test
        try
        {
            Console.WriteLine("Beginning Azure CosmosDB access test...\n");
            Program p = new Program();
            await p.GetStartedDemoAsync();
        }
        catch (CosmosException de)
        {
            Exception baseException = de.GetBaseException();
            Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e);
        }
        finally
        {
            Console.WriteLine("End of demo, press any key to exit.");
            Console.ReadKey();
        }
        /////////// Now run API service
        app.Run();
    }

    public async Task GetStartedDemoAsync()
    {
        this.cosmosClient = new CosmosClient(EndpointUri, PrimaryReadOnlyKey);
        await this.CreateDatabaseAsync();
        await this.CreateContainerAsync();
        // additemstocontainerasync if needed
        await this.QueryItemsAsync();
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
