using DevShoop.ProductAPI.Application.UseCases;
using DevShoop.ProductAPI.Data;

namespace DevShoop.ProductAPI.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddDependency(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services
                .AddRepositories(configuration)
                .AddUseCases();
    }
}
