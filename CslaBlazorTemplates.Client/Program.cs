using CslaBlazorTemplates.Client.Services;
using CslaBlazorTemplates.Ui;
using CslaBlazorTemplates.Ui.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Csla.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddCsla(options => options
  .WithBlazorWebAssembly()
  .DataPortal()
  .UseHttpProxy(options => options.DataPortalUrl = "/api/DataPortal"));

builder.UseCsla();

builder.Services.AddSingleton<IForecastService, ForecastService>();

await builder.Build().RunAsync();
