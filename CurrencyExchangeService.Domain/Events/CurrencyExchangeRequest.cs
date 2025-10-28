namespace CurrencyExchangeService.Domain.Events;

public record CurrencyExchangeRequest(
    decimal AmountUsd,
    DateTime RequestedAtUtc
);
