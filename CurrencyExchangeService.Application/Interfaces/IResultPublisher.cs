using CurrencyExchangeService.Domain.Events;

namespace CurrencyExchangeService.Application.Interfaces;

public interface IResultPublisher
{
    Task PublishAsync(CurrencyExchangeCreated evt);
}
