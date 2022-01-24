using CslaBlazorTemplates.Ui.Data;

namespace CslaBlazorTemplates.Ui.Services
{
    public interface IForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
