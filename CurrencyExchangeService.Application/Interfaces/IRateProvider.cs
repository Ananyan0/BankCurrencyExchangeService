namespace CurrencyExchangeService.Application.Interfaces;

public interface IRateProvider
{
    decimal GetUsdToAmdRate();
}
