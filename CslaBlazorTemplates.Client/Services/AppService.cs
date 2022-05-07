using CslaBlazorTemplates.Ui.Data;
using CslaBlazorTemplates.Ui.Services;

namespace CslaBlazorTemplates.Client.Services
{
    public class AppService : IAppService
    {
        public async Task<AppData> GetDataAsync()
        {
            return await Task.FromResult(new AppData
            {
                Mode = "Client"
            });
        }
    }
}
