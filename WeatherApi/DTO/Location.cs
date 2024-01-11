namespace WeatherApi.DTO
{
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string localtime { get; set; }
    }
}