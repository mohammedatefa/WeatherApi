using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using WeatherApi.DTO;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
       HttpClient httpClient=new HttpClient();

        [HttpGet]
        [Route("GetWeatherByCountryName")]
        public async Task<IActionResult> GetWeather(string countryname)
        {
            try
            {
                string baseUrl = $" http://api.weatherapi.com/v1/current.json?key=cf816923d55440db88580453232712&q={countryname}";
                HttpResponseMessage response = httpClient.GetAsync(baseUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    Weather data = response.Content.ReadAsAsync<Weather>().Result;

                    return Ok(data);
                }
                return NotFound($"The Country You Enterd {countryname} Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error => {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetCountryNameByLatandLong")]
        public async Task<IActionResult> GetCountryName(string lat, string lon)
        {
            try
            {

                string apiUrl = $"https://api.geoapify.com/v1/geocode/reverse?lat={lat}&lon={lon}&apiKey=7069deeedfd64c95a6f483d762bd0c6b";

                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                     var result = await response.Content.ReadAsStringAsync();
                    var resualtToJSON = JObject.Parse(result);
                    string? state = resualtToJSON["features"]?[0]?["properties"]?["state"]?.ToString();
                    return await GetWeather(state);
                }
                else
                {
                    return BadRequest("Failed to retrieve country name data.");
                }
            }
            catch(Exception ex) {
                return BadRequest($"Error => {ex.Message}");
            }
        }
       

    }
}
