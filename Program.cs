
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using API_Practice;
using API_Practice.Middlewares;
using API_Practice.Shared.Config;
using System.Configuration;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = configurationBuilder.Build();

//IOptions
//IOptionsSnapshot
//IOptionsMonitor

builder.Services.Configure<MySettings>(configuration.GetSection("MySettings"));

builder.Services.RegisterPresentationServices();

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

//Write custome Middleware

app.UseLogUrl();

app.MapControllers();

app.Run();
