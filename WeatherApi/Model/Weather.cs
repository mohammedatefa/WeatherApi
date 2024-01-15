namespace WeatherApi.DTO
{
    public class Weather
    {
        public int Id { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }

   
}
