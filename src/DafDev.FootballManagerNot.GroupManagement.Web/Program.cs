using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//Registering services and adding services to DI controller
{
    var services = builder.Services;
    services.AddControllersWithViews();
}

var app = builder.Build();
// Configure Httprequest pipeline
{
    app.MapControllers();
}

app.MapGet("/", () => "This is the begining");


app.Run();
