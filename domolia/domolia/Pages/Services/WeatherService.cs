namespace domolia.Pages.Services
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "8e0477492e242f2d498871f50ad6c27d"; // remplace par ta vraie clé

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var temp = doc.RootElement.GetProperty("main").GetProperty("temp").GetDecimal();
            var weather = doc.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();

            return $"{city} : {temp}°C, {weather}";
        }
    }

    public class NewsItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }


}
