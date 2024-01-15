using Microsoft.EntityFrameworkCore;
using WeatherApi.Context;
using WeatherApi.DTO;
using WeatherApi.Interfaces;

namespace WeatherApi.Reposiotris
{
    public class Reposiotry : IReposiotry
    {
        private readonly WeatherDbContext context;

        public Reposiotry(WeatherDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IReadOnlyList<Weather>> GetAllAsync()
        {
            return await context.Set<Weather>().Include(w => w.location).Include(w => w.current).ThenInclude(c=>c.condition).ToListAsync();
        }
        public async Task<Weather> GetByIdAsync(int id)
        {
            return await context.Set<Weather>().Include(w=>w.location).Include(w=>w.current).ThenInclude(c => c.condition).FirstOrDefaultAsync(w => w.Id == id);

        }
        public async Task<Weather> GetByNameAsync(string name)
        {
            return  context.Set<Weather>().Include(w => w.location).Include(w => w.current).ThenInclude(c => c.condition).FirstOrDefault(w=>w.location.Name==name);
        }
        public async Task AddAsync(Weather countryWeather)
        {
            if (countryWeather is not null)
            {
                try
                {
                    await context.Set<Weather>().AddAsync(countryWeather);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw new Exception("there is error occured during add new item in the data base", ex);

                }

            }
        }
        public async Task UpdateAsync(int id, Weather countryWeather)
        {
            var found = await context.Set<Weather>().FindAsync(id);
            if (found is not null)
            {
                try
                {
                    context.Set<Weather>().Update(countryWeather);
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new Exception("there is error occured during add new item in the data base", ex);
                }
            }

        }
        public async Task DeleteAsync(int id)
        {
            var found = await context.Set<Weather>().FindAsync(id);
            if (found is not null)
            {
                try
                {
                    context.Set<Weather>().Remove(found);
                }
                catch (Exception ex)
                {

                    throw new Exception("there is error occured during add new item in the data base", ex);
                }
            }
        }


       
    }
}