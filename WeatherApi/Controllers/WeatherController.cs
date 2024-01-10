using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {


        [HttpGet]
        [Route("GetCountryName")]
        public async Task<IActionResult> GetCountryName(string lat, string lon)
        {
            using (var client = new HttpClient())
            {
                string apiUrl = $"https://api.geoapify.com/v1/geocode/reverse?lat={lat}&lon={lon}&apiKey=7069deeedfd64c95a6f483d762bd0c6b";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var resualtToJSON = JObject.Parse(result);
                    string state = resualtToJSON["features"]?[0]?["properties"]?["state"]?.ToString();
                    return Ok(state);
                }
                else
                {
                    return BadRequest("Failed to retrieve country name data.");
                }
            }
        }

    }
}
