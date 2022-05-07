using CslaBlazorTemplates.Ui.Data;
using CslaBlazorTemplates.Ui.Services;

namespace CslaBlazorTemplates.Server.Services
{
    public class AppService: IAppService
    {
        public Task<AppData> GetDataAsync()
        {
            return Task.FromResult(new AppData
            {
                Mode = "Server"
            });
        }
    }
}
