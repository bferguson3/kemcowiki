using api.Interfaces;
using api.Services;
using api.Models;
using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using api.Settings;

public class Program
{
    //todo: put these in a config file
    private static readonly string EndpointUri = "https://kemcowiki.documents.azure.com:443/";
    private static readonly string PrimaryReadOnlyKey = "sJ8scLbCX0hi5yswpqM1cMjbGQK1Yasg5f4aWVV1TtNza2c22x8CrYsPFo0x20aAqLxucLBZyuG3cF3kMBjN1A==";
    private const string databaseId = "kemcogames";
    private const string containerId = "container1";

    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var NativeOrigin = "_nativeOrigin";
        builder.Services.AddCors(options=>
        {
            options.AddPolicy(name: NativeOrigin,
            builder=>{
                builder.WithOrigins("http://localhost:8080")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IApiSettings>(s => 
        {
            var settings = new ApiSettings
            {
                DatabaseName = databaseId
            };

            return settings;
        });

        builder.Services.AddSingleton<CosmosClient>(s => 
        {
            var serializerOptions = new CosmosSerializationOptions
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            };

            var cosmosBuilder = new CosmosClientBuilder(
                    EndpointUri,
                    PrimaryReadOnlyKey)
                .WithSerializerOptions(serializerOptions);

            return cosmosBuilder.Build();
        });

        builder.Services.AddSingleton<IDataService, DataService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(NativeOrigin);
        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();
    }
}
