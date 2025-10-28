using CurrencyExchangeService.Domain.Events;

namespace CurrencyExchangeService.Application.Interfaces;

public interface IExchangeProcessor
{
    Task HandleAsync(CurrencyExchangeRequest request, CancellationToken cancellationToken = default);
}
