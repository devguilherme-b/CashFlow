using Microsoft.Extensions.Configuration;

namespace CashFlow.Infrastructure.Extensions;
public static class ConfigurationExtension
{
    public static bool IsTetEnviroment(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("IsTestEnviroment");
    }
}