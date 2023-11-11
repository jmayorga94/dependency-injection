using dependency_injection_demo.Api;
using dependency_injection_demo.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

//Add custom dependencies
builder.Services.AddTransient<IWeatherService,WeatherService>();
builder.Services.Configure<FeaturesConfiguration>(config.GetSection("Features"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
