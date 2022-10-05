using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
//Registering services and adding services to DI controller
{
    var services = builder.Services;
    services.AddControllers();
}

var app = builder.Build();
// Configure Httprequest pipeline
{
    app.MapControllers();
}

app.MapGet("/", () => "This is the begining");


app.Run();
