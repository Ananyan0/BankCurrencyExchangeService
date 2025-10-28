using CurrencyExchangeService.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CurrencyExchangeService.Infrastructure.Repositories;

public class StaticRateProvider : IRateProvider
{
    private readonly IConfiguration _config;
    public StaticRateProvider(IConfiguration config) => _config = config;

    public decimal GetUsdToAmdRate()
    {
        return _config.GetValue<decimal?>("Rates:UsdToAmd") ?? 390m;
    }
}