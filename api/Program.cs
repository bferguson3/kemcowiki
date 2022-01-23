using api.Interfaces;
using api.Services;
using api.Models;
using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;

public class Program
{
    public static DBService? db;

    public static async Task Main(string[] args)
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

        builder.Services.AddScoped<IGameService, GameService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
        
        db = new DBService();
        //db.GetStartedDemoAsync();

        app.Run();
    }

    
}
