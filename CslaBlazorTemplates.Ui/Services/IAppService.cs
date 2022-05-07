using CslaBlazorTemplates.Ui.Data;

namespace CslaBlazorTemplates.Ui.Services
{
    public interface IAppService
    {
        Task<AppData> GetDataAsync();
    }
}
