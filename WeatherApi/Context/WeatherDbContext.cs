using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WeatherApi.DTO;

namespace WeatherApi.Context
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext() { }
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }
        public DbSet<Weather> CuontryWeather { get; set; }
    }
}
