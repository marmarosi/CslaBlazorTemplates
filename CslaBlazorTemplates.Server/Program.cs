using Csla.Configuration;
using CslaBlazorTemplates.Server.Services;
using CslaBlazorTemplates.Ui.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

string BlazorClientPolicy = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        BlazorClientPolicy,
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
}); 

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCsla(
    options =>
        options
        .AddAspNetCore()
        .DataPortal(
            dpo =>
                dpo
                .AddServerSideDataPortal()
                .UseLocalProxy()
            )
    );

//for EF Db
//builder.Services.AddTransient(typeof(DataAccess.IPersonDal), typeof(DataAccess.EF.PersonEFDal));
//builder.Services.AddDbContext<DataAccess.EF.PersonDbContext>(
//options => options.UseSqlServer("Server=servername;Database=personDB;User ID=sa; Password=pass;Trusted_Connection=True;MultipleActiveResultSets=true"));

builder.Services.AddSingleton<IAppService, AppService>();
builder.Services.AddScoped<IForecastService, ForecastService>();

// If using Kestrel:
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
// If using IIS:
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
//app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();
