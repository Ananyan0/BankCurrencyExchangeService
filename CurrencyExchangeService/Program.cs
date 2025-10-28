using CurrencyExchangeService.Application.Interfaces;
using CurrencyExchangeService.Application.Services;
using CurrencyExchangeService.Infrastructure.Messaging;
using CurrencyExchangeService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<RequestConsumer>();


// Add services to the container.
builder.Services.AddScoped<IRateProvider, StaticRateProvider>();
builder.Services.AddScoped<IResultPublisher, ResultPublisher>();
builder.Services.AddScoped<IExchangeProcessor, ExchangeProcessor>();

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
