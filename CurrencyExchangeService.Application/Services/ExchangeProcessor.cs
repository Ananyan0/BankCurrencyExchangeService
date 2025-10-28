using CurrencyExchangeService.Application.Interfaces;
using CurrencyExchangeService.Domain.Events;

namespace CurrencyExchangeService.Application.Services;

public class ExchangeProcessor : IExchangeProcessor
{
    private readonly IRateProvider _rateProvider;
    private readonly IResultPublisher _publisher;

    public ExchangeProcessor(IRateProvider rateProvider, IResultPublisher publisher)
    {
        _rateProvider = rateProvider;
        _publisher = publisher;
    }

    public async Task HandleAsync(CurrencyExchangeRequest request, CancellationToken cancellationToken = default)
    {
        var rate = _rateProvider.GetUsdToAmdRate();
        var result = request.AmountUsd * rate;

        var evt = new CurrencyExchangeCreated(
            request.AmountUsd,
            rate,
            result,
            DateTime.UtcNow
        );

        await _publisher.PublishAsync(evt);
    }
}