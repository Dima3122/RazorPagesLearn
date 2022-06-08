using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using RazorPagesLearn.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmployeeRepository, MokEmployRepository>();
builder.WebHost.UseMetricsEndpoints(options =>
{
    options.EnvironmentInfoEndpointEnabled = false;
    options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
    options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
});
builder.WebHost.UseMetricsWebTracking(options =>
{
    options.OAuth2TrackingEnabled = true;
});
builder.WebHost.UseKestrel().ConfigureKestrel(options =>
{
    options.ListenAnyIP(9299);
});
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
