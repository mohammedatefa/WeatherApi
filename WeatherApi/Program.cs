
using Microsoft.EntityFrameworkCore;
using WeatherApi.Context;
using WeatherApi.DTO;
using WeatherApi.Interfaces;
using WeatherApi.Reposiotris;

namespace WeatherApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add dbcontext configration
            builder.Services.AddDbContext<WeatherDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDbContext"));
            });

            //injection the weatherrepositry
            builder.Services.AddScoped<IReposiotry, Reposiotry>();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", option =>
                {
                    option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
    
            var app = builder.Build();

          


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
           
            app.UseCors("MyPolicy");
           
            app.MapControllers();

            app.Run();
        }
    }
}
