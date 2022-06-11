using Csla.Configuration;
using CslaBlazorTemplates.Client.Services;
using CslaBlazorTemplates.Ui;
using CslaBlazorTemplates.Ui.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
    );

builder.Services.AddAuthorizationCore();
builder.Services.AddOptions();

builder.Services.AddSingleton<IAppService, AppService>();
builder.Services.AddScoped<IForecastService, ForecastService>();

builder.Services.AddCsla(cslaOptions =>
    cslaOptions
    .AddBlazorWebAssembly()
    .DataPortal(dpo =>
        dpo.UseHttpProxy(proxyOptions =>
            proxyOptions.DataPortalUrl = "/api/DataPortal"
            )
        )
    );

await builder.Build().RunAsync();
