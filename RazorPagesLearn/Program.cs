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
/*builder.WebHost.ConfigureKestrel(serverOptions => 
{
    serverOptions.ListenAnyIP(7287 ,listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
    serverOptions.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});*/
/*ConfigureWebHostDefaults(webBuilder => webBuilder.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080, listenOptions => listenOptions.Protocols = HttpProtocols.Http1);
    options.ListenAnyIP(5000, listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
});*/
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
