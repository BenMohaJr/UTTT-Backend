using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Ultimate_Tic_Tac_Toe.Data;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Repository;
using Microsoft.OpenApi.Models;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
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

        app.Run();

        var host = CreateHostBuilder(args).Build();

        // Run your application logic here, if needed

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<DataContext>(options =>
                {
                    var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
                    options.UseNpgsql(connectionString);
                });

                services.AddScoped<IPlayersRepository, PlayersRepository>();
                services.AddScoped<IMainBoardRepository, MainBoardRepository>();
                services.AddScoped<ILocalBoardRepository, LocalBoardRepository>();
                services.AddScoped<IGamesRepository, GamesRepository>();

                // Add other services here

                // Swagger configuration
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
                });
            });
}


// Add services to the container.





