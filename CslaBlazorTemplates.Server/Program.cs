using Csla.Configuration;
using CslaBlazorTemplates.Server.Services;
using CslaBlazorTemplates.Ui.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCsla(options => options
    .DataPortal()
    .AddServerSideDataPortal()
    .UseLocalProxy());

builder.Services.AddSingleton<IForecastService, ForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseCsla();

app.Run();

/* ================================= */
/*
using Csla.Configuration;
using CslaBlazorTemplates.Server.Services;
using CslaBlazorTemplates.Ui.Services;
//using Microsoft.AspNetCore.Server.Kestrel.Core;

//string BlazorClientPolicy = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(BlazorClientPolicy,
//      builder =>
//      {
//        builder
//          .AllowAnyOrigin()
//          .AllowAnyHeader()
//          .AllowAnyMethod();
//      });
//});

//builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCsla(options => options
  .DataPortal()
    .AddServerSideDataPortal()
    .UseLocalProxy());

//for EF Db
//builder.Services.AddTransient(typeof(DataAccess.IPersonDal), typeof(DataAccess.EF.PersonEFDal));
//builder.Services.AddDbContext<DataAccess.EF.PersonDbContext>(
//options => options.UseSqlServer("Server=servername;Database=personDB;User ID=sa; Password=pass;Trusted_Connection=True;MultipleActiveResultSets=true"));

// for Mock Db
//builder.Services.AddTransient(typeof(DataAccess.IPersonDal), typeof(DataAccess.Mock.PersonDal));

//// If using Kestrel:
//builder.Services.Configure<KestrelServerOptions>(options =>
//{
//    options.AllowSynchronousIO = true;
//});

// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddSingleton<IForecastService, ForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
//app.MapControllers();
//app.MapFallbackToFile("index.html");
app.MapFallbackToPage("/_Host");

app.UseCsla();

app.Run();
*/
