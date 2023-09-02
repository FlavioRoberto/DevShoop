namespace DevShoop.Web.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddHttpServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var productApiUri = builder.Configuration["ServiceUrls:ProductApi"] ?? throw new ArgumentNullException("ProductApiUri not defined!");

        services.AddHttpClient<IProductService, ProductService>(
         config => config.BaseAddress = new Uri(productApiUri)
       );

        return services;
    }
}
