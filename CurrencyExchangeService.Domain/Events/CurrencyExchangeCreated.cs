namespace CurrencyExchangeService.Domain.Events;

public record CurrencyExchangeCreated(
    decimal AmountUsd,
    decimal RateUsdToAmd,
    decimal ResultAmd,
    DateTime TimestampUtc
);
