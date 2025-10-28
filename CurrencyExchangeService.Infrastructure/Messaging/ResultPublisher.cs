using CurrencyExchangeService.Application.Interfaces;
using CurrencyExchangeService.Domain.Events;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace CurrencyExchangeService.Infrastructure.Messaging;

public class ResultPublisher : IResultPublisher
{
    private readonly string _host;
    private const string ExchangeName = "bank.currency.exchanges";

    public ResultPublisher(IConfiguration cfg)
    {
        _host = cfg.GetValue<string>("RabbitMQ:HostName") ?? "localhost";
    }

    public async Task PublishAsync(CurrencyExchangeCreated evt)
    {
        var factory = new ConnectionFactory { HostName = _host };
        await using var conn = await factory.CreateConnectionAsync();
        await using var ch = await conn.CreateChannelAsync();

        await ch.ExchangeDeclareAsync(
            exchange: ExchangeName,
            type: ExchangeType.Direct,
            durable: true
        );
        
        var json = JsonSerializer.Serialize(evt);
        var body = Encoding.UTF8.GetBytes(json);

        var routingKey = "usd.amd.result";


        await ch.BasicPublishAsync(
                exchange: ExchangeName,
                routingKey: routingKey,
                mandatory: false,
                body: body
            );
    }
}