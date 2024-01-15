using WeatherApi.DTO;

namespace WeatherApi.Interfaces
{
    public interface IReposiotry
    {
        public Task<IReadOnlyList<Weather>> GetAllAsync();
        public Task<Weather> GetByIdAsync(int Id);
        public Task<Weather> GetByNameAsync(string name);
        public Task AddAsync(Weather countryWeather);
        public Task UpdateAsync(int id,Weather countryWeather);
        public Task DeleteAsync(int countryId);

    }
}
