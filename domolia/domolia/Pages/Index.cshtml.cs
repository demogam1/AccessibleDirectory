using domolia.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace domolia.Pages
{
    public class IndexModel : PageModel
    {

        private readonly WeatherService _weatherService;

        public string WeatherInfo { get; set; }
        public List<NewsItem> News { get; set; }

        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToPage("/Login");
            }

            WeatherInfo = await _weatherService.GetWeatherAsync("Paris");
            News = new List<NewsItem>
            {
                new NewsItem { Title = "Nouvelle fonctionnalit�", Content = "Domolia ajoute le contr�le vocal.", Date = DateTime.Now },
                new NewsItem { Title = "Mise � jour", Content = "Correction de bugs dans le syst�me d��clairage.", Date = DateTime.Now.AddDays(-1) }
            };
        }
    }
}
