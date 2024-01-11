namespace WeatherApi.DTO
{
    public class Current
    {
        public double temp_c { get; set; }
        public double temp_f { get; set;}
        public int is_day { get; set; }
        public Condition condition { get; set; }
        public double wind_mph { get; set; }
        public double wind_kph { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public int cloud { get; set; }
    }
}