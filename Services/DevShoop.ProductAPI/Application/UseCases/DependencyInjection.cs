using DevShoop.ProductAPI.Application.UseCases.Product;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        return services.AddScoped<IAddProductUseCase, AddProductUseCaseHandler>()
                       .AddScoped<IListProductUseCase, ListProductUseCaseHandler>()
                       .AddScoped<IUpdateProductUseCase, UpdateProductUseCaseHandler>();     
    }
}
