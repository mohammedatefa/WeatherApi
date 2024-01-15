using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.DTO;
using WeatherApi.Interfaces;
using WeatherApi.Reposiotris;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherSimulatedApi : ControllerBase
    {
        private readonly IReposiotry repository;

        public WeatherSimulatedApi(IReposiotry repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetcountriesWeather")]
        public async Task<IActionResult> GetAll()
        {
            var countryWeather = await repository.GetAllAsync();
            return Ok(countryWeather);
        }

        [HttpGet]
        [Route("GetCountryWeatherById")]
        public async Task<IActionResult> GetById(int id)
        {
            Weather countryWeather= await repository.GetByIdAsync(id);
            return Ok(countryWeather);
        }

        [HttpGet]
        [Route("GetcountryWeatherByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            Weather countryWeather = await repository.GetByNameAsync(name);
            return Ok(countryWeather);
        }

        [HttpPost]
        [Route("AddNewCountryWeather")]
        public async Task<IActionResult> Add(Weather countryWeather)
        {
            await repository.AddAsync(countryWeather);
            return Ok(countryWeather);
        }

        [HttpPut]
        [Route("UpdateCountryWeather")]
        public async Task<IActionResult> Update(int id,Weather countryWeather)
        {
            var found=repository.GetByIdAsync(id);
            if (found!=null)
            {
                await repository.UpdateAsync(id, countryWeather);
                return Ok(countryWeather);
            }
            return NotFound();
             
        }

        [HttpDelete]
        [Route("UpdateCountryWeather")]
        public async Task<IActionResult> Delete(int id)
        {
            var found = repository.GetByIdAsync(id);
            if (found != null)
            {
                await repository.DeleteAsync(id);
                return Ok(found);
            }
            return NotFound();

        }


    }
}
