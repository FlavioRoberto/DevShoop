using DevShoop.ProductAPI.Data.Context;
using DevShoop.ProductAPI.Data.Repositories;
using DevShoop.ProductAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevShoop.ProductAPI.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connection = configuration.GetConnectionString("MySQLConnectionString");

        return services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddDbContext<ProductApiContext>(options =>
                    options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 23)))
                );
    }
}
