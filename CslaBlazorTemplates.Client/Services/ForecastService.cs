using CslaBlazorTemplates.Ui.Data;
using CslaBlazorTemplates.Ui.Services;
using System.Net.Http.Json;

namespace CslaBlazorTemplates.Client.Services
{
    public class ForecastService : IForecastService
    {
        private HttpClient Http;
        public ForecastService(HttpClient httpClient)
        {
            Http = httpClient;
        }
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime time)
        {
            return await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }
    }
}
